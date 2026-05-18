namespace PantawidPasada
{
    partial class financialInfo
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
            employmentType = new ComboBox();
            sourceOfIncome = new TextBox();
            income = new ComboBox();
            financialObligation = new TextBox();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(13, 0);
            label4.Name = "label4";
            label4.Size = new Size(372, 47);
            label4.TabIndex = 31;
            label4.Text = "Financial Information";
            // 
            // employmentType
            // 
            employmentType.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            employmentType.FormattingEnabled = true;
            employmentType.Items.AddRange(new object[] { "Employment Type", "Self-Employed", "Employed(Company)", "Freelance", "Other" });
            employmentType.Location = new Point(13, 127);
            employmentType.Name = "employmentType";
            employmentType.Size = new Size(402, 38);
            employmentType.TabIndex = 32;
            // 
            // sourceOfIncome
            // 
            sourceOfIncome.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sourceOfIncome.Location = new Point(13, 198);
            sourceOfIncome.Multiline = true;
            sourceOfIncome.Name = "sourceOfIncome";
            sourceOfIncome.Size = new Size(402, 38);
            sourceOfIncome.TabIndex = 33;
            // 
            // income
            // 
            income.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            income.FormattingEnabled = true;
            income.Items.AddRange(new object[] { "Monthly Income", "Below 5,000", "5,000 – 9,999", "10,000 – 14,999", "15,000 – 19,999", "20,000 – 24,999", "25,000 – 29,999", "30,000 and above" });
            income.Location = new Point(13, 59);
            income.Name = "income";
            income.Size = new Size(402, 38);
            income.TabIndex = 35;
            // 
            // financialObligation
            // 
            financialObligation.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            financialObligation.Location = new Point(13, 269);
            financialObligation.Multiline = true;
            financialObligation.Name = "financialObligation";
            financialObligation.Size = new Size(402, 38);
            financialObligation.TabIndex = 36;
            // 
            // financialInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(financialObligation);
            Controls.Add(income);
            Controls.Add(sourceOfIncome);
            Controls.Add(employmentType);
            Controls.Add(label4);
            Name = "financialInfo";
            Size = new Size(437, 393);
            Load += financialInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private ComboBox income;
        private TextBox sourceOfIncome;
        private ComboBox employmentType;
        private TextBox financialObligation;
    }
}
