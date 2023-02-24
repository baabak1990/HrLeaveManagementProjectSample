using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hr.Leavemanagement.Presistance.Configuration.LeaveRequest
{
    public class LeaveRequestConfig:IEntityTypeConfiguration<LeaveManagement.Domain.Entity.LeaveEntities.LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveManagement.Domain.Entity.LeaveEntities.LeaveRequest> builder)
        {
        }
    }
}
 