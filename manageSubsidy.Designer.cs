namespace PantawidPasada
{
    partial class manageSubsidy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(manageSubsidy));
            panel1 = new Panel();
            label2 = new Label();
            panel6 = new Panel();
            label4 = new Label();
            label22 = new Label();
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            label3 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            giveSub = new Button();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            searchDriver = new TextBox();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1375, 183);
            panel1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(38, 58);
            label2.Name = "label2";
            label2.Size = new Size(436, 65);
            label2.TabIndex = 1;
            label2.Text = "Manage Subsidies";
            // 
            // panel6
            // 
            panel6.BackColor = Color.Khaki;
            panel6.Controls.Add(label4);
            panel6.Controls.Add(label22);
            panel6.Location = new Point(38, 198);
            panel6.Name = "panel6";
            panel6.Size = new Size(933, 143);
            panel6.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Khaki;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DimGray;
            label4.Location = new Point(34, 20);
            label4.Name = "label4";
            label4.Size = new Size(837, 100);
            label4.TabIndex = 1;
            label4.Text = resources.GetString("label4.Text");
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.Gold;
            label22.Location = new Point(-2, 0);
            label22.Name = "label22";
            label22.Size = new Size(7, 165);
            label22.TabIndex = 0;
            label22.Text = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(38, 387);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(584, 612);
            dataGridView1.TabIndex = 14;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(678, 387);
            panel2.Name = "panel2";
            panel2.Size = new Size(412, 170);
            panel2.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(16, 94);
            label3.Name = "label3";
            label3.Size = new Size(128, 47);
            label3.TabIndex = 1;
            label3.Text = "TOTAL";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 27);
            label1.Name = "label1";
            label1.Size = new Size(355, 30);
            label1.TabIndex = 0;
            label1.Text = "TOTAL SUBSIDIES TO BE RELEASED";
            // 
            // panel3
            // 
            panel3.BackColor = Color.WhiteSmoke;
            panel3.Controls.Add(giveSub);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(label14);
            panel3.Location = new Point(678, 594);
            panel3.Name = "panel3";
            panel3.Size = new Size(412, 405);
            panel3.TabIndex = 16;
            // 
            // giveSub
            // 
            giveSub.FlatAppearance.BorderSize = 0;
            giveSub.FlatStyle = FlatStyle.Flat;
            giveSub.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            giveSub.Location = new Point(38, 336);
            giveSub.Name = "giveSub";
            giveSub.Size = new Size(299, 53);
            giveSub.TabIndex = 7;
            giveSub.Text = "Subsidy Given";
            giveSub.UseVisualStyleBackColor = true;
            giveSub.Click += giveSub_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(38, 278);
            label9.Name = "label9";
            label9.Size = new Size(58, 21);
            label9.TabIndex = 6;
            label9.Text = "EMAIL";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(38, 177);
            label10.Name = "label10";
            label10.Size = new Size(58, 21);
            label10.TabIndex = 5;
            label10.Text = "NAME";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(38, 76);
            label11.Name = "label11";
            label11.Size = new Size(64, 21);
            label11.TabIndex = 4;
            label11.Text = "₱ 5,000";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.DimGray;
            label12.Location = new Point(38, 245);
            label12.Name = "label12";
            label12.Size = new Size(117, 21);
            label12.TabIndex = 3;
            label12.Text = "Email Address";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.DimGray;
            label13.Location = new Point(38, 40);
            label13.Name = "label13";
            label13.Size = new Size(168, 21);
            label13.TabIndex = 2;
            label13.Text = "SUBSIDY TO RECIEVE";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.DimGray;
            label14.Location = new Point(38, 137);
            label14.Name = "label14";
            label14.Size = new Size(98, 21);
            label14.TabIndex = 1;
            label14.Text = "FULL NAME";
            // 
            // searchDriver
            // 
            searchDriver.Location = new Point(38, 358);
            searchDriver.Name = "searchDriver";
            searchDriver.Size = new Size(584, 23);
            searchDriver.TabIndex = 17;
            searchDriver.TextChanged += searchDriver_TextChanged;
            searchDriver.MouseEnter += searchDriver_MouseEnter;
            searchDriver.MouseLeave += searchDriver_MouseLeave;
            // 
            // manageSubsidy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            Controls.Add(searchDriver);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(dataGridView1);
            Controls.Add(panel6);
            Controls.Add(panel1);
            DoubleBuffered = true;
            ForeColor = SystemColors.ControlText;
            Name = "manageSubsidy";
            Size = new Size(1374, 1040);
            Load += manageSubsidy_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Panel panel6;
        private Label label22;
        private DataGridView dataGridView1;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label3;
        private Button giveSub;
        private Label label4;
        private TextBox searchDriver;
    }
}
