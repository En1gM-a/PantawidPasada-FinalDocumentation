using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PantawidPasada
{
    public partial class governmentPanel : Form
    {

        SlantedButton slantedButton = new SlantedButton();

        private govData dataGov;
        private Button activeButton;

        public governmentPanel(govData data)
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(30, 58, 95);
            slantedButton.MakeSlanted(homeButtonGov);
            slantedButton.MakeSlanted(subAppGov);
            slantedButton.MakeSlanted(accButtonGov);
            slantedButton.MakeSlanted(logoutButton);
            slantedButton.MakeSlanted(manageSubButton);

            dataGov = data;

            homeGovernment home = new homeGovernment(dataGov);
            panel2.Controls.Clear();
            panel2.Controls.Add(home);
        }

        private void SetActiveButton(Button clickedButton)
        {
            // Reset all buttons to default color
            Button[] buttons = { homeButtonGov, subAppGov, accButtonGov, logoutButton };
            foreach (var btn in buttons)
                btn.BackColor = Color.FromArgb(30, 58, 95); // default dark blue

            // Highlight the clicked button
            clickedButton.BackColor = Color.FromArgb(255, 230, 128); // yellow
            activeButton = clickedButton;
        }

        private void governmentPanel_Load(object sender, EventArgs e)
        {
            SetActiveButton(homeButtonGov);
        }
        private void homeButtonGov_Click(object sender, EventArgs e)
        {
            SetActiveButton(homeButtonGov);
            homeGovernment home = new homeGovernment(dataGov);
            panel2.Controls.Clear();
            panel2.Controls.Add(home);
        }

        private void subAppGov_Click(object sender, EventArgs e)
        {
            SetActiveButton(subAppGov);
            subsidyApp subApp = new subsidyApp();
            panel2.Controls.Clear();
            panel2.Controls.Add(subApp);
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loginForm = new Form1();
            loginForm.ShowDialog();
            this.Close();
        }

        private void manageSubButton_Click(object sender, EventArgs e)
        {
            SetActiveButton(manageSubButton);
            manageSubsidy manageSub = new manageSubsidy();
            panel2.Controls.Clear();
            panel2.Controls.Add(manageSub);
        }

        private void accButtonGov_Click(object sender, EventArgs e)
        {
            SetActiveButton(accButtonGov);

            govAccountShow account = new govAccountShow(dataGov);
            panel2.Controls.Clear();
            panel2.Controls.Add(account);
        }

        private void homeButtonGov_MouseHover(object sender, EventArgs e)
        {
            if (activeButton != homeButtonGov)
                homeButtonGov.BackColor = Color.FromArgb(255, 210, 90);
        }

        private void homeButtonGov_MouseLeave(object sender, EventArgs e)
        {
            if (activeButton != homeButtonGov)
                homeButtonGov.BackColor = Color.FromArgb(30, 58, 95); // reset to default
        }

        private void subAppGov_MouseHover(object sender, EventArgs e)
        {
            if (activeButton != subAppGov)
                subAppGov.BackColor = Color.FromArgb(255, 210, 90);
        }

        private void subAppGov_MouseLeave(object sender, EventArgs e)
        {
            if (activeButton != subAppGov)
                subAppGov.BackColor = Color.FromArgb(30, 58, 95); // reset to default
        }

        private void accButtonGov_MouseHover(object sender, EventArgs e)
        {
            if (activeButton != accButtonGov)
                accButtonGov.BackColor = Color.FromArgb(255, 210, 90);
        }

        private void accButtonGov_MouseLeave(object sender, EventArgs e)
        {
            if (activeButton != accButtonGov)
                accButtonGov.BackColor = Color.FromArgb(30, 58, 95); // reset to default
        }

        private void logoutButton_MouseHover(object sender, EventArgs e)
        {
            if (activeButton != logoutButton)
                logoutButton.BackColor = Color.FromArgb(255, 210, 90);
        }

        private void logoutButton_MouseLeave(object sender, EventArgs e)
        {
            if (activeButton != logoutButton)
                logoutButton.BackColor = Color.FromArgb(30, 58, 95); // reset to default
        }

        private void manageSubButton_MouseHover(object sender, EventArgs e)
        {
            if (activeButton != manageSubButton)
                manageSubButton.BackColor = Color.FromArgb(255, 210, 90);
        }

        private void manageSubButton_MouseLeave(object sender, EventArgs e)
        {
            if (activeButton != manageSubButton)
                manageSubButton.BackColor = Color.FromArgb(30, 58, 95); // reset to default
        }

        
    }
}
