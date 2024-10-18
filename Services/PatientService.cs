using System;
using System.Data.SQLite;
using ReceptionistApp.Models;
using System.Collections.Generic;

namespace ReceptionistApp.Services
{
    public class PatientService
    {
        private static string connectionString = "Data Source=receptionist.db;Version=3;";

        public static void AddPatient(Patient patient)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Patients (FirstName, LastName, DateOfBirth, PhoneNumber, Email) 
                               VALUES (@FirstName, @LastName, @DateOfBirth, @PhoneNumber, @Email)";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", patient.LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@PhoneNumber", patient.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", patient.Email);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int GetPatientIdByName(string fullName)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string[] nameParts = fullName.Split(' ');
                string firstName = nameParts[0];
                string lastName = nameParts.Length > 1 ? string.Join(" ", nameParts.Skip(1)) : "";

                string sql = "SELECT Id FROM Patients WHERE FirstName = @FirstName AND LastName = @LastName";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public static string GetPatientNameById(int patientId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT FirstName, LastName FROM Patients WHERE Id = @PatientId";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientId", patientId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return $"{reader["FirstName"]} {reader["LastName"]}";
                        }
                    }
                }
            }
            return "Unknown Patient";
        }

        public static List<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Patients";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            patients.Add(new Patient
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FirstName = reader["FirstName"] as string ?? string.Empty,
                                LastName = reader["LastName"] as string ?? string.Empty,
                                DateOfBirth = DateTime.Parse(reader["DateOfBirth"] as string ?? DateTime.MinValue.ToString()),
                                PhoneNumber = reader["PhoneNumber"] as string ?? string.Empty,
                                Email = reader["Email"] as string ?? string.Empty
                            });
                        }
                    }
                }
            }

            return patients;
        }

        // Add more methods for updating, deleting, and retrieving patients
    }
}
