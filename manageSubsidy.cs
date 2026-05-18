using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PantawidPasada
{
    public partial class manageSubsidy : UserControl
    {
        accessDriverInfo driverAccs = new accessDriverInfo();
        int totalSubsidy = 0;
        EmailService emailService = new EmailService();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
           int nLeftRect, int nTopRect,
           int nRightRect, int nBottomRect,
           int nWidthEllipse, int nHeightEllipse
       );

        private void StylePanel(Panel pnl, int radius = 20)
        {

            pnl.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, pnl.Width, pnl.Height, radius, radius)
            );
        }

        private void setUpManageSub()
        {
            panel1.BackColor = Color.FromArgb(255, 210, 90);
            label2.ForeColor = Color.FromArgb(30, 58, 95);
            giveSub.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, giveSub.Width, giveSub.Height, 20, 20));
            giveSub.BackColor = Color.FromArgb(244, 196, 48);
            panel2.BackColor = Color.FromArgb(30, 58, 95);
            panel3.BackColor = Color.FromArgb(30, 58, 95);
            label1.ForeColor = Color.FromArgb(255, 210, 90);
            label3.ForeColor = Color.FromArgb(255, 210, 90);
            label11.ForeColor = Color.FromArgb(255, 210, 90);
            label10.ForeColor = Color.FromArgb(255, 210, 90);
            label9.ForeColor = Color.FromArgb(255, 210, 90);

        }
        public manageSubsidy()
        {
            InitializeComponent();
            setUpManageSub();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            driverAccs.LoadApprovedDriversToDataGrid(dataGridView1);

            totalSubsidy = driverAccs.GetTotalApprovedDrivers();
            label3.Text = $"₱ {totalSubsidy * 5000}";
        }

        private void loadApprovedSubsidies(int adminID)
        {
            string connStr = dataBaseDetails.connStr;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT * FROM driverAccs WHERE driver_id = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", adminID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // PERSONAL
                            label10.Text = $"{reader["first_name"].ToString()} {reader["middle_name"].ToString()} {reader["last_name"].ToString()}";

                            label9.Text = reader["email"].ToString();
                        }
                    }
                }
            }
        }

        private void manageSubsidy_Load(object sender, EventArgs e)
        {
            StylePanel(panel2, 20);
            StylePanel(panel3, 20);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int driverId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["driver_id"].Value);
            loadApprovedSubsidies(driverId);
        }

        private void UpdateTotalSubsidy()
        {
            totalSubsidy = driverAccs.GetTotalApprovedDrivers();
            label3.Text = $"₱ {totalSubsidy * 5000}";
        }

        private void giveSub_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a driver first.");
                return;
            }

            string driverId = dataGridView1.SelectedRows[0].Cells["driver_id"].Value.ToString();
            string driverName = dataGridView1.SelectedRows[0].Cells["First Name"].Value.ToString()
                              + " " + dataGridView1.SelectedRows[0].Cells["Last Name"].Value.ToString();

            DialogResult confirm = MessageBox.Show(
                $"Mark subsidy as RECEIVED for:\n\n{driverName}?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            using (MySqlConnection conn = new MySqlConnection(dataBaseDetails.connStr))
            {
                conn.Open();

                string query = @"UPDATE driverAccs 
                         SET subsidy_stats = 'Received' 
                         WHERE driver_id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", driverId);
                cmd.ExecuteNonQuery();
            }
            string email = label9.Text;

            emailService.SendEmail(
                email,
                "Subsidy Received",
                $"Hello {driverName},\n\nYour subsidy has been marked as RECEIVED.\n\nThank you."
            );

            MessageBox.Show("Subsidy marked as RECEIVED!");

            // 🔥 REFRESH ONLY APPROVED LIST
            driverAccs.LoadApprovedDriversToDataGrid(dataGridView1);

            UpdateTotalSubsidy();
        }

        private DataTable SearchApprovedDrivers(string keyword)
        {
            string connStr = dataBaseDetails.connStr;
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
        SELECT 
            driver_id,
            last_name AS 'Last Name',
            first_name AS 'First Name',
            IFNULL(LEFT(middle_name, 1), '') AS 'M.I',
            email AS 'Email',
            subsidy_stats AS 'Subsidy Status'
        FROM driverAccs
        WHERE subsidy_stats = 'Approved'
          AND (
                first_name LIKE @search
             OR last_name LIKE @search
             OR CONCAT(first_name, ' ', last_name) LIKE @search
          )";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + keyword + "%");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }

        private void searchDriver_TextChanged(object sender, EventArgs e)
        {
            string keyword = searchDriver.Text.Trim();

            // placeholder check
            if (string.IsNullOrEmpty(keyword) || keyword == "Search driver...")
            {
                driverAccs.LoadApprovedDriversToDataGrid(dataGridView1);
                return;
            }

            DataTable dt = SearchApprovedDrivers(keyword);
            dataGridView1.DataSource = dt;
        }

        private void searchDriver_MouseEnter(object sender, EventArgs e)
        {
            if (searchDriver.Text == "Search driver...")
            {
                searchDriver.Text = "";
                searchDriver.ForeColor = Color.Black;
            }
        }

        private void searchDriver_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchDriver.Text))
            {
                searchDriver.Text = "Search driver...";
                searchDriver.ForeColor = Color.Gray;
            }
        }
    }
}
