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
    public partial class govAccountShow : UserControl
    {

        private govData account;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
           int nLeftRect, int nTopRect,
           int nRightRect, int nBottomRect,
           int nWidthEllipse, int nHeightEllipse
       );
        public govAccountShow()
        {
            InitializeComponent();
        }

        public govAccountShow(govData acc)
        {
            InitializeComponent();
            account = acc;
            setUpGovAcc();
        }

        private void StylePanel(Panel pnl, int radius = 20)
        {
            pnl.BackColor = Color.FromArgb(248, 250, 252); // same as textbox
            pnl.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, pnl.Width, pnl.Height, radius, radius)
            );
        }

        private void setUpGovAcc()
        {
            panel1.BackColor = Color.FromArgb(255, 210, 90);
            label22.Text = account.username;
            label23.Text = $"{account.firstName} {account.middleInit} {account.lastName}";
            label27.Text = account.contactNum;
            label28.Text = account.email;
            label30.Text = account.agency;
            label39.Text = account.govStats;
            label38.Text = account.createDay;
        }

        private void govAccountShow_Load(object sender, EventArgs e)
        {
            StylePanel(panel2, 20);
            StylePanel(panel3, 20);
        }
    }
}
