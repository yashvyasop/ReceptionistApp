namespace ReceptionistApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnPatients = new System.Windows.Forms.Button();
            this.btnAppointments = new System.Windows.Forms.Button();
            this.btnCalendar = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();

            this.panelMenu.SuspendLayout();
            this.SuspendLayout();

            // panelMenu
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Width = 200;
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);

            // btnPatients
            this.btnPatients.Text = "Patients";
            this.btnPatients.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatients.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPatients.Height = 60;

            // btnAppointments
            this.btnAppointments.Text = "Appointments";
            this.btnAppointments.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAppointments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppointments.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAppointments.Height = 60;

            // btnCalendar
            this.btnCalendar.Text = "Calendar";
            this.btnCalendar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalendar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCalendar.Height = 60;

            // btnSearch
            this.btnSearch.Text = "Search";
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSearch.Height = 60;

            // panelContent
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(60, 60, 63);

            // MainForm
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.Text = "Receptionist App";

            this.panelMenu.Controls.Add(this.btnSearch);
            this.panelMenu.Controls.Add(this.btnCalendar);
            this.panelMenu.Controls.Add(this.btnAppointments);
            this.panelMenu.Controls.Add(this.btnPatients);

            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnPatients;
        private System.Windows.Forms.Button btnAppointments;
        private System.Windows.Forms.Button btnCalendar;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panelContent;
    }
}
