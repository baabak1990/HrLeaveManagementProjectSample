using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrLeaveManagement.Application.DTOs.LeaveAllocations;
using MediatR;

namespace HrLeaveManagement.Application.Features.leaveAllocations.Request.Command
{
    public class CreateLeaveAllocationCommand:IRequest<int>
    {
        public LeaveAllocationDTO LeaveAllocationDto { get; set; }
    }
}
