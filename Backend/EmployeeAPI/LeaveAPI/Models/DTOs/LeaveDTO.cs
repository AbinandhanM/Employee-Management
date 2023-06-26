namespace LeaveAPI.Models.DTOs
{
    public class LeaveDTO
    {
        public int leaveId { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
