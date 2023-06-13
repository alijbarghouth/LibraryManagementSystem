using System.Net;

namespace Domain.Shared.Exceptions.CustomException;

public sealed class BadRequestException : LibraryException
{
    public BadRequestException(string message)
    {
        this.Message = message;
        StatusCode = HttpStatusCode.BadRequest;
    }
}
