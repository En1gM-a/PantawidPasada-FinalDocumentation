using System;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PantawidPasada
{
    /// <summary>
    /// Form1 — The Login Page of the PantawidPasada application.
    /// This is the entry point of the app where users authenticate
    /// before being routed to their respective dashboards.
    /// </summary>
    public partial class Form1 : Form
    {
        // =============================================
        // 🔐 LOGIN PAGE — WINDOWS API IMPORTS
        // =============================================

        // Imports GDI function to apply rounded corners to UI elements
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );

        // Imports Win32 message function used to set TextBox inner padding
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        // Windows message constant for setting TextBox margins
        private const int EM_SETMARGINS = 0xD3;
        private const int EC_LEFTMARGIN = 0x1;
        private const int EC_RIGHTMARGIN = 0x2;

        /// <summary>
        /// Sets the left padding inside a TextBox on the login form
        /// so text doesn't appear flush against the rounded border.
        /// </summary>
        private void SetTextBoxLeftPadding(TextBox txt, int leftPadding)
        {
            // Pack left and right margin values into a single 32-bit parameter
            int lParam = (0 << 16) | leftPadding;
            SendMessage(txt.Handle, EM_SETMARGINS, EC_LEFTMARGIN | EC_RIGHTMARGIN, lParam);
        }

        // =============================================
        // 🎨 LOGIN PAGE — TEXTBOX STYLING HELPER
        // A reusable utility class to style and format
        // any TextBox used across the login page UI.
        // =============================================
        public static class TextBoxHelper
        {
            // Windows API imports scoped to this helper class
            [DllImport("user32.dll")]
            private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

            private const int EM_SETMARGINS = 0xD3;
            private const int EC_LEFTMARGIN = 0x1;
            private const int EC_RIGHTMARGIN = 0x2;

            /// <summary>
            /// Applies a consistent rounded style and inner padding to any
            /// TextBox on the login form (username, password, etc.).
            /// </summary>
            public static void StyleTextBox(
                TextBox txt,
                string placeholder = "",
                int fontSize = 11,
                int leftMargin = 20,
                int rightMargin = 12,
                int cornerRadius = 10,
                Color? backColor = null,
                Color? foreColor = null)
            {
                txt.BorderStyle = BorderStyle.None;
                txt.BackColor = backColor ?? Color.FromArgb(248, 250, 252); // Light gray-white background
                txt.ForeColor = foreColor ?? Color.Black;
                txt.Font = new Font("Segoe UI", fontSize);

                // Set placeholder hint text (e.g., "Username", "Password")
                if (!string.IsNullOrEmpty(placeholder))
                    txt.PlaceholderText = placeholder;

                // Clip the TextBox into a rounded rectangle shape
                txt.Region = Region.FromHrgn(
                    CreateRoundRectRgn(0, 0, txt.Width, txt.Height, cornerRadius, cornerRadius)
                );

                // Push text cursor inward so it isn't clipped by rounded edges
                SendMessage(txt.Handle, EM_SETMARGINS, EC_LEFTMARGIN | EC_RIGHTMARGIN,
                    MakeLParam(leftMargin, rightMargin));
            }

            // Packs two 16-bit margin values into a single 32-bit lParam integer
            private static int MakeLParam(int low, int high)
                => (high << 16) | (low & 0xFFFF);

            // GDI rounded rectangle region function (local import for this helper)
            [DllImport("gdi32.dll")]
            private static extern IntPtr CreateRoundRectRgn(
                int nLeftRect, int nTopRect,
                int nRightRect, int nBottomRect,
                int nWidthEllipse, int nHeightEllipse);
        }

        // =============================================
        // 🔐 LOGIN PAGE — FORM CONSTRUCTOR
        // Initializes the login form, sets the brand
        // color scheme, and builds the login UI.
        // =============================================
        public Form1()
        {
            InitializeComponent();

            // Apply the app's dark blue brand color to the login panel background
            panel1.BackColor = Color.FromArgb(30, 58, 95);

            // Apply the brand color to the label (e.g., app name or tagline)
            label3.ForeColor = Color.FromArgb(30, 58, 95);

            // Remove focus from any input field when the login form first appears
            this.Shown += (s, e) =>
            {
                this.ActiveControl = null;
            };

            // Build and style all login UI elements (inputs, buttons, etc.)
            SetupLoginUI();
        }

        // =============================================
        // 🎨 LOGIN PAGE — UI SETUP
        // Styles the Username field, Password field,
        // Login button, and Sign Up link on the login page.
        // =============================================
        private void SetupLoginUI()
        {
            // --- USERNAME FIELD ---
            // Apply rounded style with "Username" placeholder text
            TextBoxHelper.StyleTextBox(usernameLogin, placeholder: "Username");
            usernameLogin.BorderStyle = BorderStyle.None;
            usernameLogin.BackColor = Color.FromArgb(248, 250, 252);
            usernameLogin.ForeColor = Color.Black;
            usernameLogin.Font = new Font("Segoe UI", 20);
            usernameLogin.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, usernameLogin.Width, usernameLogin.Height, 10, 10)
            );

            // --- PASSWORD FIELD ---
            // Apply rounded style with "Password" placeholder and mask characters
            TextBoxHelper.StyleTextBox(passwordLogin, placeholder: "Password");
            passwordLogin.BorderStyle = BorderStyle.None;
            passwordLogin.BackColor = Color.FromArgb(248, 250, 252);
            passwordLogin.ForeColor = Color.Black;
            passwordLogin.Font = new Font("Segoe UI", 20);
            passwordLogin.UseSystemPasswordChar = true; // Mask password input with dots
            passwordLogin.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, passwordLogin.Width, passwordLogin.Height, 10, 10)
            );

            // --- LOGIN BUTTON ---
            // Style the login button with yellow brand color and rounded corners
            login.FlatStyle = FlatStyle.Flat;
            login.FlatAppearance.BorderSize = 0;
            login.BackColor = Color.FromArgb(244, 196, 48); // Brand yellow
            login.ForeColor = Color.Black;
            login.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            login.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, login.Width, login.Height, 10, 10)
            );

            // Attach hover effects to the Login button (darkens on hover)
            login.MouseEnter += Login_HoverEnter;
            login.MouseLeave += Login_HoverLeave;

            // Attach hover effects to the Sign Up link (color change on hover)
            signUp.MouseEnter += signUp_HoverEnter;
            signUp.MouseLeave += signUp_HoverLeave;
        }

        // =============================================
        // 👁️ LOGIN PAGE — PASSWORD VISIBILITY TOGGLE
        // Tracks whether the password field is masked.
        // =============================================
        private bool isPasswordHidden = true;

        /// <summary>
        /// On login page load, ensure the password is masked
        /// and the eye icon shows the "closed" state.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            passwordLogin.UseSystemPasswordChar = true;
            pictureBox6.Image = Properties.Resources.eye_closed; // Show closed-eye icon
        }

        /// <summary>
        /// Toggles password visibility on the login page
        /// when the user clicks the eye icon next to the password field.
        /// </summary>
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (isPasswordHidden)
            {
                // Reveal password and switch to open-eye icon
                passwordLogin.UseSystemPasswordChar = false;
                pictureBox6.Image = Properties.Resources.eye_opened;
                isPasswordHidden = false;
            }
            else
            {
                // Mask password again and switch back to closed-eye icon
                passwordLogin.UseSystemPasswordChar = true;
                pictureBox6.Image = Properties.Resources.eye_closed;
                isPasswordHidden = true;
            }
        }

        // =============================================
        // 🔗 LOGIN PAGE — SIGN UP NAVIGATION
        // Redirects new users away from the login page
        // to the Sign Up / Registration form (Form2).
        // =============================================

        /// <summary>
        /// Hides the login page and opens the Sign Up form
        /// when the user clicks the "Sign Up" link.
        /// </summary>
        private void signUp_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide login page
            Form2 form2 = new Form2(); // Open registration form
            form2.ShowDialog();
            this.Close(); // Close login page after registration form is done
        }

        // Sign Up link turns dark yellow on hover
        private void signUp_HoverEnter(object sender, EventArgs e)
        {
            signUp.ForeColor = Color.FromArgb(220, 170, 30); // Darker yellow on hover
        }

        // Sign Up link returns to default black color when hover ends
        private void signUp_HoverLeave(object sender, EventArgs e)
        {
            signUp.ForeColor = Color.Black;
        }

        // Login button darkens to a deeper yellow on hover
        private void Login_HoverEnter(object sender, EventArgs e)
        {
            login.BackColor = Color.FromArgb(220, 170, 30); // Darker yellow on hover
        }

        // Login button returns to original brand yellow when hover ends
        private void Login_HoverLeave(object sender, EventArgs e)
        {
            login.BackColor = Color.FromArgb(244, 196, 48); // Original brand yellow
        }

        // =============================================
        // 🔐 LOGIN PAGE — AUTHENTICATION LOGIC
        // Reads credentials, determines the account type,
        // and routes the user to the correct dashboard.
        // =============================================

        /// <summary>
        /// Handles the Login button click on the login page.
        /// Authenticates the user and opens the appropriate
        /// panel based on their account role.
        /// </summary>
        private void login_Click(object sender, EventArgs e)
        {
            loginCheck auth = new loginCheck();

            // Read credentials entered on the login page
            string username = usernameLogin.Text;
            string password = passwordLogin.Text;

            // Prepare data holders for each possible account type
            UserData currentUser = new UserData();
            adminAcc currentAdmin = new adminAcc();
            govData currentGov = new govData();
            fuelEditorData currentFuel = new fuelEditorData();

            bool isLoggedIn;

            // Determine account type from the username prefix and authenticate accordingly
            if (username.Contains("admin@") || username.Contains("superadmin"))
                isLoggedIn = auth.loginAdmin(username, password, currentAdmin);       // Admin login
            else if (username.Contains("gov@"))
                isLoggedIn = auth.loginGov(username, password, currentGov);           // Government login
            else if (username.Contains("editor"))
                isLoggedIn = auth.loginFuelEditor(username, password, currentFuel);   // Fuel Editor login
            else
                isLoggedIn = auth.loginUser(username, password, currentUser);         // Regular user login

            // Identify the account type for routing after successful login
            bool isAdmin = username.Contains("admin@") || username.Contains("superadmin");
            bool isFuel = username.Contains("editor");
            bool isGov = username.Contains("gov@");

            if (isLoggedIn)
            {
                // Hide login page before opening the target dashboard
                this.Hide();

                if (isAdmin)
                {
                    // Route Admin to the Admin Panel
                    adminPanel adminPanel = new adminPanel(currentAdmin);
                    adminPanel.ShowDialog();
                    this.Close();
                }
                else if (isGov)
                {
                    // Route Government user to the Government Panel
                    governmentPanel governmentPanel = new governmentPanel(currentGov);
                    governmentPanel.ShowDialog();
                    this.Close();
                }
                else if (isFuel)
                {
                    // Route Fuel Editor to the Fuel Editor Home Panel
                    homeFuelEditor fuelPanel = new homeFuelEditor(currentFuel);
                    fuelPanel.ShowDialog();
                    this.Close();
                }
                else
                {
                    // Route regular user to their home dashboard (Form3)
                    Form3 form3 = new Form3(currentUser);
                    form3.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                // Login failed — show appropriate error message on the login page
                if (auth.LoginError == "deactivated")
                {
                    // Account exists but has been deactivated
                    MessageBox.Show(
                        "This account has been deactivated. Please contact support to reactivate your account.",
                        "Account Deactivated",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    // Wrong username or password entered on the login page
                    MessageBox.Show(
                        "The username or password you entered is incorrect.\nPlease try again.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        // =============================================
        // 🔇 LOGIN PAGE — UNUSED EVENT STUBS
        // These handlers are wired up by the designer
        // but have no custom behavior implemented yet.
        // =============================================
        private void login_MouseEnter(object sender, EventArgs e) { }
        private void login_MouseLeave(object sender, EventArgs e) { }
        private void signUp_MouseEnter(object sender, EventArgs e) { }
        private void signUp_MouseLeave(object sender, EventArgs e) { }
    }
}