using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HrLeaveManagement.Application.Features.LeaveRequests.Request.Command
{
    public class DeleteLeaveRequestCommand:IRequest<Unit>
    {
        public int id { get; set; }
    }
}
