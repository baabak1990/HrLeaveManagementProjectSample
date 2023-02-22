using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hr.Leavemanagement.Presistance.Context;
using Hr.Leavemanagement.Presistance.Repositories;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hr.Leavemanagement.Presistance.IoCConfigurations
{
    public static class servicePresistanceConfig
    {
        public static IServiceCollection ServicePresistanceConfigorationCollection(this IServiceCollection services, IConfiguration configuration)
        {
            //Adding ConnectionStrings
            services.AddDbContext<LeaveManagementContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("HrDatabaseConnectionString")));



            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository,LeaveTypeRepository>();
            services.AddScoped<ILeaveAllocationRepository,LeaveAllocationRepository>();
            services.AddScoped<ILeaveRequestRepository,LeaveRequestRepository>();



            return services;
        }
    }
}
