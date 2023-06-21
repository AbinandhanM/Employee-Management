﻿using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using EmployeeAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListEmployeeController : ControllerBase
    {
        private readonly IRepo<int, User> _userRepo;
        private readonly IListEmployee _listEmployee;


        public ListEmployeeController(IRepo<int, User> userRepo,
            IListEmployee listEmployee)
        {
            _userRepo= userRepo;
            _listEmployee = listEmployee;

        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ActionResult<ICollection<Employee>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> GetAllEmployeees()
        {
            var users = await _listEmployee.GetEmployees();
            if (users == null)
            {
                return NotFound("No interns are available at the moment");
            }
            return Ok(users);
        }

        [HttpGet("{ID}")]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ActionResult<ICollection<Employee>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> GetEmployeeByID(int id)
        {
            var users = await _listEmployee.GetEmployeeById(id);
            if (users == null)
            {
                return NotFound("No interns are available at the moment");
            }
            return Ok(users);
        }

    }
}