using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models
{
    public class Skill
    {
        [Key]
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string? SkillName { get; set; }
    }
}
