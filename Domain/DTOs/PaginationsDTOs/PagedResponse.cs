namespace Domain.DTOs.PaginationsDTOs;

public class PagedResponse<T>
{
    public PagedResponse() { }

    public PagedResponse(List<T> data)
    {
        this.data = data;
    }
    public List<T> data { get; set; }

    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string NextPage { get; set; }
    public string PreviousPage { get; set; }
}
