
using Attendance.Data.Models;
using Attendance.Data.Validators;
using Attendance.Services;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Attendance.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                });
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IValidator<Employee>, EmployeeValidator>();
            builder.Services.AddScoped<IValidator<ManagerExtension>, ManagerExtensionValidator>();
            builder.Services.AddScoped<IValidator<DeveloperExtension>, DeveloperExtensionValidator>();
            builder.Services.AddScoped<IValidator<QualityAssuranceExtension>, QualityAssuranceExtensionValidator>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
