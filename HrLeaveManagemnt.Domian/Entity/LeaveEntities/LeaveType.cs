using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hr.LeaveManagement.Domain.Entity.Common;

namespace Hr.LeaveManagement.Domain.Entity.LeaveEntities
{
    public class LeaveType:LeaveBaseEntity<int>
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
