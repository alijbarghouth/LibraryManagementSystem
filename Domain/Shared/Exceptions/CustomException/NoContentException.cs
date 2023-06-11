using System.Net;

namespace Domain.Shared.Exceptions.CustomException;

public sealed class NoContentException : LibraryException
{
    public NoContentException(string message)
    {
        this.Message = message;
        StatusCode = HttpStatusCode.NoContent;
    }
}
