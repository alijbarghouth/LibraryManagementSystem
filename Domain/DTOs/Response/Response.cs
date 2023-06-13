namespace Domain.DTOs.Response;

public sealed class Response<T>
{
    public Guid Id { get; set; }
    public T Data { get; set; }
    public Response(T data, Guid id)
    {
        Data = data;
        Id = id;
    }
}