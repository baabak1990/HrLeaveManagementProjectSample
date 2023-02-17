using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;

namespace HrLeaveManagement.Application.DTOs.LeaveAllocations.Validations
{
    public class LeaveAllocationValidation:AbstractValidator<LeaveAllocationDTO>
    {
          private readonly ILeaveTypeRepository _leaveTypeRepository;
        public LeaveAllocationValidation(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            RuleFor(p => p.NumberOfDays)
                .NotEmpty().WithMessage("{PropertyName} Can`t Be Empty")
                .NotNull().WithMessage("{PropertyName} Can`t Be Null")
                .GreaterThan(0).WithMessage("{PropertyName} Can`t be Equal To {ComparisonValue}")
                .LessThan(25).WithMessage("{PropertyName} Should be less than {ComparisonValue}");


            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leavetype = await _leaveTypeRepository.IsExistById(id);
                    return !leavetype;
                }).WithMessage("{PropertyName} Is Not ");
        }
    }
}
