using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hr.LeaveManagement.Domain.Entity.LeaveEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hr.Leavemanagement.Presistance.Configuration.LeaveTypeConfig
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(new LeaveType()
                {
                    Id = 1,
                    Name = "vacation",
                    DefaultDays = 10
                },
                new LeaveType()
                {
                    Id = 2,
                    Name = "Sick",
                    DefaultDays = 11
                }
            );
        }
    }
}
