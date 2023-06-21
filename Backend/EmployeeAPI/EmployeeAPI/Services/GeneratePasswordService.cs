using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;

namespace EmployeeAPI.Services
{
    public class GeneratePasswordService : IGeneratePassword
    {
        public async Task<string?> GeneratePassword(Employee employee)
        {
            string password = String.Empty;
            password = employee.FirstName.Substring(0, 4);
            password += employee.DateOfBirth.Day;
            password += employee.DateOfBirth.Month;
            return password;
        }
    }
}
