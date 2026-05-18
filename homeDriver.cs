using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace PantawidPasada
{
    public partial class homeDriver : UserControl
    {
        private UserData userData;
        fuelPriceData fuelPrice = new fuelPriceData();
        private bool isClicked = false;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );

        public homeDriver()
        {
            InitializeComponent();
        }
        public homeDriver(UserData data)
        {
            InitializeComponent();
            userData = data;
            setUpHome();
            _ = LoadFuelPricesAsync();
            button1.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 20, 20));
            button1.BackColor = Color.FromArgb(244, 196, 48);

            if (data.subsidyStatus != "Not Requested")
            {
                button1.Enabled = false;
                button1.Visible = false;
            }


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



        private async Task LoadFuelPricesAsync()
        {
            try
            {
                // 1. Get all prices from the online source
                List<fuelPriceData> allPrices = await fuelPriceONLINE.GetPricesAsync();

                // 2. Sort by date descending
                allPrices.Sort((a, b) => b.Date.CompareTo(a.Date));

                // 3. Take the most recent and second most recent
                var mostRecent = allPrices.Count > 0 ? allPrices[0] : null;
                var secondMostRecent = allPrices.Count > 2 ? allPrices[2] : null;
                double ringgitToPeso = 14.92; // 1 MYR = 14.92 PHP

                // 4. Update labels safely on UI thread
                this.Invoke((MethodInvoker)(() =>
                {

                    if (mostRecent != null)
                    {
                        label11.Text = mostRecent.Date.ToString("MMMM dd ,yyyy dddd");
                        label40.Text = mostRecent.Date.ToString("MMMM dd ,yyyy dddd");
                        label17.Text = $"₱{(mostRecent.RON95PriceOnline * ringgitToPeso).ToString("N2")}";
                        label18.Text = $"₱{(mostRecent.RON97PriceOnline * ringgitToPeso).ToString("N2")}";
                        label19.Text = $"₱{(mostRecent.dieselPriceOnline * ringgitToPeso).ToString("N2")}";
                        label33.Text = $"₱{(mostRecent.dieselPriceOnline * ringgitToPeso).ToString("N2")}";
                        label38.Text = $"₱{fuelPrice.fareCalculation(mostRecent.dieselPriceOnline * ringgitToPeso, 0.1).ToString("N2")}";
                        label39.Text = $"₱{fuelPrice.discountedFare(fuelPrice.fareCalculation(mostRecent.dieselPriceOnline * ringgitToPeso, 0.1), 20).ToString("N2")}";

                        double currentRON95 = mostRecent.RON95PriceOnline * ringgitToPeso;
                        double previousRON95 = secondMostRecent.RON95PriceOnline * ringgitToPeso;

                        double currentRON97 = mostRecent.RON97PriceOnline * ringgitToPeso;
                        double previousRON97 = secondMostRecent.RON97PriceOnline * ringgitToPeso;

                        double currentDiesel = mostRecent.dieselPriceOnline * ringgitToPeso;
                        double previousDiesel = secondMostRecent.dieselPriceOnline * ringgitToPeso;

                        label23.Text = $"Compared to {secondMostRecent.Date:MM/dd/yy}";



                        UpdateFuelUI(label29, label42, currentRON95, previousRON95);
                        UpdateFuelUI(label30, label43, currentRON97, previousRON97);
                        UpdateFuelUI(label31, label44, currentDiesel, previousDiesel);


                    }
                    else
                    {
                        label11.Text = "N/A";
                        label17.Text = "N/A";
                        label18.Text = "N/A";
                        label19.Text = "N/A";
                    }


                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading fuel prices: " + ex.Message);
            }
        }

        private void UpdateFuelUI(Label priceLabel, Label changeLabel, double current, double previous)
        {
            double diff = current - previous;

            // Show previous price
            priceLabel.Text = $"₱{previous:N2}";

            // Determine color (based on comparison)
            if (current > previous)
                priceLabel.ForeColor = Color.FromArgb(244, 67, 54); // red
            else if (current < previous)
                priceLabel.ForeColor = Color.FromArgb(76, 175, 80); // green
            else
                priceLabel.ForeColor = Color.FromArgb(158, 158, 158); // gray

            // Compute difference





            if (diff > 0)
            {
                changeLabel.ForeColor = Color.FromArgb(244, 67, 54);
                changeLabel.Text = $"⇧₱{diff:N2} increase";
            }
            else if (diff < 0)
            {
                changeLabel.ForeColor = Color.FromArgb(76, 175, 80);
                changeLabel.Text = $"⇩₱{Math.Abs(diff):N2} decrease";
            }
            else
            {
                changeLabel.ForeColor = Color.FromArgb(158, 158, 158);
                changeLabel.Text = "No change";
            }
        }

        private void setUpHome()
        {
            panel1.BackColor = Color.FromArgb(255, 210, 90);//warm yelloe
            panel12.BackColor = Color.FromArgb(255, 210, 90);//warm yellow
            label41.ForeColor = Color.FromArgb(255, 210, 90);//warm yellow
            label45.ForeColor = Color.FromArgb(30, 58, 95);
            label1.ForeColor = Color.FromArgb(30, 58, 95);//dark blue
            label4.ForeColor = Color.FromArgb(30, 58, 95);//dark blue
            label2.ForeColor = Color.FromArgb(30, 58, 95);
            label3.ForeColor = Color.FromArgb(30, 58, 95);
            label9.ForeColor = Color.FromArgb(30, 58, 95);
            panel5.BackColor = Color.FromArgb(30, 58, 95);//dark blue
            panel9.BackColor = Color.FromArgb(30, 58, 95);
            label34.ForeColor = Color.FromArgb(220, 170, 30);
            label35.ForeColor = Color.FromArgb(220, 170, 30);
            label32.ForeColor = Color.FromArgb(220, 170, 30);
            label33.ForeColor = Color.FromArgb(220, 170, 30);
            label10.ForeColor = Color.FromArgb(30, 58, 95);
            label11.ForeColor = Color.FromArgb(30, 58, 95);
            label12.ForeColor = Color.FromArgb(30, 58, 95);
            label15.ForeColor = Color.FromArgb(30, 58, 95);
            label16.ForeColor = Color.FromArgb(30, 58, 95);
            label17.ForeColor = Color.FromArgb(30, 58, 95);
            label18.ForeColor = Color.FromArgb(30, 58, 95);
            label19.ForeColor = Color.FromArgb(30, 58, 95);
            label20.ForeColor = Color.FromArgb(220, 170, 30);
            label21.ForeColor = Color.FromArgb(220, 170, 30);
            label22.ForeColor = Color.FromArgb(220, 170, 30);
            label23.ForeColor = Color.FromArgb(220, 170, 30);

            label36.BackColor = Color.LightBlue;
            label37.BackColor = Color.LightGreen;
            label36.ForeColor = Color.DarkBlue;
            label37.ForeColor = Color.DarkGreen;

            label2.Text = $"{userData.FirstName} {userData.LastName}";
            label3.Text = $"License ID: {userData.LicenseNumber} | {userData.Province}";
            label4.Text = $"{userData.FirstName} {userData.MiddleName} {userData.LastName}";
            label5.Text = $"Plate number: {userData.PlateNumber} | {userData.VehicleType}";
            label7.Text = $"{userData.Phone} | {userData.Email}";
            label45.Text = userData.reason;
            if (userData.subsidyStatus == "Approved" || userData.subsidyStatus == "Received")
                label8.ForeColor = Color.FromArgb(76, 175, 80); // green
            else if (userData.subsidyStatus == "Rejected")
                label8.ForeColor = Color.FromArgb(244, 67, 54); // red
            else if (userData.subsidyStatus == "Pending")
                label8.ForeColor = Color.FromArgb(255, 193, 7);
            else if (userData.subsidyStatus == "Under Review")
                label8.ForeColor = Color.FromArgb(255, 152, 0); // orange
            else if (userData.subsidyStatus == "On Hold")
                label8.ForeColor = Color.FromArgb(158, 158, 158); // gray

            label8.Text = $"{userData.subsidyStatus}";
        }

        private void homeDriver_Load(object sender, EventArgs e)
        {
            StylePanel(panel2, 20);
            StylePanel(panel3, 20);
            StylePanel(panel4, 20);
            StyleLabel(label36, 20);
            StyleLabel(label37, 20);
            StylePanel(panel12, 20);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            requestSubsidy form = new requestSubsidy(userData);
            if (form.ShowDialog() == DialogResult.OK)
            {
                button1.Enabled = false;
                button1.Visible = false;
                label8.Text = "Pending";
                label8.ForeColor = Color.FromArgb(255, 193, 7);
            }
        }

        private void label8_MouseClick_1(object sender, MouseEventArgs e)
        {
            isClicked = !isClicked; // toggle true/false

            panel12.Visible = isClicked;
            panel12.Enabled = isClicked;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
