using System.ComponentModel.DataAnnotations;

namespace LeaveAPI.Models
{
    public class Leave
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        private TimeSpan _numberOfDays;
        public int NumberOfDays 
        { get { return _numberOfDays.Days; }
          set { _numberOfDays = EndDate - StartDate; }
        }
        public string? Reason { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public int ManagerId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }    
    }

}
