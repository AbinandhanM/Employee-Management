using EmployeeAPI.Models.DTOs;

namespace UserManagementAPI.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(UserDTO user);

    }
}
