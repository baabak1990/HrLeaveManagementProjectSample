using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hr.LeaveManagementInfrastructure.Email;
using HrLeaveManagement.Application.Contracts.Infrastructures;
using HrLeaveManagement.Application.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hr.LeaveManagementInfrastructure.IoCConfigurations
{
    public static class ConfigInfrastructureServices
    {
        public static IServiceCollection ServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSetting>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            //
            return services;
        }
    }
}
