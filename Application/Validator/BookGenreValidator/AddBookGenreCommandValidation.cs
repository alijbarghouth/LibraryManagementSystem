using Application.Command.BookGenreCommand;
using FluentValidation;

namespace Application.Validator.BookGenreValidator;

public sealed class AddBookGenreCommandValidation : AbstractValidator<AddBookGenreCommand>
{
    public AddBookGenreCommandValidation()
    {
        RuleFor(x => x.BookGenre.BookName)
            .NotEmpty().WithMessage("BookName is required.");
        RuleFor(x => x.BookGenre.Genre)
            .NotEmpty().WithMessage("Genre is required.");
    }
}