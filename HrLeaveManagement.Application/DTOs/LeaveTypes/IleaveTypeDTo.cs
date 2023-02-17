namespace HrLeaveManagement.Application.DTOs.LeaveTypes;

public interface IleaveTypeDTo
{
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}