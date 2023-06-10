using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model;
[Index(nameof(Id), IsUnique = true)]
public sealed class Role
{
    public Role()
    {
        Users = new List<User>();
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string RoleName { get; set; }
    public  ICollection<User> Users { get; set; }
}
