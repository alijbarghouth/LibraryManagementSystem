using System.Net;

namespace Domain.Shared.Exceptions;

public class LibraryException : Exception
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
}