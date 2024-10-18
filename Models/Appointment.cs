using System;

namespace ReceptionistApp.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public required string Reason { get; set; }
    }
}