using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Model;
[Index(nameof(Id), IsUnique = true)]
public sealed class BookRecommendation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public string RecommendationType { get; set; }
    public DateTime CreatedAt { get; set; }
    public User User { get; set; }
    public Book Book { get; set; }
}
