using LeaveAPI.Interfaces;
using LeaveAPI.Models;
using LeaveAPI.Models.DTOs;

namespace LeaveAPI.Services
{
    public class LeaveServiceRepo : ILeaveService
    {
        private readonly IRepo<int, Leave> _repo;

        public LeaveServiceRepo(IRepo<int,Leave> repo)
        {
            _repo = repo;
        }
        public async Task<Leave?> ApplyLeave(Leave leave)
        {
            leave.Status = "Not Updated";
            leave.Description = "Not Updated";
            leave.UpdatedAt = null;
            var addedLeave = await _repo.Add(leave);
            if (addedLeave != null)
            {
                return addedLeave;
            }
            return null;
        }

        public async Task<Leave?> UpdateLeaveStatus(LeaveDTO leave)
        {
            var resultLeave = await _repo.Get(leave.leaveId);
            if (resultLeave != null) 
            {
                resultLeave.Status = leave.Status;
                resultLeave.UpdatedAt = leave.UpdatedAt;
                resultLeave.Description = leave.Description;
                var updatedLeave = await _repo.Update(resultLeave);
                return updatedLeave;
            }
            return null;
        }
    }
}
