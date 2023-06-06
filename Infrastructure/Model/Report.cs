namespace Infrastructure.Model;

public class Report
{
    public Guid Id { get; set; }
    public string Massage { get; set; }
    public Guid UserId { get; set; }
    public Guid BookReviewId { get; set; }
    public User User { get; set; }
    public BookReview BookReview { get; set; }
}