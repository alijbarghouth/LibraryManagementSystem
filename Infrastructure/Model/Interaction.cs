using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Shared.Enums;

namespace Infrastructure.Model;

public class Interaction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BookReviewId { get; set; }
    public InteractionType Type { get; set; }

    public User User { get; set; }
    public BookReview BookReview { get; set; }
}