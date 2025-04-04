using Attendance.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Data.Models
{
    public class DeveloperExtension : EmployeeExtension
    {
        public Band Band { get; set; }
        public String TechDirection { get; set; }
    }
}
