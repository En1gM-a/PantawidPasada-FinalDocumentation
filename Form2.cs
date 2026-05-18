using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PantawidPasada
{
    /// <summary>
    /// Form2 — The Sign-Up / Registration Page of the PantawidPasada application.
    /// This is a multi-step registration form that collects user information
    /// across 4 steps: Personal Info → Contact → Vehicle Info → Summary/Review.
    /// Once completed, the account is saved to the database and the user
    /// is redirected back to the Login Page (Form1).
    /// </summary>
    public partial class Form2 : Form
    {
        // =============================================
        // 📋 SIGN-UP PAGE — STEP TRACKER
        // Tracks which step of the registration form
        // the user is currently on (0-indexed).
        // =============================================
        int currentStep = 0;

        // Array holding all registration step controls in order
        UserControl[] steps;

        // =============================================
        // 📋 SIGN-UP PAGE — REGISTRATION STEP PANELS
        // Each UserControl represents one step in the
        // multi-step sign-up form.
        // =============================================
        private personalInfo personalInfo;     // Step 1: Personal Information
        private contact contact;               // Step 2: Contact Details
        private vehicleInfo vehicleInfo;       // Step 3: Vehicle Information
        private summaryDetails summary;        // Step 4: Review & Confirm Summary

        // Holds all data collected across all registration steps
        private UserData userData = new UserData();

        // Handles saving the completed registration data to the database
        private SaveDataBase saveDataBase = new SaveDataBase();

        // =============================================
        // 🚀 SIGN-UP PAGE — FORM CONSTRUCTOR
        // Initializes all registration step panels,
        // adds them to the form, sets up the progress
        // bar, and displays the first step.
        // =============================================
        public Form2()
        {
            InitializeComponent();

            // --- Step 1: Personal Info ---
            // Initialize and add to the form; visible by default as the first step
            personalInfo = new personalInfo();
            personalInfo.Dock = DockStyle.Fill;
            panel1.Controls.Add(personalInfo);

            // --- Step 2: Contact Details ---
            // Hidden until the user advances from Step 1
            contact = new contact();
            contact.Dock = DockStyle.Fill;
            contact.Visible = false;
            panel1.Controls.Add(contact);

            // --- Step 3: Vehicle Information ---
            // Hidden until the user advances from Step 2
            vehicleInfo = new vehicleInfo();
            vehicleInfo.Dock = DockStyle.Fill;
            vehicleInfo.Visible = false;
            panel1.Controls.Add(vehicleInfo);

            // --- Step 4: Summary / Review ---
            // Hidden until the user advances from Step 3;
            // displays all collected data for final review before submission
            summary = new summaryDetails();
            summary.Dock = DockStyle.Fill;
            summary.Visible = false;
            panel1.Controls.Add(summary);

            // Register all steps in order for sequential navigation
            steps = new UserControl[]
            {
                personalInfo,   // Step 1
                contact,        // Step 2
                vehicleInfo,    // Step 3
                summary         // Step 4
            };

            // Configure the progress bar to reflect sign-up progress across all steps
            progressBar1.Minimum = 0;
            progressBar1.Maximum = steps.Length - 1;
            progressBar1.Value = 0;
            progressBar1.Style = ProgressBarStyle.Continuous;

            // Apply the app's dark blue brand color to the sign-up form background
            this.BackColor = Color.FromArgb(30, 58, 95);

            // Show the first registration step when the form opens
            ShowStep(currentStep);
        }

        // =============================================
        // 🔄 SIGN-UP PAGE — STEP NAVIGATION
        // Shows the correct step panel, updates the
        // progress bar, and manages Prev/Next buttons.
        // =============================================

        /// <summary>
        /// Displays the registration step at the given index,
        /// hides all others, and updates navigation controls.
        /// </summary>
        private void ShowStep(int index)
        {
            // Hide all registration step panels before showing the target step
            foreach (var uc in steps)
                uc.Visible = false;

            // Show and bring to front the current step panel
            steps[index].Visible = true;
            steps[index].BringToFront();

            // Disable the "Previous" button on the first registration step
            prev.Enabled = index != 0;

            // Change "Next" button to "Finish" on the final summary step
            next.Text = (index == steps.Length - 1) ? "Finish" : "Next";

            // Ensure the Next/Finish button is always active and styled correctly
            next.Enabled = true;
            next.BackColor = Color.FromArgb(244, 196, 48); // Brand yellow

            // Update the progress bar to reflect the current step
            progressBar1.Value = index;
        }

        // =============================================
        // ➡️ SIGN-UP PAGE — NEXT / FINISH BUTTON
        // Validates the current step's inputs, saves
        // the data to UserData, then either advances
        // to the next step or finalizes registration.
        // =============================================

        /// <summary>
        /// Handles the Next/Finish button click on the sign-up form.
        /// Validates each step before proceeding; on the final step,
        /// saves the account to the database and redirects to login.
        /// </summary>
        private void next_Click(object sender, EventArgs e)
        {
            // --- Validate Step 1: Personal Information ---
            if (steps[currentStep] == personalInfo)
            {
                if (!personalInfo.ISFilledUp())
                {
                    // Block progression if required personal info fields are empty
                    MessageBox.Show("Please fill up all required fields.", "Incomplete Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Save personal info into the shared UserData object
                personalInfo.FillData(userData);
            }

            // --- Validate Step 2: Contact Details ---
            else if (steps[currentStep] == contact)
            {
                if (!contact.ISfilled())
                {
                    // Block progression if required contact fields are empty
                    MessageBox.Show("Please fill up all required fields.", "Incomplete Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Save contact details into the shared UserData object
                contact.FillData(userData);
            }

            // --- Validate Step 3: Vehicle Information ---
            else if (steps[currentStep] == vehicleInfo)
            {
                if (!vehicleInfo.ISfilled())
                {
                    // Block progression if required vehicle fields are empty
                    MessageBox.Show("Please fill up all required fields.", "Incomplete Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Save vehicle info into the shared UserData object
                vehicleInfo.FillData(userData);
            }

            // =============================================
            // Advance to the next registration step
            // =============================================
            if (currentStep < steps.Length - 1)
            {
                currentStep++;

                // If advancing to the Summary step, populate it with all collected data
                if (steps[currentStep] == summary)
                    summary.LoadData(userData);

                ShowStep(currentStep);
            }
            else
            {
                // =============================================
                // 💾 SIGN-UP PAGE — FINAL STEP: SAVE ACCOUNT
                // All steps are complete; attempt to save the
                // new account to the database.
                // =============================================
                bool success = saveDataBase.SaveToDB(userData);

                if (!success)
                {
                    // Registration failed — account with this username already exists
                    MessageBox.Show(
                        "Account already exists.\nYou will be redirected to the first step.",
                        "Signup Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    // Reset the sign-up form back to Step 1 so the user can try again
                    currentStep = 0;
                    userData = new UserData(); // Clear all previously collected data
                    ShowStep(currentStep);
                    return;
                }

                // Registration successful — inform the user of account restrictions
                MessageBox.Show(
                    "Sign up successful!\n\n" +
                    "IMPORTANT NOTICE:\n" +
                    "Your account details are locked for security purposes.\n" +
                    "Username and personal information cannot be modified after registration.\n" +
                    "Password recovery is handled through the system administrator.\n\n" +
                    "Please log in to continue.",
                    "Account Created",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Close the sign-up form and redirect the user back to the Login Page
                this.Hide();
                Form1 form1 = new Form1(); // Return to Login Page (Form1)
                form1.ShowDialog();
                this.Close();
            }
        }

        // =============================================
        // ⬅️ SIGN-UP PAGE — PREVIOUS BUTTON
        // Allows the user to go back to the previous
        // registration step to review or correct input.
        // =============================================

        /// <summary>
        /// Handles the Previous button click on the sign-up form.
        /// Navigates back one step in the registration process.
        /// </summary>
        private void prev_Click(object sender, EventArgs e)
        {
            if (currentStep > 0)
            {
                currentStep--;
                ShowStep(currentStep); // Return to the previous registration step
            }
        }

        // Event handler for when the sign-up form finishes loading (currently unused)
        private void Form2_Load(object sender, EventArgs e)
        {
        }
    }
}