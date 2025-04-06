using FluentValidation;
using Attendance.Data.Models;

namespace Attendance.Data.Validators
{
    public class DeveloperExtensionValidator : AbstractValidator<DeveloperExtension>
    {
        public DeveloperExtensionValidator()
        {
            RuleFor(x => x.Band)
                .IsInEnum().WithMessage("Band is required.");

            RuleFor(x => x.TechDirection)
                .NotEmpty().WithMessage("TechDirection is required.");
        }
    }
}