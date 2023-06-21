using EmployeeAPI.Models;
using EmployeeAPI.Models.DTOs;

namespace EmployeeAPI.Interfaces
{
    public interface IManageUser
    {
        public Task<UserDTO> Login(UserDTO user);
        public Task<UserDTO> Register(Employee employee);
        public Task<UserDTO> ChangeStatus(UserDTO user);
    }
}
