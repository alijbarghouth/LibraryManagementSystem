using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model;
[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public sealed class User
{
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
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    public List<Role> Roles { get; set; }
    public List<ReadingList> ReadingLists { get; set; }
    public List<Notification> Notifications { get; set; }
    public List<BookReview> BookReviews { get; set; }
    public List<BookRecommendation> BookRecommendations { get; set; }
    public List<Order> Orders { get; set; }
}
