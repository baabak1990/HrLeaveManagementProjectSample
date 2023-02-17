using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.DTOs.LeaveTypes
{
    public class CreateLeaveTypeDTO:IleaveTypeDTo
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
