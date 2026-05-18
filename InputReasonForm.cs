using System;
using System.Drawing;
using System.Windows.Forms;

namespace PantawidPasada
{
    public partial class InputReasonForm : Form
    {
        public string ReasonText { get; private set; } = "";

        private TextBox txtReason;
        private Button btnOk;
        private Button btnCancel;

        public InputReasonForm(string title)
        {
            this.Text = title;
            this.Size = new Size(400, 200);
            this.StartPosition = FormStartPosition.CenterParent;

            Label lbl = new Label()
            {
                Text = "Type reason:",
                Location = new Point(20, 20),
                AutoSize = true
            };

            txtReason = new TextBox()
            {
                Location = new Point(20, 50),
                Width = 340
            };

            btnOk = new Button()
            {
                Text = "OK",
                Location = new Point(200, 100),
                DialogResult = DialogResult.OK
            };

            btnCancel = new Button()
            {
                Text = "Cancel",
                Location = new Point(280, 100),
                DialogResult = DialogResult.Cancel
            };

            btnOk.Click += (s, e) =>
            {
                ReasonText = txtReason.Text;
                this.Close();
            };

            btnCancel.Click += (s, e) =>
            {
                ReasonText = "";
                this.Close();
            };

            this.Controls.Add(lbl);
            this.Controls.Add(txtReason);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);
        }
    }
}