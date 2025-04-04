using FluentValidation;
using Attendance.Data.Models;

namespace Attendance.Data.Validators
{
    public class ManagerExtensionValidator : AbstractValidator<ManagerExtension>
    {
        public ManagerExtensionValidator()
        {
            RuleFor(x => x.ManagerType)
                .NotNull().WithMessage("ManagerType is required.");
        }
    }
}
