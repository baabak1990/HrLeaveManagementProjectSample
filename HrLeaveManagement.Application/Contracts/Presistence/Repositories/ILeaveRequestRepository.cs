using System.Diagnostics;
using Hr.LeaveManagement.Domain.Entity.LeaveEntities;

namespace HrLeaveManagement.Application.Contracts.Presistence.Repositories;

public interface ILeaveRequestRepository:IGenericRepository<LeaveRequest>
{
    Task<List<LeaveRequest>> GetListOfLeaveRequestsWithDetails();
    Task<LeaveRequest> GetLeaveRequestsWithDetails(int id);
    Task ChangerequestAppove(LeaveRequest request,bool? IsApproved);
}