using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HrLeaveManagement.Application.Features.LeaveTypes.Request.Command
{
    public class  DeleteLeaveTypeCommand:IRequest<Unit>
    {
        public int id { get; set; }
    }
}
