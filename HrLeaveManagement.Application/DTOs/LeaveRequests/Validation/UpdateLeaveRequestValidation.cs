using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;

namespace HrLeaveManagement.Application.DTOs.LeaveRequests.Validation
{
    public class UpdateLeaveRequestValidation:AbstractValidator<LeaveRequestDTO>
    {
          private readonly ILeaveTypeRepository _leaveTypeRepository;
          private readonly ILeaveRequestRepository _leaveRequestRepository;
        public UpdateLeaveRequestValidation(ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;
            Include(new ILeaveRequestValidation(_leaveTypeRepository));
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("{PropertyName} Should be Greater Than {ComparisonValue}")
                .MustAsync(async (id, token) =>
                {
                    var leaveRequest = await _leaveRequestRepository.IsExistById(id);
                    return !leaveRequest;
                }).WithMessage("{PropertyName} Is Not Exist !!!!");
        }
    }
}
