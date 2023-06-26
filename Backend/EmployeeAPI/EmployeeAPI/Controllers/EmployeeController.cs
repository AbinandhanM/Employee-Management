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
        private readonly IManageUser _manageUserService;

        public EmployeeController(IRepo<int, Employee> employeeRepo, IManageUser manageUserService)
        {
            _employeeRepo = employeeRepo;
            _manageUserService = manageUserService;
        }
        [HttpPost]
        
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

        [HttpPut("ChangeStatus")]

        [ProducesResponseType(typeof(ActionResult<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateUserStatus( int id,User user)
        {
            if (user == null || id != user.UserId )
            {
                return BadRequest();
            }

            var updatedStatus = await _manageUserService.ChangeStatus(user);
            return Ok(updatedStatus);
        }


    }
}
