using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hr.LeaveManagement.Domain.Entity.LeaveEntities;
using Hr.Leavemanagement.Presistance.Context;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;

namespace Hr.Leavemanagement.Presistance.Repositories
{
    public class LeaveTypeRepository:GenericRepository<LeaveType> , ILeaveTypeRepository
    {
        public LeaveTypeRepository(LeaveManagementContext context) : base(context)
        {
        }
    }
}
