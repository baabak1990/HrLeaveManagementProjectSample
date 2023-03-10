using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hr.LeaveManagement.Domain.Entity.LeaveEntities;
using HrLeaveManagement.Application.DTOs.Common;

namespace HrLeaveManagement.Application.DTOs.LeaveRequests
{
    public class UpdateleaveRequestDTO : BaseDTO,ILeaveRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public int LeaveTypeId { get; set; }
    }
}
