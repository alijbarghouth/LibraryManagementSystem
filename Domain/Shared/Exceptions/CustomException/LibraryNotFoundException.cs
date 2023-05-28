using System.Net;

namespace Domain.Shared.Exceptions.CustomException;

public sealed class LibraryNotFoundException : LibraryException
{
    public LibraryNotFoundException(string Message)
    {
        this.Message = Message;
        StatusCode = HttpStatusCode.NotFound;
    }
}
