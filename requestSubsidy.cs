using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PantawidPasada
{
    public partial class requestSubsidy : Form
    {
        private financialInfo financialControl;
        private UserData userData;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );

        public requestSubsidy(UserData data)
        {
            InitializeComponent();
            userData = data; // store it
            this.BackColor = Color.FromArgb(30, 58, 95);

            button1.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 20, 20));
            button1.BackColor = Color.FromArgb(244, 196, 48);

            financialControl = new financialInfo(data); // assign to field
            financialControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(financialControl); // into panel, not form
        }

        private void button1_Click(object sender, EventArgs e)
        {
            financialControl.FillData(userData); // use field, not null financialInfoControl

            try
            {
                using (MySqlConnection conn = new MySqlConnection(dataBaseDetails.connStr))
                {
                    conn.Open();

                    string query = @"UPDATE driverAccs 
                                     SET income = @income,
                                         employment_type = @employment,
                                         source_of_income = @source,
                                         finan_ob = @obligation,
                                         subsidy_stats = 'Pending'
                                     WHERE usernameUser = @username";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@income", userData.Income);
                    cmd.Parameters.AddWithValue("@employment", userData.EmploymentType);
                    cmd.Parameters.AddWithValue("@source", userData.SourceOfIncome);
                    cmd.Parameters.AddWithValue("@obligation", userData.FinancialObligation);
                    cmd.Parameters.AddWithValue("@username", userData.username);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Request submitted successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}