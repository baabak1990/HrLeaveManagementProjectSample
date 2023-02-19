using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hr.LeaveManagement.Domain.Entity.LeaveEntities;
using Hr.Leavemanagement.Presistance.Context;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hr.Leavemanagement.Presistance.Repositories
{
    public class LeaveAllocationRepository:GenericRepository<LeaveAllocation> ,ILeaveAllocationRepository
    {
        private readonly LeaveManagementContext _context;

        public LeaveAllocationRepository(LeaveManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _context.LeaveAllocations
                .Include(e => e.LeaveTypeId)
                .FirstOrDefaultAsync(e=>e.Id==id);
            return leaveAllocation;
        }

        public async Task<List<LeaveAllocation>> GetListOfLeaveAllocationWithDetails()
        {
            var leaveAllocations = await _context.LeaveAllocations
                .Include(e => e.LeaveTypeId)
                .ToListAsync();
            return leaveAllocations;

        }
    }
}
