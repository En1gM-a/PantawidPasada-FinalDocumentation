using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PantawidPasada
{
    public partial class adminPanel : Form
    {


        SlantedButton slantedButton = new SlantedButton();

        private adminAcc accAdmin;
        private Button activeButton;
        public adminPanel(adminAcc acc)
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(30, 58, 95);
            slantedButton.MakeSlanted(homeButtonAdmin);
            slantedButton.MakeSlanted(fuelPriceAdmin);
            slantedButton.MakeSlanted(manageAccAdmin);
            slantedButton.MakeSlanted(accountAdmin);
            slantedButton.MakeSlanted(logoutButton);


            accAdmin = acc;

            homeAdmin home = new homeAdmin(accAdmin);
            panel2.Controls.Clear();
            panel2.Controls.Add(home);
        }

        private void SetActiveButton(Button clickedButton)
        {
            // Reset all buttons to default color
            Button[] buttons = { homeButtonAdmin, fuelPriceAdmin, manageAccAdmin, accountAdmin };
            foreach (var btn in buttons)
                btn.BackColor = Color.FromArgb(30, 58, 95); // default dark blue

            // Highlight the clicked button
            clickedButton.BackColor = Color.FromArgb(255, 230, 128); // yellow
            activeButton = clickedButton;
        }

        private void homeButtonAdmin_Click(object sender, EventArgs e)
        {
            SetActiveButton(homeButtonAdmin);
            homeAdmin home = new homeAdmin(accAdmin);
            panel2.Controls.Clear();
            panel2.Controls.Add(home);
        }

        private void fuelPriceAdmin_Click(object sender, EventArgs e)
        {
            SetActiveButton(fuelPriceAdmin);
            fuelPrice fuel = new fuelPrice();
            panel2.Controls.Clear();
            panel2.Controls.Add(fuel);
        }

        private void manageAccAdmin_Click(object sender, EventArgs e)
        {
            SetActiveButton(manageAccAdmin);
            manageAccAdmin manageAcc = new manageAccAdmin(accAdmin);
            panel2.Controls.Clear();
            panel2.Controls.Add(manageAcc);
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void accountAdmin_Click(object sender, EventArgs e)
        {
            SetActiveButton(accountAdmin);
            adminAccountShow acc = new adminAccountShow(accAdmin);
            panel2.Controls.Clear();
            panel2.Controls.Add(acc);
        }

        private void homeButtonAdmin_MouseHover(object sender, EventArgs e)
        {
            if (activeButton != homeButtonAdmin)
                homeButtonAdmin.BackColor = Color.FromArgb(255, 210, 90); // hover yellow
        }

        private void homeButtonAdmin_MouseLeave(object sender, EventArgs e)
        {
            if (activeButton != homeButtonAdmin)
                homeButtonAdmin.BackColor = Color.FromArgb(30, 58, 95); // reset to default
        }

        private void adminPanel_Load(object sender, EventArgs e)
        {
            SetActiveButton(homeButtonAdmin);
        }

        private void fuelPriceAdmin_MouseHover(object sender, EventArgs e)
        {
            if (activeButton != fuelPriceAdmin)
                fuelPriceAdmin.BackColor = Color.FromArgb(255, 210, 90); // hover yellow
        }

        private void fuelPriceAdmin_MouseLeave(object sender, EventArgs e)
        {
            if (activeButton != fuelPriceAdmin)
                fuelPriceAdmin.BackColor = Color.FromArgb(30, 58, 95); // reset to default
        }

        private void manageAccAdmin_MouseHover(object sender, EventArgs e)
        {
            if (activeButton != manageAccAdmin)
                manageAccAdmin.BackColor = Color.FromArgb(255, 210, 90); // hover yellow
        }

        private void manageAccAdmin_MouseLeave(object sender, EventArgs e)
        {
            if (activeButton != manageAccAdmin)
                manageAccAdmin.BackColor = Color.FromArgb(30, 58, 95); // reset to default
        }

        private void accountAdmin_MouseHover(object sender, EventArgs e)
        {
            if (activeButton != accountAdmin)
                accountAdmin.BackColor = Color.FromArgb(255, 210, 90); // hover yellow
        }

        private void accountAdmin_MouseLeave(object sender, EventArgs e)
        {
            if (activeButton != accountAdmin)
                accountAdmin.BackColor = Color.FromArgb(30, 58, 95); // reset to default
        }

        private void logoutButton_MouseHover(object sender, EventArgs e)
        {
            if (activeButton != logoutButton)
                logoutButton.BackColor = Color.FromArgb(255, 210, 90); // hover yellow
        }

        private void logoutButton_MouseLeave(object sender, EventArgs e)
        {

            if (activeButton != logoutButton)
                logoutButton.BackColor = Color.FromArgb(30, 58, 95); // reset to default
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseSeeder seeder = new DatabaseSeeder();
            seeder.SeedGovAccounts();
        }
    }
}

