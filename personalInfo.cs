using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PantawidPasada
{
    public partial class personalInfo : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
           int nLeftRect, int nTopRect,
           int nRightRect, int nBottomRect,
           int nWidthEllipse, int nHeightEllipse
        );

        public personalInfo()
        {
            InitializeComponent();
            SetUpPersoInfo();
        }

        // =========================
        // 🔥 VALIDATION REMOVED
        // =========================
        public bool IsValid()
        {
            // Always return true, no blocking
            return true;
        }

        // =========================
        // 🎨 SETUP UI
        // =========================
        private void SetUpPersoInfo()
        {
            StyleTextBox(firstName, "First Name");
            StyleTextBox(lastName, "Last Name");
            StyleTextBox(middleName, "Middle Name");
            StyleTextBox(address, "Address");

            // Province ComboBox
            province.ForeColor = Color.Gray;
            province.SelectedIndex = 0; // placeholder
            province.SelectedIndexChanged += (s, e) =>
            {
                province.ForeColor = province.SelectedIndex == 0 ? Color.Gray : Color.Black;
            };
            province.FlatStyle = FlatStyle.Flat;
            province.BackColor = Color.FromArgb(248, 250, 252);
        }

        private void StyleTextBox(TextBox txt, string placeholder)
        {
            txt.BorderStyle = BorderStyle.None;
            txt.BackColor = Color.FromArgb(248, 250, 252);
            txt.ForeColor = Color.Black;
            txt.Font = new Font("Segoe UI", 20);
            txt.PlaceholderText = placeholder;

            txt.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, txt.Width, txt.Height, 10, 10)
            );
        }

        public void FillData(UserData data)
        {
            data.FirstName = firstName.Text;
            data.LastName = lastName.Text;
            data.MiddleName = middleName.Text;
            data.Address = address.Text;
            data.Province = province.Text;
            string usernameBase = $"{firstName.Text.Replace(" ", "")}.{lastName.Text}".ToLower();
            data.username = usernameBase.ToLower();
        }

        public bool ISFilledUp()
        {
            if(string.IsNullOrWhiteSpace(firstName.Text) || string.IsNullOrWhiteSpace(lastName.Text)  || string.IsNullOrWhiteSpace(address.Text) || string.IsNullOrWhiteSpace(province.Text)) 
                return false;
            else
            {
                return true;
            }
        }

        private void personalInfo_Load(object sender, EventArgs e)
        {
        }
    }
}