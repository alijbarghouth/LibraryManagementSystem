namespace Infrastructure.Model;

public sealed class Notification
{
    public int NotificationId { get; set; }
    public int UserId { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
    public User User { get; set; }
}
