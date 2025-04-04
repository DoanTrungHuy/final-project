using Attendance.Data.Entites;
using Attendance.Data.Enums;
using Attendance.Data.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Services.Mapping
{
    public class EmployeeEntityMapper
    {
        public static EmployeeEntity MapToEntity(SqlDataReader reader)
        {
            return new EmployeeEntity
            {
                Id = reader["Id"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Username = reader["Username"].ToString(),
                Password = reader["Password"].ToString(),
                Sex = Convert.ToInt32(reader["Sex"]),
                Department = reader["Department"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString(),
                IsIntern = Convert.ToBoolean(reader["IsIntern"]),
                EmployeeType = Convert.ToInt32(reader["EmployeeType"]),
                Extension = reader["Extension"].ToString()
            };
        }
    }
}
