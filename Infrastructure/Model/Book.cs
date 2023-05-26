using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Model;
[Index(nameof(Title), IsUnique = true)]
public sealed class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; }
    public int BookId { get; set; }
    public DateTime PublicationDate { get; set; }
    public int GenreId { get; set; }
    public bool Availability { get; set; }
    public List<Genre> Genre { get; set; }
    public List<ReadingList> ReadingList { get; set; }
    public List<Author> Authors { get; set; }
}
