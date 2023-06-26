using EmployeeAPI.Context;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Services
{
    public class EmployeeRepo:IRepo<int,Employee>
    {
        private readonly EmployeeContext _context;
        private readonly ILogger<EmployeeRepo> _logger;

        public EmployeeRepo(EmployeeContext context, ILogger<EmployeeRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Employee?> Add(Employee item)
        {
            try
            {
                _context.Employees.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Employee?> Delete(int key)
        {
            var employee = await Get(key);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            return null;
        }

        public async Task<Employee?> Get(int key)
        {
            var employee = await _context.Employees.Include(e=>e.User).Include(e=>e.Skills).FirstOrDefaultAsync(e => e.ID == key);
            return employee;
        }

        public async Task<ICollection<Employee>?> GetAll()
        {
            var employees = await _context.Employees.Include(e => e.User).Include(e=>e.Skills).ToListAsync();
            if (employees.Count > 0)
                return employees;
            return null;
        }

        public async Task<Employee?> Update(Employee item)
        {
            var employee = await Get(item.ID);
            if (employee != null)
            {
                employee.ID = item.ID;
                employee.FirstName = item.FirstName;
                employee.LastName = item.LastName;
                employee.DateOfBirth = item.DateOfBirth;
                employee.Email = item.Email;
                employee.Gender = item.Gender;
                employee.Address = item.Address;
                employee.PhoneNumber = item.PhoneNumber;
                employee.PassportID = item.PassportID;
                employee.DrivingLicenseNumber = item.DrivingLicenseNumber;
                employee.Skills = item.Skills;
                employee.ManagerID  = item.ManagerID;
                await _context.SaveChangesAsync();
                return employee;
            }
            return null;
        }
    }
}
