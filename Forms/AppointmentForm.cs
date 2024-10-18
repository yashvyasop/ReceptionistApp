using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ReceptionistApp.Models;
using ReceptionistApp.Services;

namespace ReceptionistApp
{
    public partial class AppointmentForm : Form
    {
        private List<Patient> allPatients;
        private List<PatientSuggestion> currentSuggestions;

        public AppointmentForm()
        {
            InitializeComponent();
            InitializeEventHandlers();
            LoadAllPatients();
        }

        private void InitializeEventHandlers()
        {
            btnSchedule.Click += BtnSchedule_Click;
            btnClear.Click += BtnClear_Click;
            txtPatientName.TextChanged += TxtPatientName_TextChanged;
            txtPatientName.KeyDown += TxtPatientName_KeyDown;
            lstPatientSuggestions.SelectedIndexChanged += LstPatientSuggestions_SelectedIndexChanged;
        }

        private void LoadAllPatients()
        {
            allPatients = PatientService.GetAllPatients();
        }

        private void TxtPatientName_TextChanged(object sender, EventArgs e)
        {
            UpdateSuggestions();
        }

        private void UpdateSuggestions()
        {
            string searchText = txtPatientName.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                lstPatientSuggestions.Visible = false;
                txtDateOfBirth.Clear();
                return;
            }

            currentSuggestions = allPatients
                .Where(p => p.Name.ToLower().Contains(searchText))
                .Select(p => new PatientSuggestion(p))
                .ToList();

            lstPatientSuggestions.DataSource = currentSuggestions;
            lstPatientSuggestions.DisplayMember = "DisplayText";
            lstPatientSuggestions.ValueMember = "PatientId";

            lstPatientSuggestions.Visible = currentSuggestions.Any();
            lstPatientSuggestions.Height = Math.Min(currentSuggestions.Count * 20, 100);
        }

        private void TxtPatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && lstPatientSuggestions.Visible)
            {
                lstPatientSuggestions.SelectedIndex = (lstPatientSuggestions.SelectedIndex + 1) % lstPatientSuggestions.Items.Count;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up && lstPatientSuggestions.Visible)
            {
                lstPatientSuggestions.SelectedIndex = (lstPatientSuggestions.SelectedIndex - 1 + lstPatientSuggestions.Items.Count) % lstPatientSuggestions.Items.Count;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter && lstPatientSuggestions.Visible)
            {
                SelectCurrentSuggestion();
                e.Handled = true;
            }
        }

        private void SelectCurrentSuggestion()
        {
            if (lstPatientSuggestions.SelectedItem is PatientSuggestion selectedSuggestion)
            {
                txtPatientName.Text = selectedSuggestion.Name;
                int cursorPosition = txtPatientName.Text.Length;
                txtPatientName.SelectionStart = cursorPosition;
                txtPatientName.SelectionLength = 0;
                lstPatientSuggestions.Visible = false;
                UpdateDateOfBirth(selectedSuggestion.DateOfBirth);
            }
        }

        private void UpdateDateOfBirth(DateTime dateOfBirth)
        {
            txtDateOfBirth.Text = dateOfBirth.ToString("d");
        }

        private void LstPatientSuggestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPatientSuggestions.SelectedItem is PatientSuggestion selectedSuggestion)
            {
                UpdateDateOfBirth(selectedSuggestion.DateOfBirth);
            }
        }

        private void BtnSchedule_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                int patientId = (lstPatientSuggestions.SelectedItem as PatientSuggestion)?.PatientId ?? 0;

                if (patientId == 0)
                {
                    MessageBox.Show("Please select a valid patient from the suggestions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime appointmentDateTime = dtpAppointmentDate.Value.Date + 
                    new TimeSpan(dtpAppointmentTime.Value.Hour, dtpAppointmentTime.Value.Minute, 0);

                Appointment newAppointment = new Appointment
                {
                    PatientId = patientId,
                    AppointmentDateTime = appointmentDateTime,
                    Reason = txtReason.Text
                };

                AppointmentService.AddAppointment(newAppointment);

                MessageBox.Show("Appointment scheduled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtPatientName.Text))
            {
                MessageBox.Show("Please enter the patient's name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbDoctor.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a doctor.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Please enter a reason for the appointment.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtPatientName.Clear();
            txtDateOfBirth.Clear();
            dtpAppointmentDate.Value = DateTime.Now;
            dtpAppointmentTime.Value = DateTime.Now;
            cmbDoctor.SelectedIndex = -1;
            txtReason.Clear();
            lstPatientSuggestions.Visible = false;
        }
    }

    public class PatientSuggestion
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DisplayText => $"{Name} (DOB: {DateOfBirth:d})";

        public PatientSuggestion(Patient patient)
        {
            PatientId = patient.Id;
            Name = patient.Name;
            DateOfBirth = patient.DateOfBirth;
        }
    }
}
