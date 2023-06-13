using System.Net;

namespace Domain.Shared.Exceptions.CustomException;

public sealed class NotFoundException : LibraryException
{
    public NotFoundException(string message)
    {
        this.Message = message;
        StatusCode = HttpStatusCode.NotFound;
    }
}
