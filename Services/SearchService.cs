using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using ReceptionistApp.Models;

namespace ReceptionistApp.Services
{
    public class SearchService
    {
        private static string connectionString = "Data Source=receptionist.db;Version=3;";

        public static List<Patient> SearchPatients(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return new List<Patient>();
            }

            List<Patient> patients = new List<Patient>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT * FROM Patients 
                               WHERE FirstName LIKE @SearchTerm 
                               OR LastName LIKE @SearchTerm 
                               OR PhoneNumber LIKE @SearchTerm 
                               OR Email LIKE @SearchTerm
                               OR (FirstName || ' ' || LastName) LIKE @SearchTerm";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            patients.Add(new Patient
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FirstName = reader["FirstName"] as string ?? string.Empty,
                                LastName = reader["LastName"] as string ?? string.Empty,
                                DateOfBirth = DateTime.TryParse(reader["DateOfBirth"] as string, out var dob) ? dob : DateTime.MinValue,
                                PhoneNumber = reader["PhoneNumber"] as string ?? string.Empty,
                                Email = reader["Email"] as string ?? string.Empty
                            });
                        }
                    }
                }
            }

            return patients;
        }
    }
}
