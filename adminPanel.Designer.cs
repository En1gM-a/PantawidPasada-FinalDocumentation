namespace PantawidPasada
{
    partial class adminPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminPanel));
            panel1 = new Panel();
            label5 = new Label();
            label4 = new Label();
            logoutButton = new Button();
            accountAdmin = new Button();
            manageAccAdmin = new Button();
            fuelPriceAdmin = new Button();
            homeButtonAdmin = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(logoutButton);
            panel1.Controls.Add(accountAdmin);
            panel1.Controls.Add(manageAccAdmin);
            panel1.Controls.Add(fuelPriceAdmin);
            panel1.Controls.Add(homeButtonAdmin);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(533, 1043);
            panel1.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DimGray;
            label5.Location = new Point(173, 784);
            label5.Name = "label5";
            label5.Size = new Size(95, 30);
            label5.TabIndex = 10;
            label5.Text = "Account";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DimGray;
            label4.Location = new Point(173, 410);
            label4.Name = "label4";
            label4.Size = new Size(63, 30);
            label4.TabIndex = 9;
            label4.Text = "Main";
            // 
            // logoutButton
            // 
            logoutButton.FlatAppearance.BorderSize = 0;
            logoutButton.FlatStyle = FlatStyle.Flat;
            logoutButton.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logoutButton.ForeColor = Color.White;
            logoutButton.Location = new Point(173, 914);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(360, 47);
            logoutButton.TabIndex = 8;
            logoutButton.Text = "Log Out";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            logoutButton.MouseLeave += logoutButton_MouseLeave;
            logoutButton.MouseHover += logoutButton_MouseHover;
            // 
            // accountAdmin
            // 
            accountAdmin.FlatAppearance.BorderSize = 0;
            accountAdmin.FlatStyle = FlatStyle.Flat;
            accountAdmin.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            accountAdmin.ForeColor = Color.White;
            accountAdmin.Location = new Point(173, 817);
            accountAdmin.Name = "accountAdmin";
            accountAdmin.Size = new Size(360, 91);
            accountAdmin.TabIndex = 7;
            accountAdmin.Text = "Account";
            accountAdmin.UseVisualStyleBackColor = true;
            accountAdmin.Click += accountAdmin_Click;
            accountAdmin.MouseLeave += accountAdmin_MouseLeave;
            accountAdmin.MouseHover += accountAdmin_MouseHover;
            // 
            // manageAccAdmin
            // 
            manageAccAdmin.FlatAppearance.BorderSize = 0;
            manageAccAdmin.FlatStyle = FlatStyle.Flat;
            manageAccAdmin.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            manageAccAdmin.ForeColor = Color.White;
            manageAccAdmin.Location = new Point(173, 637);
            manageAccAdmin.Name = "manageAccAdmin";
            manageAccAdmin.Size = new Size(360, 91);
            manageAccAdmin.TabIndex = 6;
            manageAccAdmin.Text = "Manage Accounts";
            manageAccAdmin.UseVisualStyleBackColor = true;
            manageAccAdmin.Click += manageAccAdmin_Click;
            manageAccAdmin.MouseLeave += manageAccAdmin_MouseLeave;
            manageAccAdmin.MouseHover += manageAccAdmin_MouseHover;
            // 
            // fuelPriceAdmin
            // 
            fuelPriceAdmin.FlatAppearance.BorderSize = 0;
            fuelPriceAdmin.FlatStyle = FlatStyle.Flat;
            fuelPriceAdmin.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fuelPriceAdmin.ForeColor = Color.White;
            fuelPriceAdmin.Location = new Point(173, 537);
            fuelPriceAdmin.Name = "fuelPriceAdmin";
            fuelPriceAdmin.Size = new Size(360, 91);
            fuelPriceAdmin.TabIndex = 5;
            fuelPriceAdmin.Text = "Monitor Fuel Prices";
            fuelPriceAdmin.UseVisualStyleBackColor = true;
            fuelPriceAdmin.Click += fuelPriceAdmin_Click;
            fuelPriceAdmin.MouseLeave += fuelPriceAdmin_MouseLeave;
            fuelPriceAdmin.MouseHover += fuelPriceAdmin_MouseHover;
            // 
            // homeButtonAdmin
            // 
            homeButtonAdmin.FlatAppearance.BorderSize = 0;
            homeButtonAdmin.FlatStyle = FlatStyle.Flat;
            homeButtonAdmin.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            homeButtonAdmin.ForeColor = Color.White;
            homeButtonAdmin.Location = new Point(173, 443);
            homeButtonAdmin.Name = "homeButtonAdmin";
            homeButtonAdmin.Size = new Size(360, 91);
            homeButtonAdmin.TabIndex = 4;
            homeButtonAdmin.Text = "Home";
            homeButtonAdmin.UseVisualStyleBackColor = true;
            homeButtonAdmin.Click += homeButtonAdmin_Click;
            homeButtonAdmin.MouseLeave += homeButtonAdmin_MouseLeave;
            homeButtonAdmin.MouseHover += homeButtonAdmin_MouseHover;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 246);
            label3.Name = "label3";
            label3.Size = new Size(240, 50);
            label3.TabIndex = 2;
            label3.Text = "Fuel Subsidy and \r\nFare Management System\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 97);
            label2.Name = "label2";
            label2.Size = new Size(235, 86);
            label2.TabIndex = 1;
            label2.Text = "PANEL";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 11);
            label1.Name = "label1";
            label1.Size = new Size(261, 86);
            label1.TabIndex = 0;
            label1.Text = "ADMIN";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(265, 122);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(268, 234);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Location = new Point(535, 1);
            panel2.Name = "panel2";
            panel2.Size = new Size(1374, 1040);
            panel2.TabIndex = 2;
            // 
            // adminPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "adminPanel";
            Text = "adminPanel";
            Load += adminPanel_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button logoutButton;
        private Button accountAdmin;
        private Button manageAccAdmin;
        private Button fuelPriceAdmin;
        private Button homeButtonAdmin;
        private Label label3;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label4;
        private Panel panel2;
        private Label label5;
    }
}