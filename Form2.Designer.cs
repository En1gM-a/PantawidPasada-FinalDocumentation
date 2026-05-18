namespace PantawidPasada
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            pictureBox5 = new PictureBox();
            SignUp = new Label();
            label1 = new Label();
            next = new Button();
            label2 = new Label();
            progressBar1 = new ProgressBar();
            personalInfo1 = new personalInfo();
            contact1 = new contact();
            financialInfo1 = new financialInfo();
            vehicleInfo1 = new vehicleInfo();
            prev = new Button();
            panel1 = new Panel();
            summaryDetails1 = new summaryDetails();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(-2, 1);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(306, 98);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 7;
            pictureBox5.TabStop = false;
            // 
            // SignUp
            // 
            SignUp.AutoSize = true;
            SignUp.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SignUp.ForeColor = Color.White;
            SignUp.Location = new Point(310, 69);
            SignUp.Name = "SignUp";
            SignUp.Size = new Size(437, 30);
            SignUp.TabIndex = 2;
            SignUp.Text = "Fuel Subsidy and Fare Management System";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(299, -17);
            label1.Name = "label1";
            label1.Size = new Size(540, 86);
            label1.TabIndex = 0;
            label1.Text = "Pantawid Pasada";
            // 
            // next
            // 
            next.Location = new Point(535, 586);
            next.Name = "next";
            next.Size = new Size(130, 42);
            next.TabIndex = 6;
            next.Text = "Next  →";
            next.UseVisualStyleBackColor = true;
            next.Click += next_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(345, 124);
            label2.Name = "label2";
            label2.Size = new Size(245, 30);
            label2.TabIndex = 9;
            label2.Text = "DRIVER REGISTRATION";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(118, 157);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(654, 22);
            progressBar1.TabIndex = 10;
            // 
            // personalInfo1
            // 
            personalInfo1.Location = new Point(0, 0);
            personalInfo1.Name = "personalInfo1";
            personalInfo1.Size = new Size(437, 393);
            personalInfo1.TabIndex = 11;
            // 
            // contact1
            // 
            contact1.Location = new Point(3, 3);
            contact1.Name = "contact1";
            contact1.Size = new Size(437, 393);
            contact1.TabIndex = 12;
            // 
            // financialInfo1
            // 
            financialInfo1.Location = new Point(3, 3);
            financialInfo1.Name = "financialInfo1";
            financialInfo1.Size = new Size(437, 393);
            financialInfo1.TabIndex = 13;
            // 
            // vehicleInfo1
            // 
            vehicleInfo1.Location = new Point(3, 3);
            vehicleInfo1.Name = "vehicleInfo1";
            vehicleInfo1.Size = new Size(437, 393);
            vehicleInfo1.TabIndex = 14;
            // 
            // prev
            // 
            prev.Location = new Point(228, 584);
            prev.Name = "prev";
            prev.Size = new Size(130, 42);
            prev.TabIndex = 15;
            prev.Text = "← Prev";
            prev.UseVisualStyleBackColor = true;
            prev.Click += prev_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(summaryDetails1);
            panel1.Controls.Add(personalInfo1);
            panel1.Controls.Add(contact1);
            panel1.Controls.Add(vehicleInfo1);
            panel1.Controls.Add(financialInfo1);
            panel1.Location = new Point(228, 187);
            panel1.Name = "panel1";
            panel1.Size = new Size(437, 393);
            panel1.TabIndex = 16;
            // 
            // summaryDetails1
            // 
            summaryDetails1.Location = new Point(3, -2);
            summaryDetails1.Name = "summaryDetails1";
            summaryDetails1.Size = new Size(437, 393);
            summaryDetails1.TabIndex = 17;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 640);
            Controls.Add(panel1);
            Controls.Add(prev);
            Controls.Add(progressBar1);
            Controls.Add(label2);
            Controls.Add(next);
            Controls.Add(label1);
            Controls.Add(SignUp);
            Controls.Add(pictureBox5);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sign Up";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label SignUp;
        private PictureBox pictureBox5;
        private Label label2;
        private Button next;
        private ProgressBar progressBar1;
        private personalInfo personalInfo1;
        private contact contact1;
        private financialInfo financialInfo1;
        private vehicleInfo vehicleInfo1;
        private Button prev;
        private Panel panel1;
        private summaryDetails summaryDetails1;
    }
}