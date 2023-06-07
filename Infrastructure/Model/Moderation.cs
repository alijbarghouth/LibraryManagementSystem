using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model;

public class Moderation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid BookReviewId { get; set; }
    public string? Reason { get; set; }
    public bool IsApproved { get; set; } = true;
    public BookReview BookReview { get; set; }
}