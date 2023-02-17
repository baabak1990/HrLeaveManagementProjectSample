using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;
using HrLeaveManagement.Application.DTOs.LeaveAllocations;
using HrLeaveManagement.Application.Features.leaveAllocations.Request.Querries;
using MediatR;

namespace HrLeaveManagement.Application.Features.leaveAllocations.Handler.Querries
{
    public class GetLeaveAllocationByIdRequestHandler : IRequestHandler<GetLeaveAllocationByIdRequest, LeaveAllocationDTO>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationByIdRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<LeaveAllocationDTO> Handle(GetLeaveAllocationByIdRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.Get(request.Id);
            if (leaveAllocation == null)
            {
                throw new Exception();
            }
            return _mapper.Map<LeaveAllocationDTO>(leaveAllocation);


        }
    }
}
