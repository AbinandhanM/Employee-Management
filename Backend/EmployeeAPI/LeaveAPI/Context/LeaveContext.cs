using LeaveAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveAPI.Context
{
    public class LeaveContext:DbContext
    {
        public LeaveContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Leave> Leaves { get; set; }
    }
}
