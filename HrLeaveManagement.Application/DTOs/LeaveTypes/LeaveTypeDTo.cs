using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrLeaveManagement.Application.DTOs.Common;

namespace HrLeaveManagement.Application.DTOs.LeaveTypes
{
    public class LeaveTypeDTo:BaseDTO,IleaveTypeDTo
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
