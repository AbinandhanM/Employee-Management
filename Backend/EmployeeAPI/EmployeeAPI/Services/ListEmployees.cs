using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;

namespace EmployeeAPI.Services
{
    public class ListEmployees : IListEmployee
    {
        private readonly IRepo<int,Employee> _repo;

        public ListEmployees(IRepo<int,Employee> repo)
        {
            repo = _repo;
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
          var result = await _repo.Get(id);
            return result;
        }


        public async Task<ICollection<Employee>> GetEmployees()
        {
            var result = new List<Employee>();
            var employees = (await _repo.GetAll()).ToList();       
           return result;
        }
    }
}
