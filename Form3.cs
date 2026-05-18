using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PantawidPasada
{
    public partial class Form3 : Form
    {
        SlantedButton slantedButton = new SlantedButton();

        private UserData userData;
        private Button activeButton;
        public Form3(UserData data)
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(30, 58, 95);
            slantedButton.MakeSlanted(homeButtonDriver);
            slantedButton.MakeSlanted(fuelPriceDriver);
            slantedButton.MakeSlanted(jeepFareDriver);
            slantedButton.MakeSlanted(accountDriver);
            slantedButton.MakeSlanted(logoutButton);

            userData = data;

            homeDriver home = new homeDriver(userData);
            panel2.Controls.Clear();
            panel2.Controls.Add(home);


        }

        private void SetActiveButton(Button clickedButton)
        {
            // Reset all buttons to default color
            Button[] buttons = { homeButtonDriver, fuelPriceDriver, jeepFareDriver, accountDriver };
            foreach (var btn in buttons)
                btn.BackColor = Color.FromArgb(30, 58, 95); // default dark blue

            // Highlight the clicked button
            clickedButton.BackColor = Color.FromArgb(255, 230, 128); // yellow
            activeButton = clickedButton;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SetActiveButton(homeButtonDriver);
        }
        private void homeButtonDriver_Click(object sender, EventArgs e)
        {
            SetActiveButton(homeButtonDriver);
            homeDriver home = new homeDriver(userData);
            panel2.Controls.Clear();
            panel2.Controls.Add(home);

        }

        private void fuelPriceDriver_Click(object sender, EventArgs e)
        {
            SetActiveButton(fuelPriceDriver);
            fuelPrice fuelPrice = new fuelPrice();
            panel2.Controls.Clear();
            panel2.Controls.Add(fuelPrice);
        }

        private void jeepFareDriver_Click(object sender, EventArgs e)
        {
            SetActiveButton(jeepFareDriver);
            fareMatrix fareMatrix = new fareMatrix();
            panel2.Controls.Clear();
            panel2.Controls.Add(fareMatrix);
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }
        private void homeButtonDriver_MouseHover(object sender, EventArgs e)
        {
            if (activeButton != homeButtonDriver)
                homeButtonDriver.BackColor = Color.FromArgb(255, 210, 90); // hover yellow
        }

        private void homeButtonDriver_MouseLeave(object sender, EventArgs e)
        {
            if (activeButton != homeButtonDriver)
                homeButtonDriver.BackColor = Color.FromArgb(30, 58, 95); // reset to default
        }

        private void fuelPriceDriver_MouseHover(object sender, EventArgs e)
        {
            if (activeButton != fuelPriceDriver)
                fuelPriceDriver.BackColor = Color.FromArgb(220, 170, 30); // darker yellow
        }

        private void fuelPriceDriver_MouseLeave(object sender, EventArgs e)
        {
            if (activeButton != fuelPriceDriver)
                fuelPriceDriver.BackColor = Color.FromArgb(30, 58, 95);
        }

        private void jeepFareDriver_MouseHover(object sender, EventArgs e)
        {
            if (activeButton != jeepFareDriver)
                jeepFareDriver.BackColor = Color.FromArgb(220, 170, 30);
        }

        private void jeepFareDriver_MouseLeave(object sender, EventArgs e)
        {
            if (activeButton != jeepFareDriver)
                jeepFareDriver.BackColor = Color.FromArgb(30, 58, 95);
        }

        private void accountDriver_MouseHover(object sender, EventArgs e)
        {
            if (activeButton != accountDriver)
                accountDriver.BackColor = Color.FromArgb(220, 170, 30);
        }

        private void accountDriver_MouseLeave(object sender, EventArgs e)
        {
            if (activeButton != accountDriver)
                accountDriver.BackColor = Color.FromArgb(30, 58, 95);
        }

        private void logoutButton_MouseHover(object sender, EventArgs e)
        {
            logoutButton.BackColor = Color.FromArgb(220, 170, 30);
        }

        private void logoutButton_MouseLeave(object sender, EventArgs e)
        {
            logoutButton.BackColor = Color.FromArgb(30, 58, 95);
        }

        private void accountDriver_Click(object sender, EventArgs e)
        {
            SetActiveButton(accountDriver);
            driverAccountShow driveracc = new driverAccountShow(userData);
            panel2.Controls.Clear();
            panel2.Controls.Add(driveracc);
        }

        private void homeDriver1_Load(object sender, EventArgs e)
        {

        }
    }
}
