using System.Net;

namespace Domain.Shared.Exceptions.CustomException;

public sealed class NoContentException : LibraryException
{
    public NoContentException(string Message)
    {
        this.Message = Message;
        StatusCode = HttpStatusCode.NoContent;
    }
}
