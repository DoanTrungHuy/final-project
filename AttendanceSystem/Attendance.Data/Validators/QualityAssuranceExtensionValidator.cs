using Attendance.Data.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Data.Validators
{
    public class QualityAssuranceExtensionValidator : AbstractValidator<QualityAssuranceExtension>
    {
        public QualityAssuranceExtensionValidator()
        {
            RuleFor(x => x.Band)
                .IsInEnum().WithMessage("Band is required.");


            RuleFor(x => x.CanWriteCode)
                .NotNull().WithMessage("CanWriteCode is required.");
        }
    }
}
