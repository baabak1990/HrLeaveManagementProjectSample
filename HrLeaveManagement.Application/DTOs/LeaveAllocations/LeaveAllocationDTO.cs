using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hr.LeaveManagement.Domain.Entity.LeaveEntities;
using HrLeaveManagement.Application.DTOs.Common;
using HrLeaveManagement.Application.DTOs.LeaveTypes;

namespace HrLeaveManagement.Application.DTOs.LeaveAllocations
{
    public class LeaveAllocationDTO:BaseDTO
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDTo LeaveTypeDTo { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
