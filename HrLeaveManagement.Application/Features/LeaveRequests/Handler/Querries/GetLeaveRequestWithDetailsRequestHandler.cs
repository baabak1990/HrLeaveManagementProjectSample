﻿using System;
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
    public class GetLeaveRequestWithDetailsRequestHandler:IRequestHandler<GetLeaveRequestWithDetailsRequest,LeaveRequestDTO>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestWithDetailsRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDTO> Handle(GetLeaveRequestWithDetailsRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = _leaveRequestRepository.GetLeaveRequestsWithDetails(request.Id);
            if (leaveRequest == null)
            {
                throw new Exception();
            }

            return _mapper.Map<LeaveRequestDTO>(leaveRequest);
        }
    }
}
