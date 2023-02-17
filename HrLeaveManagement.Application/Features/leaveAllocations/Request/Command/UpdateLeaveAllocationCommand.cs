using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using HrLeaveManagement.Application.DTOs.LeaveAllocations;
using MediatR;

namespace HrLeaveManagement.Application.Features.leaveAllocations.Request.Command
{
    public class UpdateLeaveAllocationCommand:IRequest<Unit>
    {
        public LeaveAllocationDTO LeaveAllocationDto { get; set; }
    }
}
