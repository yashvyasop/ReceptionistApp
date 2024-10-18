namespace ReceptionistApp
{
    partial class CalendarForm
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Text = "Appointment Calendar";

            // ... existing code ...

            this.calendarAppointments = new System.Windows.Forms.MonthCalendar();
            this.lstAppointments = new System.Windows.Forms.ListBox();

            this.SuspendLayout();

            // calendarAppointments
            this.calendarAppointments.Location = new System.Drawing.Point(12, 12);
            this.calendarAppointments.MaxSelectionCount = 1;

            // lstAppointments
            this.lstAppointments.Location = new System.Drawing.Point(260, 12);
            this.lstAppointments.Size = new System.Drawing.Size(300, 340);

            // CalendarForm
            this.ClientSize = new System.Drawing.Size(580, 370);
            this.Controls.Add(this.calendarAppointments);
            this.Controls.Add(this.lstAppointments);
            this.Text = "Appointment Calendar";

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.MonthCalendar calendarAppointments;
        private System.Windows.Forms.ListBox lstAppointments;
    }
}