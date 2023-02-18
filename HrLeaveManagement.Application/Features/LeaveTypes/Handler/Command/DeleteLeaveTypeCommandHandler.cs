using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;
using HrLeaveManagement.Application.Exceptions;
using HrLeaveManagement.Application.Features.LeaveTypes.Request.Command;
using MediatR;

namespace HrLeaveManagement.Application.Features.LeaveTypes.Handler.Command
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leavetype = await _leaveTypeRepository.Get(request.id);
            if (leavetype == null)
            {
                throw new NotFoundException(nameof(leavetype),request.id);
            }

            await _leaveTypeRepository.Delete(leavetype);
            return Unit.Value;
        }
    }
}
