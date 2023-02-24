using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hr.LeaveManagement.Domain.Entity.LeaveEntities;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;
using HrLeaveManagement.Application.DTOs.LeaveAllocations.Validations;
using HrLeaveManagement.Application.Features.leaveAllocations.Request.Command;
using HrLeaveManagement.Application.Models;
using HrLeaveManagement.Application.Response;
using MediatR;

namespace HrLeaveManagement.Application.Features.leaveAllocations.Handler.Command
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
          private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;


        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validation = new LeaveAllocationValidation(_leaveTypeRepository);
            var validationResult =await validation.ValidateAsync(request.LeaveAllocationDto);

            if (validationResult.IsValid==false)
            {
                response.Success = false;
                response.Message = "Some Errors occurred During Creation";
                response.Errors=validationResult.Errors.Select(e=>e.ErrorMessage).ToList();

            }
            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);
            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);
         
            response.Success = true;
            response.Message = "Operation Complete !";
            response.Id = leaveAllocation.Id;

            return response.Id;
        }
    }
}
