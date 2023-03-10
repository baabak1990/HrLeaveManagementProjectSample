using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrLeaveManagement.Application.DTOs.LeaveRequests;
using MediatR;

namespace HrLeaveManagement.Application.Features.LeaveRequests.Request.Querries
{
    public class GetLeaveRequestByIdRequest:IRequest<LeaveRequestDTO>
    {
        public int Id { get; set; }
    }
}
