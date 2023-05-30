using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model;
[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User
{
    public User()
    {
        Roles = new List<Role>(); 
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSlot { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<RefreshToken> RefreshTokens { get; set; }
    public virtual ICollection<Role> Roles { get; set; }
    public virtual IEnumerable<ReadingList> ReadingLists { get; set; }
    public virtual IEnumerable<Notification> Notifications { get; set; }
    public virtual IEnumerable<BookReview> BookReviews { get; set; }
    public virtual IEnumerable<BookRecommendation> BookRecommendations { get; set; }
    public virtual IEnumerable<Order> Orders { get; set; }
}
