using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;



namespace PantawidPasada
{
    public partial class fuelPrice : UserControl
    {
        fuelPricewithStation fuelData = new fuelPricewithStation();
        forGraph graphData = new forGraph();
        private System.Windows.Forms.Timer hideGraphTimer;

        

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );

        public fuelPrice()
        {
            InitializeComponent();
            setFuelPrice();
            panel9.BackColor = Color.WhiteSmoke;

            hideGraphTimer = new System.Windows.Forms.Timer();
            hideGraphTimer.Interval = 300;
            hideGraphTimer.Tick += HideGraphTimer_Tick;
        }

        // =========================
        // STYLE HELPERS
        // =========================
        private void StylePanel(Panel pnl, int radius = 20)
        {
            pnl.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, pnl.Width, pnl.Height, radius, radius)
            );
        }

        private void setFuelPrice()
        {
            panel4.BackColor = Color.FromArgb(30, 58, 95);
            label7.ForeColor = Color.FromArgb(255, 210, 90);
            label8.ForeColor = Color.FromArgb(255, 210, 90);
            label9.ForeColor = Color.FromArgb(255, 210, 90);
            label10.ForeColor = Color.FromArgb(255, 210, 90);
            label12.ForeColor = Color.FromArgb(255, 210, 90);
            panel1.BackColor = Color.FromArgb(255, 210, 90);
            label1.ForeColor = Color.FromArgb(30, 58, 95);
            label2.ForeColor = Color.FromArgb(30, 58, 95);
            label3.ForeColor = Color.FromArgb(30, 58, 95);
        }

        private void fuelPrice_Load(object sender, EventArgs e)
        {
            StylePanel(panel2, 20);
            StylePanel(panel3, 20);
            StylePanel(panel9, 20);
            setFuelPrice();
            LoadMostRecentPrices();

            
        }

        // =========================
        // UPDATE STATION UI
        // =========================
        private void UpdateStationUI(string station, string area, string diesel,
            string unleaded, string premium,
            double dieselChange, double unleadedChange, double premiumChange)
        {
            switch (station)
            {
                case "Petron":
                    label18.Text = area;
                    label25.Text = diesel;
                    label33.Text = unleaded;
                    label41.Text = premium;
                    SetChangeLabel(label24, dieselChange);
                    SetChangeLabel(label32, unleadedChange);
                    SetChangeLabel(label40, premiumChange);
                    break;

                case "Shell":
                    label16.Text = area;
                    label20.Text = diesel;
                    label29.Text = unleaded;
                    label37.Text = premium;
                    SetChangeLabel(label21, dieselChange);
                    SetChangeLabel(label28, unleadedChange);
                    SetChangeLabel(label36, premiumChange);
                    break;

                case "Caltex":
                    label17.Text = area;
                    label22.Text = diesel;
                    label31.Text = unleaded;
                    label39.Text = premium;
                    SetChangeLabel(label23, dieselChange);
                    SetChangeLabel(label30, unleadedChange);
                    SetChangeLabel(label38, premiumChange);
                    break;

                case "SeaOil":
                    label19.Text = area;
                    label26.Text = diesel;
                    label35.Text = unleaded;
                    label43.Text = premium;
                    SetChangeLabel(label27, dieselChange);
                    SetChangeLabel(label34, unleadedChange);
                    SetChangeLabel(label42, premiumChange);
                    break;
            }
        }

        // =========================
        // LOAD MOST RECENT PRICES
        // =========================

        private void LoadMostRecentPrices()
        {
            try
            {
                var list = fuelData.LoadMostRecent();

                if (list.Count == 0)
                {
                    label3.Text = "No fuel price data available.";
                    return;
                }

                // Show the date of the most recent entry
                var latestDate = list.Max(x => x.DateOfPrice);
                label3.Text = "Fuel Prices as of " + latestDate.ToString("MMMM dd, yyyy");

                foreach (var item in list)
                {
                    UpdateStationUI(
                        item.StationName,
                        item.Area,
                        "₱" + item.dieselPrice.ToString("N2"),
                        "₱" + item.unleadedPrice.ToString("N2"),
                        "₱" + item.premUnleadedPrice.ToString("N2"),
                        fuelData.GetDieselChange(item.StationName),
                        fuelData.GetUnleadedChange(item.StationName),
                        fuelData.GetPremiumChange(item.StationName)
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading fuel prices: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HideGraphTimer_Tick(object sender, EventArgs e)
        {
            Point cursor = panel9.PointToClient(Cursor.Position);

            if (!panel9.ClientRectangle.Contains(cursor))
            {
                panel9.Visible = false;
                hideGraphTimer.Stop();
            }
        }

        // =========================
        // SET CHANGE LABEL
        // =========================
        private void SetChangeLabel(Label lbl, double change)
        {
            lbl.Text = fuelData.FormatChange(change);

            if (change > 0)
                lbl.ForeColor = Color.FromArgb(198, 40, 40);  // red — price went up
            else if (change < 0)
                lbl.ForeColor = Color.FromArgb(46, 125, 50);  // green — price went down
            else
                lbl.ForeColor = Color.Gray;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            graphData.SetupPriceChart(cartesianChart1, "Shell");

            panel9.BringToFront();
            cartesianChart1.BringToFront();
            cartesianChart1.Dock = DockStyle.Fill;
            panel9.Visible = true;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            hideGraphTimer.Start();
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            graphData.SetupPriceChart(cartesianChart1, "Caltex");

            panel9.BringToFront();
            cartesianChart1.BringToFront();
            cartesianChart1.Dock = DockStyle.Fill;
            panel9.Visible = true;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            hideGraphTimer.Start();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            graphData.SetupPriceChart(cartesianChart1, "Petron");

            panel9.BringToFront();
            cartesianChart1.BringToFront();
            cartesianChart1.Dock = DockStyle.Fill;
            panel9.Visible = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            hideGraphTimer.Start();
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            graphData.SetupPriceChart(cartesianChart1, "SeaOil");

            panel9.BringToFront();
            cartesianChart1.BringToFront();
            cartesianChart1.Dock = DockStyle.Fill;
            panel9.Visible = true;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            hideGraphTimer.Start();
        }
    }
}