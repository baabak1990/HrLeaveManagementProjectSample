using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrLeaveManagement.Application.DTOs.LeaveRequests;
using MediatR;

namespace HrLeaveManagement.Application.Features.LeaveRequests.Request.Command
{
    public class UpdateLeaveRequestCommand:IRequest<Unit>
    {
        public int id { get; set; }
        public LeaveRequestDTO LeaveRequestDto { get; set; }
        public ChangeleaveRequestApprovalDTO ChangeleaveRequestApprovalDto { get; set; }

    }
}
