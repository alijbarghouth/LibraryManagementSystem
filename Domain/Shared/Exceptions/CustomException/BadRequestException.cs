using System.Net;

namespace Domain.Shared.Exceptions.CustomException;

public sealed class BadRequestException : LibraryException
{
    public BadRequestException(string Message)
    {
        this.Message = Message;
        StatusCode = HttpStatusCode.BadRequest;
    }
}
