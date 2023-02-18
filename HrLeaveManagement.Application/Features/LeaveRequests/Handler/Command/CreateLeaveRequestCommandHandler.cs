using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hr.LeaveManagement.Domain.Entity.LeaveEntities;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;
using HrLeaveManagement.Application.DTOs.LeaveRequests.Validation;
using HrLeaveManagement.Application.Features.LeaveRequests.Request.Command;
using MediatR;

namespace HrLeaveManagement.Application.Features.LeaveRequests.Handler.Command
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }


        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validation = new CreateLeaveRequestValidation(_leaveTypeRepository);
            var validationResult =await validation.ValidateAsync(request.LeaveRequest);
            if (validationResult.IsValid==false)
            {
                throw new Exception();
            }
            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequest);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
            return leaveRequest.Id;
        }
    }
}
