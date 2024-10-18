namespace ReceptionistApp
{
    partial class AppointmentForm
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
            this.lblPatientName = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.lstPatientSuggestions = new System.Windows.Forms.ListBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.txtDateOfBirth = new System.Windows.Forms.TextBox();
            this.lblAppointmentDate = new System.Windows.Forms.Label();
            this.dtpAppointmentDate = new System.Windows.Forms.DateTimePicker();
            this.lblAppointmentTime = new System.Windows.Forms.Label();
            this.dtpAppointmentTime = new System.Windows.Forms.DateTimePicker();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // lblPatientName
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Location = new System.Drawing.Point(12, 15);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(80, 13);
            this.lblPatientName.Text = "Patient Name:";

            // txtPatientName
            this.txtPatientName.Location = new System.Drawing.Point(120, 12);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(250, 20);
            this.txtPatientName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;

            // lstPatientSuggestions
            this.lstPatientSuggestions.Location = new System.Drawing.Point(120, 32);
            this.lstPatientSuggestions.Name = "lstPatientSuggestions";
            this.lstPatientSuggestions.Size = new System.Drawing.Size(250, 0);
            this.lstPatientSuggestions.Visible = false;

            // lblDateOfBirth
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(12, 45);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(69, 13);
            this.lblDateOfBirth.Text = "Date of Birth:";
            this.cmbDoctor.BackColor = System.Drawing.Color.White;

            // txtDateOfBirth
            this.txtDateOfBirth.Location = new System.Drawing.Point(120, 42);
            this.txtDateOfBirth.Name = "txtDateOfBirth";
            this.txtDateOfBirth.Size = new System.Drawing.Size(250, 20);
            this.txtDateOfBirth.ReadOnly = true;
            this.txtDateOfBirth.BackColor = System.Drawing.Color.White;

            // lblAppointmentDate
            this.lblAppointmentDate.AutoSize = true;
            this.lblAppointmentDate.Location = new System.Drawing.Point(12, 75);
            this.lblAppointmentDate.Name = "lblAppointmentDate";
            this.lblAppointmentDate.Size = new System.Drawing.Size(33, 13);
            this.lblAppointmentDate.Text = "Date:";

            // dtpAppointmentDate
            this.dtpAppointmentDate.Location = new System.Drawing.Point(120, 72);
            this.dtpAppointmentDate.Name = "dtpAppointmentDate";
            this.dtpAppointmentDate.Size = new System.Drawing.Size(250, 20);

            // lblAppointmentTime
            this.lblAppointmentTime.AutoSize = true;
            this.lblAppointmentTime.Location = new System.Drawing.Point(12, 105);
            this.lblAppointmentTime.Name = "lblAppointmentTime";
            this.lblAppointmentTime.Size = new System.Drawing.Size(33, 13);
            this.lblAppointmentTime.Text = "Time:";

            // dtpAppointmentTime
            this.dtpAppointmentTime.Location = new System.Drawing.Point(120, 102);
            this.dtpAppointmentTime.Name = "dtpAppointmentTime";
            this.dtpAppointmentTime.Size = new System.Drawing.Size(250, 20);
            this.dtpAppointmentTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAppointmentTime.CustomFormat = "  hh:mm tt";
            this.dtpAppointmentTime.ShowUpDown = true;

            // lblDoctor
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Location = new System.Drawing.Point(12, 135);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(42, 13);
            this.lblDoctor.Text = "Doctor:";

            // cmbDoctor
            this.cmbDoctor.Location = new System.Drawing.Point(120, 132);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(250, 21);
            this.cmbDoctor.Items.AddRange(new object[] {  "Dr. Vipul Chakurkar", "Dr. Harshad Toshniwal" });

            // lblReason
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(12, 165);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(47, 13);
            this.lblReason.Text = "Reason:";

            // txtReason
            this.txtReason.Location = new System.Drawing.Point(120, 162);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(250, 60);
            this.txtReason.Multiline = true;

            // btnSchedule
            this.btnSchedule.Location = new System.Drawing.Point(120, 240);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(100, 30);
            this.btnSchedule.Text = "Schedule";

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(230, 240);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.Text = "Clear";

            // AppointmentForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 290);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.lstPatientSuggestions);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.txtDateOfBirth);
            this.Controls.Add(this.lblAppointmentDate);
            this.Controls.Add(this.dtpAppointmentDate);
            this.Controls.Add(this.lblAppointmentTime);
            this.Controls.Add(this.dtpAppointmentTime);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.cmbDoctor);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.btnSchedule);
            this.Controls.Add(this.btnClear);
            this.Name = "AppointmentForm";
            this.Text = "Appointment Scheduling";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.ListBox lstPatientSuggestions;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.TextBox txtDateOfBirth;
        private System.Windows.Forms.Label lblAppointmentDate;
        private System.Windows.Forms.DateTimePicker dtpAppointmentDate;
        private System.Windows.Forms.Label lblAppointmentTime;
        private System.Windows.Forms.DateTimePicker dtpAppointmentTime;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Button btnClear;
    }
}
