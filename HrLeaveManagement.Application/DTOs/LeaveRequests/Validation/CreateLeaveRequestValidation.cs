using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;

namespace HrLeaveManagement.Application.DTOs.LeaveRequests.Validation
{
    public class CreateLeaveRequestValidation:AbstractValidator<LeaveRequestDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestValidation(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }
        public CreateLeaveRequestValidation()
        {
            Include(new ILeaveRequestValidation(_leaveTypeRepository));
            RuleFor(p => p.RequestComments)
                .NotEmpty().WithMessage("{PropertyName} Can`t Be Empty !!!")
                .MaximumLength(250);
        }
    }
}
