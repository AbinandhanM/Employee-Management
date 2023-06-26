using EmployeeAPI.Models;

namespace EmployeeAPI.Interfaces
{
    public interface IListEmployee
    {
        Task<ICollection<Employee>> GetEmployees();

        Task<Employee> GetEmployeeById(int empid);
        Task<ICollection<Employee>?> GetEmployeesByManagerID(int managerId);

    }
}
