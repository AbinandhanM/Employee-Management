using LeaveAPI.Models;
using LeaveAPI.Models.DTOs;

namespace LeaveAPI.Interfaces
{
    public interface ILeaveService
    {
        public Task<Leave?> ApplyLeave(Leave leave);
        public Task<Leave?> UpdateLeaveStatus(LeaveDTO leave);
    }
}
