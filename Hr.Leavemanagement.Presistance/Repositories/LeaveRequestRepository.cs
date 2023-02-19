using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hr.LeaveManagement.Domain.Entity.LeaveEntities;
using Hr.Leavemanagement.Presistance.Context;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;
using HrLeaveManagement.Application.DTOs.LeaveRequests;
using Microsoft.EntityFrameworkCore;

namespace Hr.Leavemanagement.Presistance.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementContext _context;
        public LeaveRequestRepository(LeaveManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<LeaveRequest>> GetListOfLeaveRequestsWithDetails()
        {
            var leaveRequests=await _context.LeaveRequests
                .Include(e=>e.LeaveTypeId)
                .ToListAsync();
            return leaveRequests;
        }

        

       public async Task<LeaveRequest> GetLeaveRequestsWithDetails(int id)
       {
           var leaveRequest = await _context.LeaveRequests
               .Include(e => e.LeaveTypeId)
               .FirstOrDefaultAsync(e => e.Id == id);
           return leaveRequest;
       }

        public async Task ChangerequestAppove(LeaveRequest request, bool? IsApproved)
        {
            request.Approved = IsApproved;
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
