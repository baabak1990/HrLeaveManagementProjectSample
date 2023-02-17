using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace HrLeaveManagement.Application.DTOs.LeaveTypes.Validations
{
   
    public class CreateLeaveTypeValidations:AbstractValidator<LeaveTypeDTo>
    {
        public CreateLeaveTypeValidations()
        {
         Include(new IleaveTypeDTOValidaitor());
        }
    }
}
