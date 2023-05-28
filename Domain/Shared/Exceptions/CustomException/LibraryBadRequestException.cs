using System.Net;

namespace Domain.Shared.Exceptions.CustomException;

public sealed class LibraryBadRequestException : LibraryException
{
    public LibraryBadRequestException(string Message)
    {
        this.Message = Message;
        StatusCode = HttpStatusCode.NotFound;
    }
}
