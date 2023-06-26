using LeaveAPI.Context;
using LeaveAPI.Interfaces;
using LeaveAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveAPI.Services
{
    public class LeaveRepo:IRepo<int,Leave>
    {
        private LeaveContext _context;
        private ILogger<LeaveRepo> _logger;

        public LeaveRepo(LeaveContext context, ILogger<LeaveRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Leave?> Add(Leave item)
        {
            try
            {
                _context.Leaves.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Leave?> Delete(int key)
        {
            var leave = await Get(key);
            if (leave != null)
            {
                _context.Leaves.Remove(leave);
                await _context.SaveChangesAsync();
                return leave;
            }
            return null;
        }

        public async Task<Leave?> Get(int key)
        {
            var leave = await _context.Leaves.FirstOrDefaultAsync(l=>l.Id==key);
            return leave;
        }

        public async Task<ICollection<Leave>?> GetAll()
        {
            var leaves = await _context.Leaves.ToListAsync();
            if (leaves.Count > 0)
                return leaves;
            return null;
        }

        public async Task<Leave?> Update(Leave item)
        {
            var leave = await Get(item.Id);
            if (leave != null)
            {
                leave.Id = item.Id;
                leave.EmployeeId = item.EmployeeId;
                leave.StartDate = item.StartDate;
                leave.EndDate = item.EndDate;
                leave.Reason = item.Reason;
                leave.Status = item.Status;
                leave.CreatedAt = item.CreatedAt;
                leave.UpdatedAt = item.UpdatedAt;
                await _context.SaveChangesAsync();
                return leave;
            }
            return null;
        }
    }
}
