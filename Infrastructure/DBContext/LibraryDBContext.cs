﻿using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DBContext;

public sealed class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(x => x.Roles)
            .WithMany(x => x.Users)
            .UsingEntity(x => x.ToTable("UserRole"));
        modelBuilder.Entity<User>()
            .HasMany(x => x.ReadingLists)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
        modelBuilder.Entity<User>()
            .HasMany(x => x.Notifications)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
        modelBuilder.Entity<User>()
            .HasMany(x => x.BookRecommendations)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
        modelBuilder.Entity<User>()
            .HasMany(x => x.BookReviews)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
        modelBuilder.Entity<User>()
         .HasMany(x => x.Orders)
         .WithOne(x => x.User)
         .HasForeignKey(x => x.UserId);
        modelBuilder.Entity<User>()
            .HasMany(x => x.Interactions)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
        modelBuilder.Entity<User>()
            .HasMany(x => x.Reports)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
        
        modelBuilder.Entity<BookReview>()
            .HasMany(x => x.Interactions)
            .WithOne(x => x.BookReview)
            .HasForeignKey(x => x.BookReviewId);
        modelBuilder.Entity<BookReview>()
            .HasMany(x => x.Moderations)
            .WithOne(x => x.BookReview)
            .HasForeignKey(x => x.BookReviewId);
        modelBuilder.Entity<BookReview>()
            .HasMany(x => x.Reports)
            .WithOne(x => x.BookReview)
            .HasForeignKey(x => x.BookReviewId);

        modelBuilder.Entity<Book>()
            .HasMany(x => x.Authors)
            .WithMany(x => x.Books)
            .UsingEntity(x => x.ToTable("BookAuthor"));
        modelBuilder.Entity<Book>()
            .HasMany(x => x.Genres)
            .WithMany(x => x.Books)
            .UsingEntity(x => x.ToTable("BookGenre"));
        modelBuilder.Entity<Book>()
            .HasMany(x => x.ReadingLists)
            .WithOne(x => x.Book)
            .HasForeignKey(x => x.BookId);
        modelBuilder.Entity<Book>()
           .HasMany(x => x.BookReviews)
           .WithOne(x => x.Book)
           .HasForeignKey(x => x.BookId);
        modelBuilder.Entity<Book>()
            .HasOne(x => x.BookRecommendation)
            .WithOne(x => x.Book)
            .HasForeignKey<BookRecommendation>(x => x.BookId);
        modelBuilder.Entity<Book>()
           .HasMany(x => x.OrderItems)
           .WithOne(x => x.Book)
           .HasForeignKey(x => x.BookId);

        modelBuilder.Entity<Order>()
            .HasMany(x => x.OrderItems)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId);
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookRecommendation> BookRecommendations { get; set; }
    public DbSet<Interaction> Interactions { get; set; }
    public DbSet<Moderation> Moderations { get; set; }
    public DbSet<BookReview> BookReviews { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<ReadingList> ReadingLists { get; set; }
}