using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace EmployeeAPI.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("ID")]
        public User? User { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? PassportID { get; set; }
        public string? DrivingLicenseNumber { get; set;}
        public ICollection<Skill>? Skills { get; set; }
        public int ManagerID { get; set; }
    }
}
