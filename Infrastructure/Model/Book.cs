using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model;
[Index(nameof(Title), IsUnique = true)]
[Index(nameof(Id), IsUnique = true)]
public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public Guid GenreId { get; set; }
    public bool Availability { get; set; }
    public int Count { get; set; }
    public virtual IEnumerable<Genre> Genre { get; set; }
    public virtual ICollection<Author> Authors { get; set; }
    public virtual IEnumerable<ReadingList> ReadingLists { get; set; }
    public virtual IEnumerable<BookReview> BookReviews { get; set; }
    public virtual BookRecommendation BookRecommendation { get; set; }
    public virtual IEnumerable<OrderItem> OrderItems { get; set; }
}
