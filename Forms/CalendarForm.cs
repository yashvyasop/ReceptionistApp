using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ReceptionistApp.Models;
using ReceptionistApp.Services;

namespace ReceptionistApp
{
    public partial class CalendarForm : Form
    {
        public CalendarForm()
        {
            InitializeComponent();
            InitializeEventHandlers();
        }

        private void InitializeEventHandlers()
        {
            calendarAppointments.DateSelected += CalendarAppointments_DateSelected;
        }

        private void CalendarAppointments_DateSelected(object? sender, DateRangeEventArgs e)
        {
            DisplayAppointmentsForDate(e.Start);
        }

        private void DisplayAppointmentsForDate(DateTime date)
        {
            lstAppointments.Items.Clear();
            lstAppointments.Items.Add($"Appointments for {date.ToShortDateString()}:");
            
            List<Appointment> appointmentsForDate = AppointmentService.GetAppointmentsForDate(date);

            if (appointmentsForDate.Any())
            {
                foreach (var appointment in appointmentsForDate)
                {
                    string patientName = PatientService.GetPatientNameById(appointment.PatientId);
                    lstAppointments.Items.Add($"{appointment.AppointmentDateTime.ToShortTimeString()} - {patientName} - {appointment.Reason}");
                }
            }
            else
            {
                lstAppointments.Items.Add("No appointments scheduled for this date.");
            }
        }
    }
}