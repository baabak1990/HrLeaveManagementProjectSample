using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hr.LeaveManagement.Domain.Entity.LeaveEntities;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;
using HrLeaveManagement.Application.DTOs.LeaveTypes;
using HrLeaveManagement.Application.DTOs.LeaveTypes.Validations;
using HrLeaveManagement.Application.Exceptions;
using HrLeaveManagement.Application.Features.LeaveTypes.Request.Command;
using HrLeaveManagement.Application.Response;
using MediatR;

namespace HrLeaveManagement.Application.Features.LeaveTypes.Handler.Command
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validation = new CreateLeaveTypeValidations();
            var validationResult = await validation.ValidateAsync(request.LeaveTypeDTo);

            if (validationResult.IsValid==false)
            {
                
                response.Success = false;
                response.Message = "Failed To Create";
                response.Errors =  validationResult.Errors.Select(r => r.ErrorMessage).ToList();
            }

            var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDTo);
            leaveType = await _leaveTypeRepository.Add(leaveType);

            response.Success = true;
            response.Message = "Operation was successful";
            response.Id = request.LeaveTypeDTo.Id;

            return response;
        }
    }
}
