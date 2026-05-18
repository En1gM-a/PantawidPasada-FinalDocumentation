using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PantawidPasada
{
    public partial class driverAccountShow : UserControl
    {
        private UserData userData;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
           int nLeftRect, int nTopRect,
           int nRightRect, int nBottomRect,
           int nWidthEllipse, int nHeightEllipse
       );
        public driverAccountShow()
        {
            InitializeComponent();


        }

        public driverAccountShow(UserData data)
        {
            InitializeComponent();
            userData = data;
            setUpAccount();

        }

        private void StylePanel(Panel pnl, int radius = 20)
        {
            pnl.BackColor = Color.FromArgb(248, 250, 252); // same as textbox
            pnl.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, pnl.Width, pnl.Height, radius, radius)
            );
        }

        private void setUpAccount()
        {
            panel1.BackColor = Color.FromArgb(255, 210, 90);
            label23.Text = $"{userData.FirstName} {userData.MiddleName} {userData.LastName}";
            label22.Text = userData.username;
            label25.Text = userData.Address;
            label26.Text = userData.Province;
            label27.Text = userData.Phone;
            label28.Text = userData.Email;
            label29.Text = userData.Income;
            label30.Text = userData.createDay;
            label39.Text = userData.VehicleType;
            label38.Text = userData.PlateNumber;
            label37.Text = userData.LicenseNumber;
        }

        private void driverAccountShow_Load(object sender, EventArgs e)
        {
            StylePanel(panel2, 20);
            StylePanel(panel3, 20);
        }
    }
}
