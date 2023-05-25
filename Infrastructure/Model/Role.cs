namespace Infrastructure.Model;

public sealed class Role
{
    public int Id { get; set; }
    public string RoleName { get; set; }

    public List<User> Users { get; set; }
}
