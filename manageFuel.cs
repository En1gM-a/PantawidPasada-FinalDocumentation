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
    public partial class manageFuel : UserControl
    {

        fuelPricewithStation fuelData = new fuelPricewithStation();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );



        public manageFuel()
        {
            InitializeComponent();
            setUpManageFuel();
        }

        private void StylePanel(Panel pnl, int radius = 20)
        {

            pnl.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, pnl.Width, pnl.Height, radius, radius)
            );
        }

        private void setUpManageFuel()
        {
            panel1.BackColor = Color.FromArgb(255, 210, 90);
            label2.ForeColor = Color.FromArgb(30, 58, 95);

            savePrice.BackColor = Color.FromArgb(244, 196, 48);
            savePrice.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, savePrice.Width, savePrice.Height, 20, 20)
            );
        }

        private void manageFuel_Load(object sender, EventArgs e)
        {
            StylePanel(panel2, 20);
            StylePanel(panel3, 20);
            StylePanel(panel4, 20);
            StylePanel(panel5, 20);

        }

        private void savePrice_Click(object sender, EventArgs e)
        {
            // Confirmation dialog showing all prices
            DialogResult confirm = MessageBox.Show(
                $"Please confirm the following fuel prices:\n\n" +
                $"Shell ({comboBox1.Text})\n" +
                $"  Diesel: ₱{textBox1.Text}  |  Unleaded: ₱{textBox2.Text}  |  Premium: ₱{textBox3.Text}\n\n" +
                $"Petron ({comboBox3.Text})\n" +
                $"  Diesel: ₱{textBox9.Text}  |  Unleaded: ₱{textBox8.Text}  |  Premium: ₱{textBox7.Text}\n\n" +
                $"Caltex ({comboBox2.Text})\n" +
                $"  Diesel: ₱{textBox6.Text}  |  Unleaded: ₱{textBox5.Text}  |  Premium: ₱{textBox4.Text}\n\n" +
                $"SeaOil ({comboBox4.Text})\n" +
                $"  Diesel: ₱{textBox12.Text}  |  Unleaded: ₱{textBox11.Text}  |  Premium: ₱{textBox10.Text}\n\n" +
                $"Are all prices correct?",
                "Confirm Fuel Prices",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return; // stop here if No

            string stationName = "Shell";
            string area = comboBox1.Text;
            double dieselPrice = double.TryParse(textBox1.Text, out double diesel) ? diesel : 0;
            double unleadedPrice = double.TryParse(textBox2.Text, out double unleaded) ? unleaded : 0;
            double premiumUnleadedPrice = double.TryParse(textBox3.Text, out double premium) ? premium : 0;
            DateTime dateNow = dateTimePicker1.Value;

            fuelData.AddFuelPriceData(stationName, area, dieselPrice, unleadedPrice, premiumUnleadedPrice, dateNow);

            stationName = "Petron";
            area = comboBox3.Text;
            dieselPrice = double.TryParse(textBox9.Text, out diesel) ? diesel : 0;
            unleadedPrice = double.TryParse(textBox8.Text, out unleaded) ? unleaded : 0;
            premiumUnleadedPrice = double.TryParse(textBox7.Text, out premium) ? premium : 0;
            dateNow = dateTimePicker1.Value;

            fuelData.AddFuelPriceData(stationName, area, dieselPrice, unleadedPrice, premiumUnleadedPrice, dateNow);

            stationName = "Caltex";
            area = comboBox2.Text;
            dieselPrice = double.TryParse(textBox6.Text, out diesel) ? diesel : 0;
            unleadedPrice = double.TryParse(textBox5.Text, out unleaded) ? unleaded : 0;
            premiumUnleadedPrice = double.TryParse(textBox4.Text, out premium) ? premium : 0;
            dateNow = dateTimePicker1.Value;

            fuelData.AddFuelPriceData(stationName, area, dieselPrice, unleadedPrice, premiumUnleadedPrice, dateNow);

            stationName = "SeaOil";
            area = comboBox4.Text;
            dieselPrice = double.TryParse(textBox12.Text, out diesel) ? diesel : 0;
            unleadedPrice = double.TryParse(textBox11.Text, out unleaded) ? unleaded : 0;
            premiumUnleadedPrice = double.TryParse(textBox10.Text, out premium) ? premium : 0;
            dateNow = dateTimePicker1.Value;

            fuelData.AddFuelPriceData(stationName, area, dieselPrice, unleadedPrice, premiumUnleadedPrice, dateNow);

            MessageBox.Show("Fuel prices saved successfully!", "Prices Updated",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
