using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model;

[Index(nameof(Id), IsUnique = true)]
public sealed class OrderItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }
    public Guid BookId { get; set; }
    public decimal? Price { get; set; }
    public DateTime? BorrowedDate { get; set; }
    public DateTime RequestDate { get; set; }
    public DateTime? DateRetrieved { get; set; }
    public  Order Order { get; set; }
    public  Book Book { get; set; }
}