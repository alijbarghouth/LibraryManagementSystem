﻿using Domain.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model;

[Index(nameof(Title), IsUnique = true)]
[Index(nameof(Id), IsUnique = true)]
public sealed class Book
{
    public Book()
    {
        OrderItems = new List<OrderItem>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public BookStatus BookStatus { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
    public  ICollection<Genre> Genres { get; set; }
    public  ICollection<Author> Authors { get; set; }
    public  IEnumerable<ReadingList> ReadingLists { get; set; }
    public  List<BookReview> BookReviews { get; set; }
    public  BookRecommendation BookRecommendation { get; set; }
    public  IEnumerable<OrderItem> OrderItems { get; set; }
}