using Hr.LeaveManagement.Domain.Entity.LeaveEntities;

namespace HrLeaveManagement.Application.Contracts.Presistence.Repositories;

public interface ILeaveAllocationRepository:IGenericRepository<LeaveAllocation>
{
    Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
    Task<List<LeaveAllocation>> GetListOfLeaveAllocationWithDetails();
}