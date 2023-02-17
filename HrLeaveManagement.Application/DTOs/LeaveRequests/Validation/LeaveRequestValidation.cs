using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;

namespace HrLeaveManagement.Application.DTOs.LeaveRequests.Validation
{
    public class LeaveRequestValidation:AbstractValidator<LeaveRequestDTO>
    {  private readonly ILeaveTypeRepository _leaveTypeRepository;
        public LeaveRequestValidation(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} Should be before the {ComparisonValue}");

            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} Should be After {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveISExist = await _leaveTypeRepository.IsExistById(id);
                    return !leaveISExist;
                }).WithMessage("{PropertyName} Is not Exist !!");

        }
    }
}
