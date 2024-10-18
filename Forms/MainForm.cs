using System;
using System.Windows.Forms;

namespace ReceptionistApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeMainMenu();
        }

        private void InitializeMainMenu()
        {
            btnPatients.Click += (s, e) => OpenForm(new PatientForm());
            btnAppointments.Click += (s, e) => OpenForm(new AppointmentForm());
            btnCalendar.Click += (s, e) => OpenForm(new CalendarForm());
            btnSearch.Click += (s, e) => OpenForm(new SearchForm());
        }

        private void OpenForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContent.Controls.Clear();
            panelContent.Controls.Add(form);
            form.Show();
        }
    }
}
