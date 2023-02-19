using HrLeaveManagement.Application.Models;

namespace HrLeaveManagement.Application.Contracts.Infrastructures;

public interface IEmailSender
{
    Task<bool> SendEmail(Email email);
}