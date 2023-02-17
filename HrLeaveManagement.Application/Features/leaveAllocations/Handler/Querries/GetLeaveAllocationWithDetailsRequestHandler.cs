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
    public class GetLeaveAllocationWithDetailsRequestHandler : IRequestHandler<GetLeaveAllocationWithDetailsRequest, LeaveAllocationDTO>
    {

        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;


        public GetLeaveAllocationWithDetailsRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<LeaveAllocationDTO> Handle(GetLeaveAllocationWithDetailsRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation =await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);
            if (leaveAllocation == null)
            {
                throw new Exception();
            }

            return _mapper.Map<LeaveAllocationDTO>(leaveAllocation);
        }
    }
}
