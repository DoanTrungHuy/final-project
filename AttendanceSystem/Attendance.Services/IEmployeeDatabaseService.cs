using Attendance.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Services
{
    interface IEmployeeDatabaseService
    {
        public Task<Employee> GetEmployeeByUserName(string username);
        public Task<Boolean> AddEmployees(List<Employee> employees);
    }
}
