using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace HrLeaveManagement.Application.DTOs.LeaveTypes.Validations
{
    public class IleaveTypeDTOValidaitor:AbstractValidator<IleaveTypeDTo>
    {
        public IleaveTypeDTOValidaitor()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("{PropertyName} Can`t be Null")
                .NotEmpty().WithMessage("{PropertyName} Can`t be Null")
                .MaximumLength(50).WithMessage("{PropertyName} should be less than {ComparisonValue}");

            RuleFor(p => p.DefaultDays)
                .LessThan(360).WithMessage("{PropertyName} Should be less Than {ComparisonValue}")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than {ComparisonValue}");
        }
    }
}
