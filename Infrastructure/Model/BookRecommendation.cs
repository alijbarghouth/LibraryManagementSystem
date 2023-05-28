using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model;
[Index(nameof(Id), IsUnique = true)]
public class BookRecommendation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public string RecommendationType { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual User User { get; set; }
    public virtual Book Book { get; set; }
}
