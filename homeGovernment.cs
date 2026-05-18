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
    public partial class homeGovernment : UserControl
    {

        private govData dataGov;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
           int nLeftRect, int nTopRect,
           int nRightRect, int nBottomRect,
           int nWidthEllipse, int nHeightEllipse
       );

        public homeGovernment()
        {
            InitializeComponent();
        }

        public homeGovernment(govData data)
        {
            InitializeComponent();
            dataGov = data;
            setUpHome();
            
        }

        private void StylePanel(Panel pnl, int radius = 20)
        {
            pnl.BackColor = Color.FromArgb(248, 250, 252); // same as textbox
            pnl.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, pnl.Width, pnl.Height, radius, radius)
            );
        }

        private void setUpHome()
        {
            panel1.BackColor = Color.FromArgb(255, 210, 90);
            label1.ForeColor = Color.FromArgb(30, 58, 95);
            label2.ForeColor = Color.FromArgb(30, 58, 95);
            label3.ForeColor = Color.FromArgb(30, 58, 95);
            label5.ForeColor = Color.FromArgb(30, 58, 95);

            label3.Text = $"{dataGov.firstName} {dataGov.middleInit} {dataGov.lastName}";
            label4.Text = $"{dataGov.username}";
            label5.Text = $"{dataGov.agency}";

        }

        private void loadDataDriverPending()
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
                    int pending = Convert.ToInt32(reader["PendingDrivers"]);
                    

                    // 👉 Assign to labels (CHANGE these to your actual labels)
                    label16.Text = pending.ToString();
                    
                }
            }
        }

        private void loadDataDriverApproved()
        {
            string connStr = dataBaseDetails.connStr;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
            SELECT 
                COUNT(*) AS TotalDrivers,
                SUM(CASE WHEN subsidy_stats = 'Approved' THEN 1 ELSE 0 END) AS ApprovedDrivers
            FROM driverAccs";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int approved = Convert.ToInt32(reader["ApprovedDrivers"]);


                    // 👉 Assign to labels (CHANGE these to your actual labels)
                    label10.Text = approved.ToString();
                    
                }
            }
        }

        private void loadDataDriverOnHold()
        {
            string connStr = dataBaseDetails.connStr;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
            SELECT 
                COUNT(*) AS TotalDrivers,
                SUM(CASE WHEN subsidy_stats = 'On Hold' THEN 1 ELSE 0 END) AS OnHoldDrivers
            FROM driverAccs";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int onHold = Convert.ToInt32(reader["OnHoldDrivers"]);


                    // 👉 Assign to labels (CHANGE these to your actual labels)
                    label13.Text = onHold.ToString();

                }
            }
        }

        private void loadDataDriverUnderReview()
        {
            string connStr = dataBaseDetails.connStr;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
            SELECT 
                COUNT(*) AS TotalDrivers,
                SUM(CASE WHEN subsidy_stats = 'Under Review' THEN 1 ELSE 0 END) AS UnderReviewDrivers
            FROM driverAccs";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int underReview = Convert.ToInt32(reader["UnderReviewDrivers"]);


                    // 👉 Assign to labels (CHANGE these to your actual labels)
                    label7.Text = underReview.ToString();

                }
            }
        }

        private void homeGovernment_Load(object sender, EventArgs e)
        {
            StylePanel(panel5, 20);
            StylePanel(panel3, 20);
            StylePanel(panel4, 20);
            StylePanel(panel2, 20);
            loadDataDriverPending();
            loadDataDriverApproved();
            loadDataDriverOnHold();
            loadDataDriverUnderReview();    
        }
    }
}
