using System;

namespace ReceptionistApp.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string Name => $"{FirstName} {LastName}";
        public DateTime DateOfBirth { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
    }
}
