using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;
using HrLeaveManagement.Application.DTOs.LeaveRequests.Validation;
using HrLeaveManagement.Application.Features.LeaveRequests.Request.Command;
using MediatR;

namespace HrLeaveManagement.Application.Features.LeaveRequests.Handler.Command
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validation = new UpdateLeaveRequestValidation(_leaveTypeRepository, _leaveRequestRepository);
            var validator = await validation.ValidateAsync(request.LeaveRequestDto);
            if (validator.IsValid == false)
            {
                throw new Exception();
            }
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestsWithDetails(request.id);
            if (request.LeaveRequestDto != null)
            {
                _mapper.Map(request.LeaveRequestDto, leaveRequest);
                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if (request.ChangeleaveRequestApprovalDto != null)
            {
                await _leaveRequestRepository.ChangerequestAppove(leaveRequest, 
                      request.ChangeleaveRequestApprovalDto.Approved);
            }
            return Unit.Value;
        }
    }
}
