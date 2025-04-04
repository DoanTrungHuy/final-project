using FluentValidation;
using Attendance.Data.Models;
using Attendance.Data.Enums;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;

namespace Attendance.Data.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator(ILogger<EmployeeValidator> logger)
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

            //RuleFor(x => x.Extension)
            //    .NotNull().WithMessage("Extension is required")
            //    .Custom((extension, context) =>
            //    {
            //        if (extension is ManagerExtension managerExtension)
            //        {
            //            var validator = new ManagerExtensionValidator();
            //            var result = validator.Validate(managerExtension);
            //            if (!result.IsValid)
            //            {
            //                foreach (var failure in result.Errors)
            //                {
            //                    context.AddFailure(failure);
            //                }
            //            }
            //        }
            //        else if (extension is DeveloperExtension developerExtension)
            //        {
            //            var validator = new DeveloperExtensionValidator();
            //            var result = validator.Validate(developerExtension);
            //            if (!result.IsValid)
            //            {
            //                foreach (var failure in result.Errors)
            //                {
            //                    context.AddFailure(failure);
            //                }
            //            }
            //        }
            //        else if (extension is QualityAssuranceExtension qaExtension)
            //        {
            //            var validator = new QualityAssuranceExtensionValidator();
            //            var result = validator.Validate(qaExtension);
            //            if (!result.IsValid)
            //            {
            //                foreach (var failure in result.Errors)
            //                {
            //                    context.AddFailure(failure);
            //                }
            //            }
            //        }
            //        else
            //        {
            //            context.AddFailure("Invalid extension type.");
            //        }
            //    });

            RuleFor(x => x.IsIntern)
               .NotNull().WithMessage("Intern status must be specified");
        }
    }
}