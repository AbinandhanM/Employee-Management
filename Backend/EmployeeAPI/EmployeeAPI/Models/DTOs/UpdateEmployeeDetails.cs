namespace EmployeeAPI.Models.DTOs
{
    public class UpdateEmployeeDetails
    {
        public int EmployeeID { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? PassportID { get; set; }
        public string? DrivingLicenseNumber { get; set; }
    }
}
