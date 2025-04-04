using Attendance.Data.Entites;
using Attendance.Data.Enums;
using Attendance.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Services.Mapping
{
    public class EmployeeMapper
    {
        public static Employee MapToModel(EmployeeEntity entity)
        {
            EmployeeExtension? extension = null;

            if (!String.IsNullOrEmpty(entity.Extension))
            {
                switch ((EmployeeType)entity.EmployeeType)
                {
                    case EmployeeType.Developer:
                    case EmployeeType.QualityAssurance:
                    case EmployeeType.Manager:
                        extension = JsonConvert.DeserializeObject(entity.Extension, new JsonSerializerSettings()
                        {
                            TypeNameHandling = TypeNameHandling.Auto
                        }) as EmployeeExtension;
                        break;
                }
            }

            return new Employee
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Username = entity.Username,
                Password = entity.Password,
                Sex = (Sex)entity.Sex,
                Department = entity.Department,
                PhoneNumber = entity.PhoneNumber,
                IsIntern = entity.IsIntern,
                Extension = extension,
                EmployeeType = (EmployeeType)entity.EmployeeType
            };
        }

        public static EmployeeEntity MapToEntity(Employee model)
        {
            return new EmployeeEntity
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = model.Password,
                Sex = (int)model.Sex,
                Department = model.Department,
                PhoneNumber = model.PhoneNumber,
                IsIntern = model.IsIntern,
                Extension = JsonConvert.SerializeObject(model.Extension),
                EmployeeType = (int)model.EmployeeType
            };
        }
    }
}
