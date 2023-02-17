using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrLeaveManagement.Application.DTOs.Common;
using HrLeaveManagement.Application.DTOs.LeaveTypes;

namespace HrLeaveManagement.Application.DTOs.LeaveRequests
{
    public class LeaveRequestDTO:BaseDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveTypeDTo LeaveTypeDto { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }
        public bool? Cancelled { get; set; }
    }
}
