using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PantawidPasada
{
    public partial class dashboardPetron : UserControl
    {
        fuelPriceData fuelPrice = new fuelPriceData();
        fuelPricewithStation fuelData = new fuelPricewithStation();
        private fuelEditorData user;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );

        public dashboardPetron(fuelEditorData data)
        {
            InitializeComponent();
            user = data ?? throw new ArgumentNullException(nameof(data));
            setupPetron();
            
            _ = LoadFuelPricesAsync();
            savePrice.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, savePrice.Width, savePrice.Height, 20, 20));
            savePrice.BackColor = Color.FromArgb(244, 196, 48);
        }
        

        private void StylePanel(Panel pnl, int radius = 20)
        {
            pnl.BackColor = Color.FromArgb(248, 250, 252); // same as textbox
            pnl.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, pnl.Width, pnl.Height, radius, radius)
            );
        }

        private void setupPetron()
        {
            if (user?.username?.Contains("petron") == true)
            {
                label8.Text = "Petron";
                pictureBox3.Image = Properties.Resources.petronLogo;
            }
            else if (user.username.Contains("shell"))
            {
                label8.Text = "Shell";
                pictureBox3.Image = Properties.Resources.shellLogo;
            }
            else if (user.username.Contains("caltex"))
            {
                label8.Text = "Caltex";
                pictureBox3.Image = Properties.Resources.caltexLogo;
            }
            else if (user.username.Contains("seaoil"))
            {
                label8.Text = "SeaOil";
                pictureBox3.Image = Properties.Resources.seaOil;
            }
            else
            {
                label2.Text = "Unknown";
            }

            panel1.BackColor = Color.FromArgb(255, 210, 90);//warm yelloe
            label1.ForeColor = Color.FromArgb(30, 58, 95);//dark blue
            label2.ForeColor = Color.FromArgb(30, 58, 95);
            label9.ForeColor = Color.FromArgb(30, 58, 95);
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

                        label17.Text = $"₱{(mostRecent.RON95PriceOnline * ringgitToPeso).ToString("N2")}";
                        label18.Text = $"₱{(mostRecent.RON97PriceOnline * ringgitToPeso).ToString("N2")}";
                        label19.Text = $"₱{(mostRecent.dieselPriceOnline * ringgitToPeso).ToString("N2")}";


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


        private void dashboardPetron_Load(object sender, EventArgs e)
        {
            StylePanel(panel3, 20);
        }

        private void savePrice_Click(object sender, EventArgs e)
        {
            // Confirmation dialog showing all prices
            DialogResult confirm = MessageBox.Show(
                $"Please confirm the following fuel prices:\n\n" +
                $"{user.name} ({comboBox3.Text})\n" +
                $"  Diesel: ₱{textBox9.Text}  |  Unleaded: ₱{textBox8.Text}  |  Premium: ₱{textBox7.Text}\n\n" +
                
                $"Are all prices correct?",
                "Confirm Fuel Prices",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return; // stop here if No

            string stationName = user.name;
            string area = comboBox3.Text;
            double dieselPrice = double.TryParse(textBox9.Text, out double diesel) ? diesel : 0;
            double unleadedPrice = double.TryParse(textBox8.Text, out double unleaded) ? unleaded : 0;
            double premiumUnleadedPrice = double.TryParse(textBox7.Text, out double premium) ? premium : 0;
            DateTime dateNow = dateTimePicker1.Value;

            fuelData.AddFuelPriceData(stationName, area, dieselPrice, unleadedPrice, premiumUnleadedPrice, dateNow);

            

            MessageBox.Show("Fuel prices saved successfully!", "Prices Updated",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
