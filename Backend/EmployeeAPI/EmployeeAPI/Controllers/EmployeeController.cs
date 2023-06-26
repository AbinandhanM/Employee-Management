using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using EmployeeAPI.Models.DTOs;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("AngularCORS")]

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
        public async Task<ActionResult<UserDTO>> Register(Employee employee)
        {
            var result = await _manageUserService.Register(employee);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Unable to register at this moment");
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Login(UserDTO user)
        {
            var result = await _manageUserService.Login(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Invalid Id or Password");
        }
        [HttpPost]
        
        [ProducesResponseType(typeof(ActionResult<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> AddEmployeees(Employee employee)
        {
            var users = await _manageUserService.AddEmployee(employee);
            if (users == null)
            {
                return NotFound("No interns are available at the moment");
            }
            return Ok(users);
        }

        [HttpPut("ChangeStatus")]

        [ProducesResponseType(typeof(ActionResult<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateUserStatus(UpdateUserStatus user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var updatedStatus = await _manageUserService.ChangeStatus(user);
            return Ok(updatedStatus);
        }


    }
}
