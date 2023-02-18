namespace HrLeaveManagement.Application.DTOs.LeaveRequests;

public interface ILeaveRequestDTO
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime DateRequested { get; set; }
    public string RequestComments { get; set; }
    public int LeaveTypeId { get; set; }
}