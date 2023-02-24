using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hr.LeaveManagement.Domain.Entity.Common;
using Hr.LeaveManagement.Domain.Entity.LeaveEntities;
using Microsoft.EntityFrameworkCore;

namespace Hr.Leavemanagement.Presistance.Context
{
    public class LeaveManagementContext:DbContext
    {
        public LeaveManagementContext(DbContextOptions<LeaveManagementContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<LeaveBaseEntity<int>>())
            {
                entry.Entity.ModifyDate = DateTime.Now;
                if (entry.State==EntityState.Added)
                {
                    entry.Entity.CreateDate = DateTime.Now;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        #region Dbset

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        #endregion
    }
}
