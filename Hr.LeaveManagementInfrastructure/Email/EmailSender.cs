using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrLeaveManagement.Application.Contracts.Infrastructures;
using HrLeaveManagement.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Hr.LeaveManagementInfrastructure.Email
{
    public class EmailSender:IEmailSender
    {
        private EmailSetting _emailSetting { get; }

        //IOptions Is From Dependency.Extensions Library
        public EmailSender(IOptions<EmailSetting> emailSetting)
        {
            _emailSetting = emailSetting.Value;
        }
        public async Task<bool> SendEmail(HrLeaveManagement.Application.Models.Email email)
        {
            var client = new SendGridClient(_emailSetting.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _emailSetting.FromAddress,
                Name = _emailSetting.FromName
            };

            var massage = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(massage);

            return response.StatusCode==System.Net.HttpStatusCode.OK||response.StatusCode==System.Net.HttpStatusCode.Accepted;

        }
    }
}
