using EmployeeAPI.Models;

namespace EmployeeAPI.Interfaces
{
    public interface IGeneratePassword
    {
        public Task<string?> GeneratePassword(Employee employee);
    }
}
