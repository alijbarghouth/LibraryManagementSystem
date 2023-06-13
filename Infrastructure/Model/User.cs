using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model;
[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public sealed class User
{
    public User()
    {
        Roles = new List<Role>();
        Orders = new List<Order>();
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
    public bool IsConfirmed { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }
    public  ICollection<Role> Roles { get; set; }
    public  IEnumerable<ReadingList> ReadingLists { get; set; }
    public  ICollection<Notification> Notifications { get; set; }
    public  ICollection<BookReview> BookReviews { get; set; }
    public  IEnumerable<BookRecommendation> BookRecommendations { get; set; }
    public  IEnumerable<Order> Orders { get; set; }
    public ICollection<Interaction> Interactions { get; set; }
    public ICollection<Report> Reports { get; set; }
}
