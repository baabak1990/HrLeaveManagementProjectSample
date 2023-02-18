using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Hr.LeaveManagement.Domain.Entity.LeaveEntities;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;
using HrLeaveManagement.Application.DTOs.LeaveTypes.Validations;
using HrLeaveManagement.Application.Exceptions;
using HrLeaveManagement.Application.Features.LeaveTypes.Request.Command;
using HrLeaveManagement.Application.Response;
using MediatR;
using ValidationException = HrLeaveManagement.Application.Exceptions.ValidationException;

namespace HrLeaveManagement.Application.Features.LeaveTypes.Handler.Command
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validation = new UpdateLeaveTypeValidation();
            var validationResult = await validation.ValidateAsync(request.LeaveTypeDTo);
            if (validationResult == null)
            {
                response.Success=false;
                response.Message = "Failed To Update";
                response.Errors = validationResult.Errors.Select(r => r.ErrorMessage).ToList();
                throw new ValidationException(validationResult);
            }

            var leaveType = await _leaveTypeRepository.Get(request.LeaveTypeDTo.Id);
            leaveType = _mapper.Map(request.LeaveTypeDTo, leaveType);
            await _leaveTypeRepository.Update(leaveType);

            response.Success = true;
            response.Id=request.LeaveTypeDTo.Id;
            response.Message = "Update was Successful";
            return response;

        }
    }
}
