using System;
using System.Data.SQLite;
using System.IO;

namespace ReceptionistApp.Services
{
    public class DatabaseService
    {
        private static string connectionString = "Data Source=receptionist.db;Version=3;";

        public static void EnsureDatabaseCreated()
        {
            if (!File.Exists("receptionist.db"))
            {
                SQLiteConnection.CreateFile("receptionist.db");
            }
            InitializeDatabase();
        }

        public static void InitializeDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                
                string createPatientsTable = @"
                    CREATE TABLE IF NOT EXISTS Patients (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FirstName TEXT NOT NULL,
                        LastName TEXT NOT NULL,
                        DateOfBirth TEXT NOT NULL,
                        PhoneNumber TEXT,
                        Email TEXT
                    )";

                string createAppointmentsTable = @"
                    CREATE TABLE IF NOT EXISTS Appointments (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        PatientId INTEGER NOT NULL,
                        AppointmentDateTime TEXT NOT NULL,
                        Reason TEXT,
                        FOREIGN KEY (PatientId) REFERENCES Patients (Id)
                    )";

                using (SQLiteCommand cmd = new SQLiteCommand(createPatientsTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteCommand cmd = new SQLiteCommand(createAppointmentsTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}