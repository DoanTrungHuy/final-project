using FluentValidation;
using Attendance.Data.Models;
using Attendance.Data.Enums;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using Attendance.Data.Entites;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;
using System.Text.Json;

namespace Attendance.Data.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id is required")
            .Length(1, 50).WithMessage("Id must be between 1 and 50 characters");

            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty().WithMessage("First Name is required")
                .Length(1, 50).WithMessage("First Name must be at most 50 characters");

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty().WithMessage("Last Name is required")
                .Length(1, 50).WithMessage("Last Name must be at most 50 characters");

            RuleFor(x => x.Username)
                .NotNull()
                .NotEmpty().WithMessage("Username is required")
                .Length(1, 50).WithMessage("Username must be at most 50 characters");

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty().WithMessage("Password is required")
                .Length(8, 255).WithMessage("Password must be at least 8 characters long.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.")
                .Matches(@"[\W]").WithMessage("Password must contain at least one special character.");

            RuleFor(x => x.Sex)
                .NotNull()
                .IsInEnum().WithMessage("Sex must be 0 (Male) and 1 (Female)");

            RuleFor(x => x.EmployeeType)
                .NotNull()
                .IsInEnum().WithMessage("Invalid EmployeeType value.");

            RuleFor(x => x)
                .NotNull().WithMessage("Extension is required")
                .Custom((request, context) =>
                {
                    if (request.Extension == null)
                    {
                        context.AddFailure("Extension", "Extension is required");
                        return;
                    }

                    FluentValidation.Results.ValidationResult result = null;

                    switch (request.EmployeeType)
                    {
                        case EmployeeType.Developer:
                            var devExtension = JsonSerializer.Deserialize<DeveloperExtension>(
                                JsonSerializer.Serialize(request.Extension));
                            Console.WriteLine("🛠️ Mapping to DeveloperExtension: " + JsonSerializer.Serialize(devExtension));
                            if (devExtension != null)
                            {
                                var devValidator = new DeveloperExtensionValidator();
                                result = devValidator.Validate(devExtension);
                            }
                            else
                            {
                                context.AddFailure("Extension", "Extension must be of type DeveloperExtension");
                            }
                            break;

                        case EmployeeType.QualityAssurance:
                            var qaExtension = JsonSerializer.Deserialize<QualityAssuranceExtension>(
                                JsonSerializer.Serialize(request.Extension));
                            Console.WriteLine("🧪 Mapping to QAExtension: " + JsonSerializer.Serialize(qaExtension));
                            if (qaExtension != null)
                            {
                                var qaValidator = new QualityAssuranceExtensionValidator();
                                result = qaValidator.Validate(qaExtension);
                            }
                            else
                            {
                                context.AddFailure("Extension", "Extension must be of type QualityAssuranceExtension");
                            }
                            break;

                        case EmployeeType.Manager:
                            var managerExtension = JsonSerializer.Deserialize<ManagerExtension>(
                                JsonSerializer.Serialize(request.Extension));
                            Console.WriteLine("📋 Mapping to ManagerExtension: " + JsonSerializer.Serialize(managerExtension));
                            if (managerExtension != null)
                            {
                                var managerValidator = new ManagerExtensionValidator();
                                result = managerValidator.Validate(managerExtension);
                            }
                            else
                            {
                                context.AddFailure("Extension", "Extension must be of type ManagerExtension");
                            }
                            break;

                        default:
                            context.AddFailure("EmployeeType", "Invalid employee type.");
                            break;
                    }

                    if (result != null && !result.IsValid)
                    {
                        foreach (var failure in result.Errors)
                        {
                            context.AddFailure(failure);
                        }
                    }
                });



            RuleFor(x => x.IsIntern)
               .NotNull().WithMessage("Intern status must be specified");
        }
    }
}