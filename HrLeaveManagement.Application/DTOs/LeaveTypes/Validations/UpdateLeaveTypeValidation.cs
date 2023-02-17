using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace HrLeaveManagement.Application.DTOs.LeaveTypes.Validations
{
    public class UpdateLeaveTypeValidation:AbstractValidator<LeaveTypeDTo>
    {
        public UpdateLeaveTypeValidation()
        {
            Include(new IleaveTypeDTOValidaitor());
            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} Can`t be Null");
        }
    }
}
