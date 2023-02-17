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
    public class GetListOfLeaveAllocationRequestWithDetailsHandler:IRequestHandler<GetListOfLeaveAllocationRequestWithDetails,List<LeaveAllocationDTO>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;


        public GetListOfLeaveAllocationRequestWithDetailsHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveAllocationDTO>> Handle(GetListOfLeaveAllocationRequestWithDetails request, CancellationToken cancellationToken)
        {
            var leaveAllocations= await _leaveAllocationRepository.GetAll();
            return _mapper.Map<List<LeaveAllocationDTO>>(leaveAllocations);
        }
    }
}
