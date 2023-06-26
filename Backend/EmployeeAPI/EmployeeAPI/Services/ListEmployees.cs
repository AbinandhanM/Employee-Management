using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;

namespace EmployeeAPI.Services
{
    public class ListEmployees : IListEmployee
    {
        private readonly IRepo<int, Employee> _repo;

        public ListEmployees(IRepo<int,Employee> repo)
        {
            _repo = repo;
        }
        public async Task<Employee?> GetEmployeeById(int id)
        {
          var result = await _repo.Get(id);
            if (result!=null)
            {
                return result;
            }
            return null;
        }


        public async Task<ICollection<Employee>?> GetEmployees()
        {
            var employees = await _repo.GetAll();
            if (employees!=null)
            {
                return employees.ToList();
            }
            return null;
        }

        public async Task<ICollection<Employee>?> GetEmployeesByManagerID(int managerId)
        {
            var result = await _repo.GetAll();
            if (result!=null)
            {
                var employees = result.ToList();
                var classifiedEmployees = employees.Where(e => e.ManagerID == managerId).ToList();
                return classifiedEmployees;
            }
            return null; 
        }
    }
}
