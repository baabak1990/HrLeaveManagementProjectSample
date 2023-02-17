using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrLeaveManagement.Application.DTOs.Common;

namespace HrLeaveManagement.Application.DTOs.LeaveRequests
{
    public class ChangeleaveRequestApprovalDTO:BaseDTO
    {
        public bool? Approved { get; set; }
    }
}
