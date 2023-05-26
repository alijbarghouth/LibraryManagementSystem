namespace Infrastructure.Model;

public sealed class ReadingList
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public User User { get; set; }
    public List<Book> Books { get; set; }
}
