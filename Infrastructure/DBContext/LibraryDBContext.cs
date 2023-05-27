using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DBContext;

public sealed class LibraryDBContext : DbContext
{
    public LibraryDBContext(DbContextOptions<LibraryDBContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(x => x.Roles)
            .WithMany(x => x.Users)
            .UsingEntity(x => x.ToTable("UserRole"));
        modelBuilder.Entity<Author>()
            .HasMany(x => x.Books)
            .WithMany(x => x.Authors)
            .UsingEntity(x => x.ToTable("BookAuthor"));
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
}