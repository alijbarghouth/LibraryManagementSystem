using Application.Command.ReportCommand;
using FluentValidation;

namespace Application.Validator.ReportValidator;

public sealed class AddReportCommandValidation : AbstractValidator<AddReportCommand>
{
    public AddReportCommandValidation()
    {
        RuleFor(x => x.Report.UserId)
           .NotEmpty().WithMessage("UserId is required.");
        RuleFor(x => x.Report.BookReviewId)
            .NotEmpty().WithMessage("BookReviewId is required.");
        RuleFor(x => x.Report.Massage)
                .NotEmpty().WithMessage("Massage is required.");
    }
}
