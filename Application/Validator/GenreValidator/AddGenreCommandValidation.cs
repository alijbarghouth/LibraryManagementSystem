using Application.Command.BookGenreCommand;
using Application.Command.GenreCommand;
using FluentValidation;

namespace Application.Validator.GenreValidator;

public sealed class AddGenreCommandValidation : AbstractValidator<AddGenreCommand>
{
    public AddGenreCommandValidation()
    {
        RuleFor(x => x.Genre.Name)
             .NotEmpty().WithMessage("name is required.");
    }
}
