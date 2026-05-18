using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PantawidPasada
{
    public partial class subsidyApp : UserControl
    {

        accessDriverInfo driverInfo = new accessDriverInfo();
        EmailService emailService = new EmailService();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
           int nLeftRect, int nTopRect,
           int nRightRect, int nBottomRect,
           int nWidthEllipse, int nHeightEllipse
       );

        public subsidyApp()
        {
            InitializeComponent();
            setUpSubsidyApp();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            driverInfo.LoadDriversToDataGrid(dataGridView1);

        }

        private void StylePanel(Panel pnl, int radius = 20)
        {

            pnl.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, pnl.Width, pnl.Height, radius, radius)
            );
        }

        private void setUpSubsidyApp()
        {
            panel1.BackColor = Color.FromArgb(255, 210, 90);
            label2.ForeColor = Color.FromArgb(30, 58, 95);
            approve.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, approve.Width, approve.Height, 20, 20));
            approve.BackColor = Color.FromArgb(244, 196, 48);
            reject.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, reject.Width, reject.Height, 20, 20));
            reject.BackColor = Color.FromArgb(244, 196, 48);
            onHold.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, onHold.Width, onHold.Height, 20, 20));
            onHold.BackColor = Color.FromArgb(244, 196, 48);
            underReview.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, underReview.Width, underReview.Height, 20, 20));
            underReview.BackColor = Color.FromArgb(244, 196, 48);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void subsidyApp_Load(object sender, EventArgs e)
        {
            StylePanel(panel2, 20);
        }

        private void LoadDriverDetails(int driverId)
        {
            string connStr = dataBaseDetails.connStr;


            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT * FROM driverAccs WHERE driver_id = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", driverId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // PERSONAL
                            label1.Text = $"{reader["first_name"].ToString()} {reader["middle_name"].ToString()} {reader["last_name"].ToString()}";

                            label6.Text = reader["address"].ToString();
                            label7.Text = reader["province"].ToString();

                            // CONTACT
                            label9.Text = reader["email"].ToString();
                            label13.Text = reader["phone_num"].ToString();



                            // FINANCIAL
                            label18.Text = reader["income"].ToString();
                            label11.Text = reader["employment_type"].ToString();
                            label8.Text = reader["source_of_income"].ToString();
                            label23.Text = reader["finan_ob"].ToString();

                            // VEHICLE
                            label27.Text = reader["lic_num"].ToString();
                            label31.Text = reader["vehicle_type"].ToString();
                            label26.Text = reader["plate_number"].ToString();

                            // STATUS
                            label25.Text = reader["subsidy_stats"].ToString();

                            if (reader["subsidy_stats"].ToString() == "Pending")
                            {
                                label25.ForeColor = Color.FromArgb(255, 193, 7);
                            }
                            else if (reader["subsidy_stats"].ToString() == "Under Review")
                            {
                                label25.ForeColor = Color.FromArgb(255, 152, 0);

                            }
                            else if (reader["subsidy_stats"].ToString() == "On Hold")
                            {
                                label25.ForeColor = Color.FromArgb(158, 158, 158);

                            }

                        }
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int driverId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["driver_id"].Value);
            LoadDriverDetails(driverId);

        }

        private void approve_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a driver first.");
                return;
            }

            string driverId = dataGridView1.SelectedRows[0].Cells["driver_id"].Value.ToString();
            string driverName = dataGridView1.SelectedRows[0].Cells["First Name"].Value.ToString()
                              + " " + dataGridView1.SelectedRows[0].Cells["Last Name"].Value.ToString();

            string email = dataGridView1.SelectedRows[0].Cells["email"].Value.ToString();

            DialogResult confirm = MessageBox.Show(
                $"Approve subsidy for:\n\n{driverName}?",
                "Confirm Approval",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            // 🔥 ASK FOR REASON
            using (InputReasonForm reasonForm = new InputReasonForm("Approval Reason"))
            {
                if (reasonForm.ShowDialog() != DialogResult.OK)
                    return;

                string reason = reasonForm.ReasonText;

                if (string.IsNullOrWhiteSpace(reason))
                {
                    MessageBox.Show("Reason is required.");
                    return;
                }

                // DB UPDATE
                using (MySqlConnection conn = new MySqlConnection(dataBaseDetails.connStr))
                {
                    conn.Open();

                    string query = @"UPDATE driverAccs 
                             SET subsidy_stats = 'Approved', reason = @reason 
                             WHERE driver_id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", driverId);
                    cmd.Parameters.AddWithValue("@reason", reason);
                    cmd.ExecuteNonQuery();
                }

                // EMAIL


                emailService.SendEmail(
                    email,
                    "Subsidy Application Approved",
                    $"Hello {driverName},\n\nYour subsidy has been APPROVED.\n\nReason: {reason}\n\nThank you."
                );

                MessageBox.Show("Approved successfully!");
                driverInfo.LoadDriversToDataGrid(dataGridView1);
            }
        }

        private void reject_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a driver first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the driver ID and name from the selected row
            string driverId = dataGridView1.SelectedRows[0].Cells["driver_id"].Value.ToString();
            string driverName = dataGridView1.SelectedRows[0].Cells["First Name"].Value.ToString()
                              + " " + dataGridView1.SelectedRows[0].Cells["Last Name"].Value.ToString();
            string email = dataGridView1.SelectedRows[0].Cells["email"].Value.ToString();
            // Confirm before rejecting
            DialogResult confirm = MessageBox.Show(
    $"Are you sure you want to reject the subsidy for:\n\n{driverName}?",
    "Confirm Rejection",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            // 🔥 ASK FOR REASON
            InputReasonForm reasonForm = new InputReasonForm("Reject Reason");
            reasonForm.ShowDialog();

            string reason = reasonForm.ReasonText;

            if (string.IsNullOrWhiteSpace(reason))
            {
                MessageBox.Show("Rejection cancelled: no reason provided.");
                return;
            }

            // Update the database
            string connStr = dataBaseDetails.connStr;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "UPDATE driverAccs SET subsidy_stats = 'Rejected', reason = @reason WHERE driver_id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", driverId);
                cmd.Parameters.AddWithValue("@reason", reason);
                cmd.ExecuteNonQuery();
            }

            emailService.SendEmail(
                    email,
                    "Subsidy Application Rejected",
                    $"Hello {driverName},\n\nYour subsidy has been REJECTED.\n\nReason: {reason}\n\nThank you."
                );

            // Success message
            MessageBox.Show(
                $"Subsidy for {driverName} has been rejected!",
                "Rejected",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Refresh the DataGridView to remove the approved driver from the list
            driverInfo.LoadDriversToDataGrid(dataGridView1);
        }

        private void onHold_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a driver first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the driver ID and name from the selected row
            string driverId = dataGridView1.SelectedRows[0].Cells["driver_id"].Value.ToString();
            string driverName = dataGridView1.SelectedRows[0].Cells["First Name"].Value.ToString()
                              + " " + dataGridView1.SelectedRows[0].Cells["Last Name"].Value.ToString();
            string email = dataGridView1.SelectedRows[0].Cells["email"].Value.ToString();
            // Confirm before On Hold
            DialogResult confirm = MessageBox.Show(
    $"Are you sure you want to put on hold the subsidy for:\n\n{driverName}?",
    "Confirm On Hold",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            // 🔥 ASK FOR REASON
            InputReasonForm reasonForm = new InputReasonForm("On Hold Reason");
            reasonForm.ShowDialog();

            string reason = reasonForm.ReasonText;

            if (string.IsNullOrWhiteSpace(reason))
            {
                MessageBox.Show("On Hold cancelled: no reason provided.");
                return;
            }

            // Update the database
            string connStr = dataBaseDetails.connStr;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "UPDATE driverAccs SET subsidy_stats = 'On Hold', reason = @reason WHERE driver_id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", driverId);
                cmd.Parameters.AddWithValue("@reason", reason);
                cmd.ExecuteNonQuery();
            }

            emailService.SendEmail(
                    email,
                    "Subsidy Application put On Hold",
                    $"Hello {driverName},\n\nYour subsidy has been ON HOLD.\n\nReason: {reason}\n\nThank you."
                );

            // Success message
            MessageBox.Show(
                $"Subsidy for {driverName} has been put On Hold!",
                "On Hold",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Refresh the DataGridView to remove the approved driver from the list
            driverInfo.LoadDriversToDataGrid(dataGridView1);
        }

        private void underReview_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a driver first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the driver ID and name from the selected row
            string driverId = dataGridView1.SelectedRows[0].Cells["driver_id"].Value.ToString();
            string driverName = dataGridView1.SelectedRows[0].Cells["First Name"].Value.ToString()
                              + " " + dataGridView1.SelectedRows[0].Cells["Last Name"].Value.ToString();
            string email = dataGridView1.SelectedRows[0].Cells["email"].Value.ToString();
            // Confirm before Under Review
            DialogResult confirm = MessageBox.Show(
    $"Are you sure you want to put Under Review the subsidy for:\n\n{driverName}?",
    "Confirm Under Review",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            // 🔥 ASK FOR REASON
            InputReasonForm reasonForm = new InputReasonForm("Under Review Reason");
            reasonForm.ShowDialog();

            string reason = reasonForm.ReasonText;

            if (string.IsNullOrWhiteSpace(reason))
            {
                MessageBox.Show("Under Review cancelled: no reason provided.");
                return;
            }

            // Update the database
            string connStr = dataBaseDetails.connStr;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "UPDATE driverAccs SET subsidy_stats = 'Under Review', reason = @reason WHERE driver_id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", driverId);
                cmd.Parameters.AddWithValue("@reason", reason);
                cmd.ExecuteNonQuery();
            }

            emailService.SendEmail(
                    email,
                    "Subsidy Application put Under Review",
                    $"Hello {driverName},\n\nYour subsidy has been UNDER REVIEW.\n\nReason: {reason}\n\nThank you."
                );

            // Success message
            MessageBox.Show(
                $"Subsidy for {driverName} has been put Under Review!",
                "Under Review",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Refresh the DataGridView to remove the approved driver from the list
            driverInfo.LoadDriversToDataGrid(dataGridView1);
        }

        private DataTable SearchDrivers(string keyword)
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
        WHERE subsidy_stats IN ('Pending','Under Review','On Hold')
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

            if (string.IsNullOrEmpty(keyword) || keyword == "Search driver...")
            {
                driverInfo.LoadDriversToDataGrid(dataGridView1);
                return;
            }

            dataGridView1.DataSource = SearchDrivers(keyword);
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
