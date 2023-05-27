using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Model;
[Index(nameof(Title), IsUnique = true)]
[Index(nameof(Id), IsUnique = true)]
public sealed class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string BookId { get; set; }
    public DateTime PublicationDate { get; set; }
    public string GenreId { get; set; }
    public bool Availability { get; set; }
    public List<Genre> Genre { get; set; }
    public List<Author> Authors { get; set; }
    public List<ReadingList> ReadingLists { get; set; }
    public List<BookReview> BookReviews { get; set; }
    public BookRecommendation BookRecommendation { get; set; }
}
