using Application.Query.AuthorQuery;
using FluentValidation;

namespace Application.Validator.AuthorBookValidator;

public sealed class GetAuthorByBookIdQueryValidation : AbstractValidator<GetAuthorByBookIdQuery>
{
    public GetAuthorByBookIdQueryValidation()
    {
        RuleFor(X => X.BookId)
           .NotEmpty().WithMessage("BookId is required.");
    }
}
