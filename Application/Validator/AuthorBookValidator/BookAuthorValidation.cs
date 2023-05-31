using Application.Command.BookAuthorCommand;
using FluentValidation;

namespace Application.Validator.AuthorBookValidator;

public sealed class BookAuthorValidation : AbstractValidator<BookAuthorCommand>
{
    public BookAuthorValidation()
    {
        RuleFor(X => X.BookAuthor.AuthorName)
            .NotEmpty().WithMessage("AuthorName is required.");
        RuleFor(X => X.BookAuthor.BookName)
            .NotEmpty().WithMessage("BookName is required.");
    }
}
