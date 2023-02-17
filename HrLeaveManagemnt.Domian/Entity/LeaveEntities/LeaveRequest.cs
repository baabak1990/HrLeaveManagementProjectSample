using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Hr.LeaveManagement.Domain.Entity.Common;

namespace Hr.LeaveManagement.Domain.Entity.LeaveEntities
{
    public class LeaveRequest:LeaveBaseEntity<int>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set;}
        public string RequestComments { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }
        public bool? Cancelled { get; set; }

    }
}
