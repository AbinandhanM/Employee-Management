using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepo<int, Employee> _employeeRepo;

        public EmployeeController(IRepo<int, Employee> employeeRepo)
        {
            _employeeRepo = employeeRepo;

        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ActionResult<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> AddEmployeees(Employee employee)
        {
            var users = await _employeeRepo.Add(employee);
            if (users == null)
            {
                return NotFound("No interns are available at the moment");
            }
            return Ok(users);
        }

    }
}
