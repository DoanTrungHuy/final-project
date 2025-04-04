using Attendance.Data.Models;
using Attendance.Data.Validators;
using Attendance.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Attendance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> logger;
        private readonly IEmployeeService employeeService;
        private readonly IValidator<Employee> validator;

        public EmployeeController(
            ILogger<EmployeeController> logger, 
            IEmployeeService employeeService,
            IValidator<Employee> validator
            )
        {
            this.logger = logger;
            this.employeeService = employeeService;
            this.validator = validator;
        }

        [HttpPost("Login")]
        public Task<IActionResult> login()
        {
            throw new NotImplementedException();
        }

        [HttpPost("")]
        public async Task<IActionResult> ImportEmployees([FromBody] List<Employee> employees)
        {
            var validationResults = await Task.WhenAll(employees.Select(async employee =>
            {
                var validationResult = await validator.ValidateAsync(employee);
                return new { Employee = employee, Errors = validationResult.Errors };
            }));

            var allFailures = validationResults.Where(vr => vr.Errors.Any()).ToList();

            if (allFailures.Any())
            {
                return BadRequest(new
                {
                    Status = "error",
                    Message = "Invalid employee data",
                    Errors = allFailures.Select(f => new
                    {
                        Employee = f.Employee,
                        ValidationErrors = f.Errors.Select(e => new
                        {
                            Field = e.PropertyName,
                            Message = e.ErrorMessage
                        })
                    })
                });
            }

            return Ok(new { Status = "success", Message = "Employees successfully imported." });
        }

    }
}
