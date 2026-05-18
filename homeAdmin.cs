using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PantawidPasada
{
    public partial class homeAdmin : UserControl
    {

        private adminAcc accAdmin;
        string totalNumDrivers;
        string totalNumAdmins;
        string totalPending;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
           int nLeftRect, int nTopRect,
           int nRightRect, int nBottomRect,
           int nWidthEllipse, int nHeightEllipse
       );



        public homeAdmin()
        {
            InitializeComponent();
        }

        public homeAdmin(adminAcc admin)
        {
            InitializeComponent();
            accAdmin = admin;
            setUpHome();

        }

        private void StylePanel(Panel pnl, int radius = 20)
        {

            pnl.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, pnl.Width, pnl.Height, radius, radius)
            );
        }

        private void StyleLabel(Label lbl, int radius = 20)
        {
            // background color

            lbl.TextAlign = ContentAlignment.MiddleCenter; // optional, center text
            lbl.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, lbl.Width, lbl.Height, radius, radius)
            );
        }

        private void loadDataDriver()
        {
            string connStr = dataBaseDetails.connStr;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
            SELECT 
                COUNT(*) AS TotalDrivers,
                SUM(CASE WHEN subsidy_stats = 'Pending' THEN 1 ELSE 0 END) AS PendingDrivers
            FROM driverAccs";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int totalDrivers = Convert.ToInt32(reader["TotalDrivers"]);
                    int pendingDrivers = Convert.ToInt32(reader["PendingDrivers"]);

                    // 👉 Assign to labels (CHANGE these to your actual labels)
                    label7.Text = totalDrivers.ToString();
                    label16.Text = pendingDrivers.ToString();
                }
            }
        }

        private void loadDataAdmins()
        {
            string connStr = dataBaseDetails.connStr;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
SELECT 
    COUNT(*) AS TotalAdmins
FROM admins
WHERE adminStatus = 'Active'";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int totalAdmin = Convert.ToInt32(reader["TotalAdmins"]);
                    

                    // 👉 Assign to labels (CHANGE these to your actual labels)
                    label10.Text = totalAdmin.ToString();
                    
                }
            }
        }

        private void loadDataGov()
        {
            string connStr = dataBaseDetails.connStr;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
SELECT 
    COUNT(*) AS TotalGov
FROM govAccs
WHERE govStatus = 'Active'";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int totalAdmin = Convert.ToInt32(reader["TotalGov"]);


                    // 👉 Assign to labels (CHANGE these to your actual labels)
                    label13.Text = totalAdmin.ToString();

                }
            }
        }

        private void setUpHome()
        {
            panel1.BackColor = Color.FromArgb(255, 210, 90);
            label5.BackColor = Color.FromArgb(30, 58, 95);
            label2.ForeColor = Color.FromArgb(30, 58, 95);
            label1.ForeColor = Color.FromArgb(30, 58, 95);
            label3.ForeColor = Color.FromArgb(30, 58, 95);
            label7.ForeColor = Color.FromArgb(30, 58, 95);
            label10.ForeColor = Color.FromArgb(30, 58, 95);
            label13.ForeColor = Color.FromArgb(30, 58, 95);

            label3.Text = $"{accAdmin.FirstName} {accAdmin.MiddleInit} {accAdmin.LastName}";
            label4.Text = $"{accAdmin.username}";
            label5.Text = $"{accAdmin.role}";


        }

        private void homeAdmin_Load(object sender, EventArgs e)
        {
            StylePanel(panel2, 20);
            StylePanel(panel3, 20);
            StylePanel(panel4, 20);
            StylePanel(panel5, 20);
            
            StyleLabel(label5, 10);
            loadDataAdmins();
            loadDataDriver();
            loadDataGov();
        }
    }
}
