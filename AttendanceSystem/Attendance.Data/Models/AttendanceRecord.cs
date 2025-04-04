using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Data.Models
{
    public class AttendanceRecord
    {
        public String Id { get; set; }
        public String EmployeeId { get; set; }
        public Int64 Data { get; set; }
        public Int64 ArrivalTime { get; set; }
        public Int64 LeaveTime { get; set; }
    }
}
