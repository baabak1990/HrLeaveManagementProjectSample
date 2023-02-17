using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hr.LeaveManagement.Domain.Entity.LeaveEntities;
using MediatR;

namespace HrLeaveManagement.Application.Features.LeaveRequests.Request.Command
{
    public class CreateLeaveRequestCommand:IRequest<int>
    {
        public LeaveRequest LeaveRequest { get; set; }
    }
}
