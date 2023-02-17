using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;
using HrLeaveManagement.Application.DTOs.LeaveRequests;
using HrLeaveManagement.Application.Features.LeaveRequests.Request.Querries;
using MediatR;

namespace HrLeaveManagement.Application.Features.LeaveRequests.Handler.Querries
{
    public class GetListOfLeaveRequestRequestHandler:IRequestHandler<GetListOfLeaveRequestRequest,List<LeaveRequestDTO>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetListOfLeaveRequestRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveRequestDTO>> Handle(GetListOfLeaveRequestRequest request, CancellationToken cancellationToken)
        {
           var leaveRequests=_leaveRequestRepository.GetAll();
           return _mapper.Map<List<LeaveRequestDTO>>(leaveRequests);
        }
    }
}
