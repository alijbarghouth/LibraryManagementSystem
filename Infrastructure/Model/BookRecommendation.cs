namespace Infrastructure.Model;

public sealed class BookRecommendation
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public string RecommendationType { get; set; }
    public DateTime CreatedAt { get; set; }
    public User User { get; set; }
    public Book Book { get; set; }
}
