using System;
using System.Drawing;
using System.Windows.Forms;

namespace BKIApp
{
    public partial class Form1 : Form
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblBoy;
        private Label lblKilo;
        private TextBox txtBoy;
        private TextBox txtKilo;
        private Button btnHesabla;
        private Label lblBKI;
        private Label lblNetice;
        private PictureBox pictureBox1;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblBoy = new Label();
            this.lblKilo = new Label();
            this.txtBoy = new TextBox();
            this.txtKilo = new TextBox();
            this.btnHesabla = new Button();
            this.lblBKI = new Label();
            this.lblNetice = new Label();
            this.pictureBox1 = new PictureBox();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();

            this.BackColor = Color.White;
            this.ClientSize = new Size(500, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "BMI Calculator";

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(140, 30);
            lblTitle.Text = "BMI CALCULATOR";

            lblBoy.AutoSize = true;
            lblBoy.Font = new Font("Arial", 11F);
            lblBoy.Location = new Point(60, 110);
            lblBoy.Text = "Height (m):";

            txtBoy.Font = new Font("Arial", 11F);
            txtBoy.Location = new Point(180, 105);
            txtBoy.Size = new Size(200, 24);

            lblKilo.AutoSize = true;
            lblKilo.Font = new Font("Arial", 11F);
            lblKilo.Location = new Point(60, 160);
            lblKilo.Text = "Weight (kg):";

            txtKilo.Font = new Font("Arial", 11F);
            txtKilo.Location = new Point(180, 155);
            txtKilo.Size = new Size(200, 24);

            btnHesabla.BackColor = Color.DarkBlue;
            btnHesabla.ForeColor = Color.White;
            btnHesabla.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnHesabla.Location = new Point(160, 215);
            btnHesabla.Size = new Size(180, 45);
            btnHesabla.Text = "CALCULATE";
            btnHesabla.Click += new EventHandler(btnHesabla_Click);

            lblBKI.AutoSize = true;
            lblBKI.Font = new Font("Arial", 16F, FontStyle.Bold);
            lblBKI.ForeColor = Color.DarkBlue;
            lblBKI.Location = new Point(170, 300);
            lblBKI.Text = "BMI: 0.00";

            lblNetice.AutoSize = true;
            lblNetice.Font = new Font("Arial", 18F, FontStyle.Bold);
            lblNetice.ForeColor = Color.Green;
            lblNetice.Location = new Point(180, 350);
            lblNetice.Text = "Result";

            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(175, 400);
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            Controls.Add(lblTitle);
            Controls.Add(lblBoy);
            Controls.Add(txtBoy);
            Controls.Add(lblKilo);
            Controls.Add(txtKilo);
            Controls.Add(btnHesabla);
            Controls.Add(lblBKI);
            Controls.Add(lblNetice);
            Controls.Add(pictureBox1);

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnHesabla_Click(object sender, EventArgs e)
        {
            double boy;
            double kilo;

            if (!double.TryParse(txtBoy.Text, out boy))
            {
                MessageBox.Show("Boyu düzgün daxil edin!\nMəsələn: 1.75");
                txtBoy.Focus();
                return;
            }

            if (!double.TryParse(txtKilo.Text, out kilo))
            {
                MessageBox.Show("Çəkini düzgün daxil edin!\nMəsələn: 70");
                txtKilo.Focus();
                return;
            }

            if (boy <= 0 || kilo <= 0)
            {
                MessageBox.Show("Boy və çəki 0-dan böyük olmalıdır!");
                return;
            }

            double bki = kilo / (boy * boy);

            lblBKI.Text = "BMI: " + bki.ToString("0.00");

            if (bki < 18.5)
            {
                lblNetice.Text = "Underweight";
                lblNetice.ForeColor = Color.Orange;
                pictureBox1.Image = Properties.Resources.arig;
            }
            else if (bki < 25)
            {
                lblNetice.Text = "Normal weight";
                lblNetice.ForeColor = Color.Green;
                pictureBox1.Image = Properties.Resources.normal;
            }
            else if (bki < 30)
            {
                lblNetice.Text = "Overweight";
                lblNetice.ForeColor = Color.OrangeRed;
                pictureBox1.Image = Properties.Resources.artiq;
            }
            else
            {
                lblNetice.Text = "Obese";
                lblNetice.ForeColor = Color.Red;
                pictureBox1.Image = Properties.Resources.obez;
            }
        }
    }
}
