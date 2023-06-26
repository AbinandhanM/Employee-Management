using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [JsonIgnore]
        public byte[]? PasswordHash { get; set; }
        [JsonIgnore]
        public byte[]? PasswordKey { get; set; }
        public string? Role { get; set; }
        public string? Status { get; set; }
    }
}
