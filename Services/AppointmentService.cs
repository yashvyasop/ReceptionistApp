using System;
using System.Collections.Generic;
using System.Data.SQLite;
using ReceptionistApp.Models;

namespace ReceptionistApp.Services
{
    public class AppointmentService
    {
        private static string connectionString = "Data Source=receptionist.db;Version=3;";

        public static void AddAppointment(Appointment appointment)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Appointments (PatientId, AppointmentDateTime, Reason) 
                               VALUES (@PatientId, @AppointmentDateTime, @Reason)";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                    cmd.Parameters.AddWithValue("@AppointmentDateTime", appointment.AppointmentDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@Reason", appointment.Reason);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Appointment> GetAppointmentsForDate(DateTime date)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT * FROM Appointments 
                               WHERE date(AppointmentDateTime) = @Date
                               ORDER BY AppointmentDateTime";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appointments.Add(new Appointment
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                PatientId = Convert.ToInt32(reader["PatientId"]),
                                AppointmentDateTime = DateTime.TryParse(reader["AppointmentDateTime"]?.ToString(), out var dateTime) ? dateTime : DateTime.MinValue,
                                Reason = reader["Reason"] as string ?? string.Empty
                            });
                        }
                    }
                }
            }

            return appointments;
        }

        public static List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT * FROM Appointments 
                               WHERE PatientId = @PatientId
                               ORDER BY AppointmentDateTime";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientId", patientId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appointments.Add(new Appointment
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                PatientId = Convert.ToInt32(reader["PatientId"]),
                                AppointmentDateTime = DateTime.TryParse(reader["AppointmentDateTime"]?.ToString(), out var dateTime) ? dateTime : DateTime.MinValue,
                                Reason = reader["Reason"] as string ?? string.Empty
                            });
                        }
                    }
                }
            }

            return appointments;
        }

        // Add more methods for updating, deleting, and retrieving appointments
    }
}
