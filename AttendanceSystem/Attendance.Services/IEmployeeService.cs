using Attendance.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Services
{
    public interface IEmployeeService
    {
        Task<Employee> Login(String Username, String Password);
        Task<Boolean> AddEmployees(List<Employee> employees);
    }
}
