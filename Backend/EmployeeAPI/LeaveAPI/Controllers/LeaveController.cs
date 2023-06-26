using LeaveAPI.Interfaces;
using LeaveAPI.Models;
using LeaveAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly IRepo<int, Leave> _repo;
        private readonly ILeaveService _leaveService;

        public LeaveController(IRepo<int,Leave> repo,ILeaveService leaveService)
        {
            _repo = repo;
            _leaveService = leaveService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ActionResult<ICollection<Leave>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Leave>>> GetAll()
        {
            var leaves = await _repo.GetAll();
            if (leaves == null)
            {
                return NotFound("No Details are available at the moment");
            }
            return Ok(leaves);
        }
        [HttpGet]
        [ProducesResponseType(typeof(ActionResult<Leave>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Leave>> GetLeavesByLeaveId(int Id)
        {
            var leave = await _repo.Get(Id);
            if (leave == null)
            {
                return NotFound("No Details are available at the moment");
            }
            return Ok(leave);
        }
        [HttpPost]
        [ProducesResponseType(typeof(ActionResult<Leave>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Leave>>> Add(Leave leave)
        {
            var result = await _leaveService.ApplyLeave(leave);
            if (result == null)
            {
                return NotFound("unable to add the leave details");
            }
            return Created("Home", result);
        }
        [HttpPut]
        [ProducesResponseType(typeof(ActionResult<Leave>), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Leave>> ApproveLeave(LeaveDTO leave)
        {
            var result = await _leaveService.UpdateLeaveStatus(leave);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Unable to update leave details");
        }
        [HttpPut]
        [ProducesResponseType(typeof(ActionResult<Leave>), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Leave>> Update(Leave leave)
        {
            var result = await _repo.Update(leave);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Unable to update leave details");
        }
        [HttpDelete]
        [ProducesResponseType(typeof(ActionResult<Leave>), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Leave>> Delete(int id)
        {
            var result = await _repo.Delete(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Unable to Delete leave details");
        }
    }
}
