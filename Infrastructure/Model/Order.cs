using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Model;
[Index(nameof(Id), IsUnique = true)]
public sealed class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public User User { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}
