using System;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using ReceptionistApp.Services;
using ReceptionistApp.Models;

namespace ReceptionistApp
{
    public partial class SearchForm : Form
    {
        private CancellationTokenSource? _cts;

        public SearchForm()
        {
            InitializeComponent();
            InitializeSearchForm();
        }

        private void InitializeSearchForm()
        {
            btnSearch.Click += BtnSearch_Click;
            listViewResults.SelectedIndexChanged += ListViewResults_SelectedIndexChanged;
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private async void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            try
            {
                await Task.Delay(300, _cts.Token); // Debounce for 300ms
                await PerformSearchAsync(_cts.Token);
            }
            catch (TaskCanceledException)
            {
                // Search was cancelled, do nothing
            }
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            _ = PerformSearchAsync(_cts.Token);
        }

        private async Task PerformSearchAsync(CancellationToken cancellationToken)
        {
            string searchTerm = txtSearch.Text.Trim();
            List<Patient> patients;

            if (string.IsNullOrEmpty(searchTerm))
            {
                patients = new List<Patient>();
            }
            else
            {
                patients = await Task.Run(() => SearchService.SearchPatients(searchTerm), cancellationToken);
            }

            if (!cancellationToken.IsCancellationRequested)
            {
                DisplaySearchResults(patients);
            }
        }

        private void DisplaySearchResults(List<Patient> patients)
        {
            listViewResults.Items.Clear();
            foreach (var patient in patients)
            {
                ListViewItem item = new ListViewItem(new[] { patient.Id.ToString(), $"{patient.FirstName} {patient.LastName}", patient.DateOfBirth.ToString("yyyy-MM-dd") });
                item.Tag = patient;
                listViewResults.Items.Add(item);
            }
        }

        private void ListViewResults_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listViewResults.SelectedItems.Count > 0)
            {
                Patient selectedPatient = (Patient)listViewResults.SelectedItems[0].Tag!;
                DisplayPatientAppointments(selectedPatient.Id);
            }
        }

        private void DisplayPatientAppointments(int patientId)
        {
            var appointments = AppointmentService.GetAppointmentsForPatient(patientId);
            listViewAppointments.Items.Clear();
            foreach (var appointment in appointments)
            {
                ListViewItem item = new ListViewItem(new[] { appointment.AppointmentDateTime.ToString("yyyy-MM-dd HH:mm"), appointment.Reason });
                listViewAppointments.Items.Add(item);
            }
        }
    }
}
