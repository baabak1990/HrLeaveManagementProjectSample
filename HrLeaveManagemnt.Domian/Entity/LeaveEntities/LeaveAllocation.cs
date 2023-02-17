using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Hr.LeaveManagement.Domain.Entity.Common;

namespace Hr.LeaveManagement.Domain.Entity.LeaveEntities
{
    public class LeaveAllocation : LeaveBaseEntity<int>
    {
        public int NumberOfDays { get; set; }
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }

    }
}
