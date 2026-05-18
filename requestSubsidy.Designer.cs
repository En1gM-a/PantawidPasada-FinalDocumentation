namespace PantawidPasada
{
    partial class requestSubsidy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(requestSubsidy));
            label1 = new Label();
            SignUp = new Label();
            pictureBox5 = new PictureBox();
            panel1 = new Panel();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(313, -17);
            label1.Name = "label1";
            label1.Size = new Size(540, 86);
            label1.TabIndex = 8;
            label1.Text = "Pantawid Pasada";
            // 
            // SignUp
            // 
            SignUp.AutoSize = true;
            SignUp.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SignUp.ForeColor = Color.White;
            SignUp.Location = new Point(324, 69);
            SignUp.Name = "SignUp";
            SignUp.Size = new Size(437, 30);
            SignUp.TabIndex = 9;
            SignUp.Text = "Fuel Subsidy and Fare Management System";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(12, 1);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(306, 98);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 10;
            pictureBox5.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Location = new Point(229, 130);
            panel1.Name = "panel1";
            panel1.Size = new Size(446, 427);
            panel1.TabIndex = 11;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(378, 575);
            button1.Name = "button1";
            button1.Size = new Size(165, 53);
            button1.TabIndex = 12;
            button1.Text = "Request";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // requestSubsidy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(886, 640);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(SignUp);
            Controls.Add(pictureBox5);
            Name = "requestSubsidy";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "requestSubsidy";
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label SignUp;
        private PictureBox pictureBox5;
        private Panel panel1;
        private Button button1;
    }
}