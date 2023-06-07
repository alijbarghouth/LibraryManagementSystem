using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model;
[Index(nameof(Id), IsUnique = true)]
public sealed class BookReview
{
    public BookReview()
    {
        Moderations = new List<Moderation>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public int Rating { get; set; }
    public string Content  { get; set; }
    public DateTime CreatedAt { get; set; }
    public  User User { get; set; }
    public  Book Book { get; set; }
    public ICollection<Interaction> Interactions { get; set; }
    public ICollection<Moderation> Moderations { get; set; } 
    public ICollection<Report> Reports { get; set; }
}
