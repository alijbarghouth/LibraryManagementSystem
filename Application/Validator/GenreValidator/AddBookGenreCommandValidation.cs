using Application.Command.GenreCommand;
using FluentValidation;

namespace Application.Validator.GenreValidator;

public sealed class AddBookGenreCommandValidation : AbstractValidator<AddBookGenreCommand>
{
    public AddBookGenreCommandValidation()
    {
        RuleFor(x => x.Genre.Name)
             .NotEmpty().WithMessage("name is required.");
    }
}
