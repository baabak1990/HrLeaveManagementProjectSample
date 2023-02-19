using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hr.LeaveManagement.Domain.Entity.LeaveEntities;
using HrLeaveManagement.Application.Contracts.Infrastructures;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;
using HrLeaveManagement.Application.DTOs.LeaveRequests.Validation;
using HrLeaveManagement.Application.Features.LeaveRequests.Request.Command;
using HrLeaveManagement.Application.Models;
using MediatR;

namespace HrLeaveManagement.Application.Features.LeaveRequests.Handler.Command
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IEmailSender emailSender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
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

            var email = new Email
            {
                To = "Some sample Email",
                Body =
                    $"Your Leave Request for {request.LeaveRequest.StartDate:D} to {request.LeaveRequest.EndDate:D} Is Submitted SuccessFully !",
                Subject = "Leave Request Submitted !"
            };
            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception e)
            {
               //ToDO : Log Or Handle Error ;
            }

            return leaveRequest.Id;
        }
    }
}
