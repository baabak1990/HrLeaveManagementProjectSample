using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hr.LeaveManagement.Domain.Entity.LeaveEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hr.Leavemanagement.Presistance.Configuration.LeaveAllocationConfig
{
    public class LeaveAllocationConfiguration : IEntityTypeConfiguration<LeaveAllocation>
    {
        //There are so many different ways To Seed Data To SQL 
        //Here We Use This Way
        public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
        {
            builder.HasData(new LeaveAllocation()
            {
                LeaveTypeId = 1,
                Id = 1,
                NumberOfDays = 3,
                Period = 1
            }, new LeaveAllocation()
            {
                LeaveTypeId = 1,
                Id = 2,
                NumberOfDays = 5,
                Period = 2
            }
            );
        }
    }
}
