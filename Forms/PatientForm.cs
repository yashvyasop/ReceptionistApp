using System.Windows.Forms;
using System.Net.Mail;
using ReceptionistApp.Models;
using ReceptionistApp.Services;

namespace ReceptionistApp
{
    public partial class PatientForm : Form
    {
        public PatientForm()
        {
            InitializeComponent();
            InitializeEventHandlers();
        }

        private void InitializeEventHandlers()
        {
            btnSave.Click +=  BtnSave_Click;
            btnClear.Click += BtnClear_Click;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (ValidateForm())
            {
                Patient newPatient = new Patient
                {
                    FirstName = txtName.Text.Split(' ')[0],
                    LastName = txtName.Text.Split(' ').Length > 1 ? string.Join(" ", txtName.Text.Split(' ').Skip(1)) : "",
                    PhoneNumber = txtPhone.Text,
                    Email = txtEmail.Text,
                    DateOfBirth = dtpDateOfBirth.Value
                };

                PatientService.AddPatient(newPatient);

                MessageBox.Show("Patient data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            dtpDateOfBirth.Value = DateTime.Now;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the patient's name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please enter the patient's phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}