using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;
using HrLeaveManagement.Application.DTOs.LeaveTypes;
using HrLeaveManagement.Application.Features.LeaveTypes.Request.Querries;
using MediatR;

namespace HrLeaveManagement.Application.Features.LeaveTypes.Handler.Querries
{
    public class GetLeaveTypeDToListRequestHandler : IRequestHandler<GetLeaveTypeDToListRequest, List<LeaveTypeDTo>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDToListRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveTypeDTo>> Handle(GetLeaveTypeDToListRequest request, CancellationToken cancellationToken)
        {
            var leavetypes = await _leaveTypeRepository.GetAll();
            return _mapper.Map<List<LeaveTypeDTo>>(leavetypes);
        }
    }
}
