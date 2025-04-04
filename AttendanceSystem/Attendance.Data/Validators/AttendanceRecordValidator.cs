using FluentValidation;
using Attendance.Data.Models;

namespace Attendance.Data.Validators
{
    public class AttendanceRecordValidator : AbstractValidator<AttendanceRecord>
    {
        public AttendanceRecordValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty().WithMessage("Id is required.")
                .Length(1, 50).WithMessage("Id must be between 1 and 50 characters.");

            RuleFor(x => x.EmployeeId)
                .NotNull()
                .NotEmpty().WithMessage("EmployeeId is required.")
                .Length(1, 50).WithMessage("EmployeeId must be between 1 and 50 characters.");

            RuleFor(x => x.Data)
                .NotNull()
                .GreaterThan(0).WithMessage("Data must be a positive value.");

            RuleFor(x => x.ArrivalTime)
                .NotNull()
                .GreaterThan(0).WithMessage("ArrivalTime must be a valid timestamp.");

            RuleFor(x => x.LeaveTime)
                .NotNull()
                .GreaterThan(0).WithMessage("LeaveTime must be a valid timestamp.");

            RuleFor(x => new { x.ArrivalTime, x.LeaveTime })
                .NotNull()
                .Must(x => x.ArrivalTime < x.LeaveTime)
                .WithMessage("ArrivalTime must be earlier than LeaveTime.");
        }
    }
}