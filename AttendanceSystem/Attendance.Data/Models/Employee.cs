using Attendance.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Data.Models
{
    public class Employee
    {
        public String Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public Sex Sex { get; set; }
        public String Department { get; set; }
        public String PhoneNumber { get; set; }
        public Boolean IsIntern { get; set; }
        public EmployeeExtension Extension { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
