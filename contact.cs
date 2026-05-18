using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PantawidPasada
{
    public partial class contact : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
           int nLeftRect, int nTopRect,
           int nRightRect, int nBottomRect,
           int nWidthEllipse, int nHeightEllipse
       );

        public contact()
        {
            InitializeComponent();
            setUpContact();
        }

        // =========================
        // 🔥 VALIDATION REMOVED
        // =========================
        public bool IsValid()
        {
            // Always return true, no blocking
            return true;
        }

        private void setUpContact()
        {
            StyleTextBox(phoneNum, "Enter contact number");
            StyleTextBox(email, "Enter email address");
            StyleTextBox(passWord, "Password");
            StyleTextBox(confirmPass, "Confirm Password");

            // Style each textbox individually (rounded + colors)
            StyleControl(phoneNum);
            StyleControl(email);
            StyleControl(passWord);
            StyleControl(confirmPass);
        }

        private void StyleTextBox(TextBox txt, string placeholder)
        {
            txt.BorderStyle = BorderStyle.None;
            txt.BackColor = Color.FromArgb(248, 250, 252);
            txt.ForeColor = Color.Black;
            txt.Font = new Font("Segoe UI", 20);
            txt.PlaceholderText = placeholder;
        }

        private void StyleControl(TextBox txt)
        {
            txt.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txt.Width, txt.Height, 10, 10));
        }

        public void FillData(UserData data)
        {
            data.Phone = phoneNum.Text;
            data.Email = email.Text;
            data.Password = passWord.Text;
        }

        public bool ISfilled()
        {
            if (string.IsNullOrWhiteSpace(phoneNum.Text) || string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrWhiteSpace(passWord.Text) || string.IsNullOrWhiteSpace(confirmPass.Text))
                return false;
            else
            {
                return true;
            }
        }
        private void contact_Load(object sender, EventArgs e)
        {

        }

        private void confirmPass_TextChanged(object sender, EventArgs e)
        {
            label6.Text = "*The password does not match!";

            if(confirmPass.Text != passWord.Text)
            {
                label6.Visible = true;
            }
            else
            {
                label6.Visible = false;
            }
        }
    }
}