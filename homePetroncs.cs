using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PantawidPasada
{
    public partial class homeFuelEditor : Form
    {

        SlantedButton slantedButton = new SlantedButton();
        private fuelEditorData fuelData;
        public homeFuelEditor(fuelEditorData data)
        {
            InitializeComponent();

            fuelData = data;
            setUpPetron();


            dashboardPetron dashboard = new dashboardPetron(fuelData);
            panel2.Controls.Clear();
            panel2.Controls.Add(dashboard);

            panel1.BackColor = Color.FromArgb(30, 58, 95);
            slantedButton.MakeSlanted(logoutButton);
        }

        private void setUpPetron()
        {
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;

            if (fuelData.name == "Petron")
            {
                label5.Text = "Petron";
                pictureBox3.Image = Properties.Resources.petronLogo;
            }
            else if (fuelData.name == "Caltex")
            {
                label5.Text = "Caltex";
                pictureBox3.Image = Properties.Resources.Untitled_design__2_;
            }
            else if (fuelData.name == "Shell")
            {
                label5.Text = "Shell";
                pictureBox3.Image = Properties.Resources.shellLogo;
            }
            else if (fuelData.name == "SeaOil")
            {
                label5.Text = "SeaOil";
                pictureBox3.Image = Properties.Resources.seaOil;
            }

        }

        private void logoutButton_MouseHover(object sender, EventArgs e)
        {
            logoutButton.BackColor = Color.FromArgb(255, 210, 90); // hover yellow
        }

        private void logoutButton_MouseLeave(object sender, EventArgs e)
        {
            logoutButton.BackColor = Color.FromArgb(30, 58, 95); // reset to default
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }
    }

}
