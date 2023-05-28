using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model;
[Index(nameof(Id), IsUnique = true)]
public class OrderItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid BookId { get; set; }
    public DateTime BorrowedAt { get; set; }
    public DateTime? ReturnedAt { get; set; }
    public virtual Order Order { get; set; }
    public virtual Book Book { get; set; }
}
