using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HrLeaveManagement.Application.Features.leaveAllocations.Request.Command
{
    public class DeleteLeaveAllocationCommand:IRequest<Unit>
    {
        public int id { get; set; }
    }
}
