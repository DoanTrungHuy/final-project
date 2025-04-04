using Attendance.Data.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger<EmployeeService> logger;

        public EmployeeService(ILogger<EmployeeService> logger)
        {
            this.logger = logger;
        }
        Task<bool> IEmployeeService.AddEmployees(List<Employee> employees)
        {
            throw new NotImplementedException();
        }

        Task<Employee> IEmployeeService.Login(string Username, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
