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
using HrLeaveManagement.Application.Features.LeaveTypes.Request.Command;
using MediatR;

namespace HrLeaveManagement.Application.Features.LeaveTypes.Handler.Command
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validation = new CreateLeaveTypeValidations();
            var validationResult = await validation.ValidateAsync(request.LeaveTypeDTo);

            if (validationResult.IsValid==false)
            {
                throw new Exception();
            }

            var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDTo);
            leaveType = await _leaveTypeRepository.Add(leaveType);
            return leaveType.Id;
        }
    }
}
