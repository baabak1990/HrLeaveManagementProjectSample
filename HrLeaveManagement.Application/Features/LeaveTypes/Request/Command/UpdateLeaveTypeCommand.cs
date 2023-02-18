using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrLeaveManagement.Application.DTOs.LeaveTypes;
using HrLeaveManagement.Application.Response;
using MediatR;

namespace HrLeaveManagement.Application.Features.LeaveTypes.Request.Command
{
    public class UpdateLeaveTypeCommand:IRequest<BaseCommandResponse>
    {
        public LeaveTypeDTo LeaveTypeDTo { get; set; }
    }
}
