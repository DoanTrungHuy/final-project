using Attendance.Data.Enums;
using Attendance.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Data.Entites
{
    public class EmployeeEntity
    {
        public String Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public Int32 Sex { get; set; }
        public String Department { get; set; }
        public String PhoneNumber { get; set; }
        public Boolean IsIntern { get; set; }
        public String Extension { get; set; }
        public Int32 EmployeeType { get; set; }
    }
}
