namespace PantawidPasada
{
    partial class contact
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label4 = new Label();
            confirmPass = new TextBox();
            passWord = new TextBox();
            email = new TextBox();
            phoneNum = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(17, 8);
            label4.Name = "label4";
            label4.Size = new Size(364, 47);
            label4.TabIndex = 26;
            label4.Text = "Contact and Security";
            // 
            // confirmPass
            // 
            confirmPass.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            confirmPass.Location = new Point(17, 305);
            confirmPass.Name = "confirmPass";
            confirmPass.Size = new Size(402, 35);
            confirmPass.TabIndex = 23;
            confirmPass.TextChanged += confirmPass_TextChanged;
            // 
            // passWord
            // 
            passWord.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passWord.Location = new Point(17, 227);
            passWord.Name = "passWord";
            passWord.Size = new Size(402, 35);
            passWord.TabIndex = 21;
            // 
            // email
            // 
            email.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            email.Location = new Point(17, 153);
            email.Name = "email";
            email.Size = new Size(402, 35);
            email.TabIndex = 20;
            // 
            // phoneNum
            // 
            phoneNum.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            phoneNum.Location = new Point(17, 85);
            phoneNum.Name = "phoneNum";
            phoneNum.Size = new Size(402, 35);
            phoneNum.TabIndex = 19;
            // 
            // label6
            // 
            label6.AccessibleRole = AccessibleRole.None;
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(244, 343);
            label6.Name = "label6";
            label6.Size = new Size(175, 15);
            label6.TabIndex = 27;
            label6.Text = "*The password does not match!";
            // 
            // contact
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(confirmPass);
            Controls.Add(passWord);
            Controls.Add(email);
            Controls.Add(phoneNum);
            Name = "contact";
            Size = new Size(437, 393);
            Load += contact_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private TextBox confirmPass;
        private TextBox passWord;
        private TextBox email;
        private TextBox phoneNum;
        private Label label6;
    }
}
