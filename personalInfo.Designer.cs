namespace PantawidPasada
{
    partial class personalInfo
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
            province = new ComboBox();
            label3 = new Label();
            address = new TextBox();
            birthDay = new DateTimePicker();
            middleName = new TextBox();
            lastName = new TextBox();
            firstName = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(12, 10);
            label4.Name = "label4";
            label4.Size = new Size(367, 47);
            label4.TabIndex = 18;
            label4.Text = "Personal Information";
            // 
            // province
            // 
            province.DropDownStyle = ComboBoxStyle.DropDownList;
            province.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            province.FormattingEnabled = true;
            province.Items.AddRange(new object[] { "Select Province", "Abra", "Agusan del Norte", "Agusan del Sur", "Aklan", "Albay", "Antique", "Apayao", "Aurora", "Basilan", "Bataan", "Batanes", "Batangas", "Benguet", "Biliran", "Bohol", "Bukidnon", "Bulacan", "Cagayan", "Camarines Norte", "Camarines Sur", "Camiguin", "Capiz", "Catanduanes", "Cavite", "Cebu", "Cotabato", "Davao de Oro", "Davao del Norte", "Davao del Sur", "Davao Occidental", "Davao Oriental", "Dinagat Islands", "Eastern Samar", "Guimaras", "Ifugao", "Ilocos Norte", "Ilocos Sur", "Iloilo", "Isabela", "Kalinga", "La Union", "Laguna", "Lanao del Norte", "Lanao del Sur", "Leyte", "Maguindanao del Norte", "Maguindanao del Sur", "Marinduque", "Masbate", "Misamis Occidental", "Misamis Oriental", "Mountain Province", "Negros Occidental", "Negros Oriental", "Northern Samar", "Nueva Ecija", "Nueva Vizcaya", "Occidental Mindoro", "Oriental Mindoro", "Palawan", "Pampanga", "Pangasinan", "Quezon", "Quirino", "Rizal", "Romblon", "Samar", "Sarangani", "Siquijor", "Sorsogon", "South Cotabato", "Southern Leyte", "Sultan Kudarat", "Sulu", "Surigao del Norte", "Surigao del Sur", "Tarlac", "Tawi-Tawi", "Zambales", "Zamboanga del Norte", "Zamboanga del Sur", "Zamboanga Sibugay" });
            province.Location = new Point(11, 350);
            province.Name = "province";
            province.Size = new Size(401, 40);
            province.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 222);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 16;
            label3.Text = "Birthday";
            // 
            // address
            // 
            address.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            address.Location = new Point(11, 292);
            address.Name = "address";
            address.Size = new Size(402, 35);
            address.TabIndex = 15;
            // 
            // birthDay
            // 
            birthDay.CalendarFont = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            birthDay.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            birthDay.Format = DateTimePickerFormat.Short;
            birthDay.Location = new Point(13, 240);
            birthDay.Name = "birthDay";
            birthDay.Size = new Size(149, 35);
            birthDay.TabIndex = 14;
            // 
            // middleName
            // 
            middleName.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            middleName.Location = new Point(12, 175);
            middleName.Name = "middleName";
            middleName.Size = new Size(402, 35);
            middleName.TabIndex = 13;
            // 
            // lastName
            // 
            lastName.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lastName.Location = new Point(12, 123);
            lastName.Name = "lastName";
            lastName.Size = new Size(402, 35);
            lastName.TabIndex = 12;
            // 
            // firstName
            // 
            firstName.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            firstName.Location = new Point(12, 70);
            firstName.Name = "firstName";
            firstName.Size = new Size(402, 35);
            firstName.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DimGray;
            label6.Location = new Point(354, 161);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 19;
            label6.Text = "*Optional";
            // 
            // personalInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label6);
            Controls.Add(province);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(address);
            Controls.Add(birthDay);
            Controls.Add(middleName);
            Controls.Add(lastName);
            Controls.Add(firstName);
            Name = "personalInfo";
            Size = new Size(437, 393);
            Load += personalInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private ComboBox province;
        private Label label3;
        private TextBox address;
        private DateTimePicker birthDay;
        private TextBox middleName;
        private TextBox lastName;
        private TextBox firstName;
        private Label label6;
    }
}
