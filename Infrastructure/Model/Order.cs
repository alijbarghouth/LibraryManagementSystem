using Domain.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model;
[Index(nameof(Id), IsUnique = true)]
public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime? BorrowingDate { get; set; }
    public DateTime? DateRetrive { get; set; }
    public DateTime RequestDate { get; set; }
    public StatusRequest StatusRequest { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
}
