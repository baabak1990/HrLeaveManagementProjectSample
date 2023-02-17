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
    public class GetLeaveTypeRequestHandler:IRequestHandler<GetLeaveTypeRequest,LeaveTypeDTo>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<LeaveTypeDTo> Handle(GetLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var leavetype = await _leaveTypeRepository.Get(request.Id);
            if (leavetype == null)
            {
                throw new Exception();
            }

            return _mapper.Map<LeaveTypeDTo>(leavetype);
        }
    }
}
