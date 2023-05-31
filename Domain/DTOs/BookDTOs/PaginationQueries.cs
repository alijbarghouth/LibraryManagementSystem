namespace Domain.DTOs.BookDTOs;

public record PaginationQueries
{
    private int _pageSize;
    public PaginationQueries()
    {
        PageNumber = 1;
        PageSize = 100;
    }
    public PaginationQueries(int PageNumber, int PageSize)
    {
        this.PageNumber = PageNumber;
        this.PageSize = PageSize;
    }
    public int PageNumber { get; set; }
    public int PageSize
    {
        get => _pageSize;
        set
        {
            _pageSize = value;
            if (value > 100)
                _pageSize = 100;
        }
    }
}
