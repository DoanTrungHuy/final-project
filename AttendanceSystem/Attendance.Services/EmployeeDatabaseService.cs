using Attendance.Data.Models;
using Attendance.Services.Mapping;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Attendance.Data.Entites;

namespace Attendance.Services
{
    public class EmployeeDatabaseService : IEmployeeDatabaseService
    {
        public EmployeeDatabaseService()
        {
            
        }

        public async Task<bool> AddEmployees(List<Employee> employees)
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("Username", typeof(string));
            table.Columns.Add("Password", typeof(string));
            table.Columns.Add("Sex", typeof(int));
            table.Columns.Add("Department", typeof(string));
            table.Columns.Add("PhoneNumber", typeof(string));
            table.Columns.Add("IsIntern", typeof(bool));
            table.Columns.Add("Extension", typeof(string));
            table.Columns.Add("EmployeeType", typeof(int));

            foreach (var employee in employees.Select(e => EmployeeMapper.MapToEntity(e)))
            {
                table.Rows.Add(
                    employee.Id,
                    employee.FirstName,
                    employee.LastName,
                    employee.Username,
                    employee.Password,
                    employee.Sex,
                    employee.Department,
                    employee.PhoneNumber,
                    employee.IsIntern,
                    employee.Extension,
                    employee.EmployeeType
                );
            }

            using (var conn = await GetOpenedSqlConnectionAysnc())
            {
                await conn.OpenAsync();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "BatchAddEmployees";
                    cmd.Parameters.Add(new SqlParameter("employees", employees));
                    return await cmd.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        public async Task<Employee?> GetEmployeeByUserName(string username)
        {
            using (var conn = await GetOpenedSqlConnectionAysnc())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Employee WHERE Username = @Username";
                    cmd.Parameters.Add(new SqlParameter("Username", username));
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            EmployeeEntity entity = EmployeeEntityMapper.MapToEntity(reader);
                            return EmployeeMapper.MapToModel(entity);
                        }
                    }
                }
            }
            return null;
        }

        private async Task<SqlConnection> GetOpenedSqlConnectionAysnc()
        {
            var connectionBuilder = new SqlConnectionStringBuilder();
            connectionBuilder.DataSource = ".";
            connectionBuilder.InitialCatalog = "AttendanceSystem";
            connectionBuilder.TrustServerCertificate = true;
            var connection = new SqlConnection(connectionBuilder.ConnectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}