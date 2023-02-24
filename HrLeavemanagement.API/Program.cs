using Hr.Leavemanagement.Presistance.Context;
using Hr.Leavemanagement.Presistance.IoCConfigurations;
using Hr.LeaveManagementInfrastructure.IoCConfigurations;
using HrLeaveManagement.Application.IoCConfigurations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configuration();
builder.Services.ServicePresistanceConfigorationCollection(builder.Configuration);
builder.Services.ServicesConfiguration(builder.Configuration);





builder.Services.AddCors(o =>
{
    o.AddPolicy("CoresPolicy"
    , builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("CoresPolicy");
app.MapControllers();

app.Run();
