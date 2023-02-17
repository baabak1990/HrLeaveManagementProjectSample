using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrLeaveManagement.Application.DTOs.Common;
using HrLeaveManagement.Application.DTOs.LeaveTypes;

namespace HrLeaveManagement.Application.DTOs.LeaveRequests
{
    public class LeaveRequestListDTo:BaseDTO
    {
        public LeaveTypeDTo LeaveTypeDto { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
    }
}
