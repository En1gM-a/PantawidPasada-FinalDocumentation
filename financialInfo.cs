using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PantawidPasada
{
    public partial class financialInfo : UserControl
    {
        // Holds the user's data passed from the parent form
        private UserData userData;

        // Reference to this control instance (used to call FillData)
        private financialInfo financialInfoControl;

        // Imports the Windows GDI function to create rounded rectangle regions
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );

        // Default constructor (no initialization — used as a fallback)
        public financialInfo()
        {
        }

        // Main constructor — initializes the control with user data and sets background color
        public financialInfo(UserData data)
        {
            InitializeComponent();
            setUpFinancialInfo();
            this.BackColor = Color.FromArgb(30, 58, 95); // Dark blue background
            userData = data;
        }

        // Validation method — currently bypassed, always returns true to allow proceeding
        public bool IsValid()
        {
            return true; // always allow Next
        }

        // Sets up the appearance and behavior of all form inputs
        private void setUpFinancialInfo()
        {
            // Apply placeholder text and styling to the text fields
            StyleTextBox(sourceOfIncome, "Other Source of Income");
            StyleTextBox(financialObligation, "Other Financial Obligation (loans, etc.)");

            // Set default gray appearance for the Monthly Income dropdown
            income.ForeColor = Color.Gray;
            income.SelectedIndex = 0;
            // Change text color to black when a real option is selected
            income.SelectedIndexChanged += (s, e) =>
            {
                income.ForeColor = income.SelectedIndex == 0 ? Color.Gray : Color.Black;
            };
            income.FlatStyle = FlatStyle.Flat;
            income.BackColor = Color.FromArgb(248, 250, 252); // Light gray background

            // Set default gray appearance for the Employment Type dropdown
            employmentType.ForeColor = Color.Gray;
            employmentType.SelectedIndex = 0;
            // Change text color to black when a real option is selected
            employmentType.SelectedIndexChanged += (s, e) =>
            {
                employmentType.ForeColor = employmentType.SelectedIndex == 0 ? Color.Gray : Color.Black;
            };
            employmentType.FlatStyle = FlatStyle.Flat;
            employmentType.BackColor = Color.FromArgb(248, 250, 252);

            // Apply rounded corner clipping regions to the text fields
            StyleControl(sourceOfIncome);
            StyleControl(financialObligation);
        }

        // Applies consistent styling (font, color, border, placeholder) to a TextBox
        private void StyleTextBox(TextBox txt, string placeholder)
        {
            txt.BorderStyle = BorderStyle.None;
            txt.BackColor = Color.FromArgb(248, 250, 252);
            txt.ForeColor = Color.Black;
            txt.Font = new Font("Segoe UI", 20);
            txt.PlaceholderText = placeholder;
        }

        // Clips a TextBox to a rounded rectangle shape using GDI region
        private void StyleControl(TextBox txt)
        {
            txt.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, txt.Width, txt.Height, 10, 10)
            );
        }

        // Reads values from the form inputs and stores them into the UserData object
        public void FillData(UserData data)
        {
            data.Income = income.Text;
            data.EmploymentType = employmentType.Text;
            data.SourceOfIncome = sourceOfIncome.Text;
            data.FinancialObligation = financialObligation.Text;
        }

        // Event handler for when the control finishes loading (currently unused)
        private void financialInfo_Load(object sender, EventArgs e)
        {
        }

        // Handles the Save/Submit button click — validates, fills data, and updates the database
        private void button1_Click(object sender, EventArgs e)
        {
            // Ensure the required dropdown fields are not empty before proceeding
            if (string.IsNullOrWhiteSpace(income.Text) || string.IsNullOrWhiteSpace(employmentType.Text))
            {
                MessageBox.Show("Please fill up all required fields.", "Incomplete Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Default optional fields to "N/A" if left blank
            if (string.IsNullOrWhiteSpace(sourceOfIncome.Text))
                sourceOfIncome.Text = "N/A";

            if (string.IsNullOrWhiteSpace(financialObligation.Text))
                financialObligation.Text = "N/A";

            // Transfer form input values into the userData object
            financialInfoControl.FillData(userData);

            try
            {
                // Open a connection to the MySQL database
                using (MySqlConnection conn = new MySqlConnection(dataBaseDetails.connStr))
                {
                    conn.Open();

                    // SQL query to update the driver's financial info by their username
                    string query = @"UPDATE driverAccs 
                                     SET income = @income,
                                         employment_type = @employment,
                                         source_of_income = @source,
                                         finan_ob = @obligation
                                     WHERE usernameUser = @username";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Bind UserData values to the query parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@income", userData.Income);
                    cmd.Parameters.AddWithValue("@employment", userData.EmploymentType);
                    cmd.Parameters.AddWithValue("@source", userData.SourceOfIncome);
                    cmd.Parameters.AddWithValue("@obligation", userData.FinancialObligation);
                    cmd.Parameters.AddWithValue("@username", userData.username);

                    // Execute the UPDATE query
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Display any database or connection errors to the user
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}