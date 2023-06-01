using System.Net;

namespace Domain.Shared.Exceptions.CustomException;

public sealed class NotFoundException : LibraryException
{
    public NotFoundException(string Message)
    {
        this.Message = Message;
        StatusCode = HttpStatusCode.NotFound;
    }
}
