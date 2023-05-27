using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Model;

[Index(nameof(Id), IsUnique = true)]
public sealed class ReadingList
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public string BookId { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public User User { get; set; }
    public Book Books { get; set; }
}
