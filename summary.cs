using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PantawidPasada
{
    public partial class summaryDetails : UserControl
    {
        public summaryDetails()
        {
            InitializeComponent();
        }

        public void LoadData(UserData data)
        {
            // Personal Info
            NameUser.Text = $"{data.FirstName} {data.MiddleName} {data.LastName}";
            AddressUser.Text = $"{data.Address},{data.Province}";

            // Contact Info
            numberUser.Text = data.Phone;
            eMail.Text = data.Email;
            // Financial Info
            
            label7.Text = data.PlateNumber;
            label9.Text = data.VehicleType;
            label11.Text = data.LicenseNumber;


            label15.Text = data.username;
            
            textBox1.Text = data.Password ;

        }
        private bool isPasswordHidden = true;
        private void summary_Load(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = true;
            pictureBox1.Image = Properties.Resources.eye_closed;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

            if (isPasswordHidden)
            {
                textBox1.UseSystemPasswordChar = false;
                pictureBox1.Image = Properties.Resources.eye_opened;
                isPasswordHidden = false;
            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
                pictureBox1.Image = Properties.Resources.eye_closed;
                isPasswordHidden = true;
            }
        
        }
    }
}
