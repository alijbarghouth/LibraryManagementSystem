﻿using Domain.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model;
[Index(nameof(Id), IsUnique = true)]
public sealed class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DateRetrive { get; set; }
    public DateTime DateRequest { get; set; }
    public StatusRequest StatusRequest { get; set; }
    public User User { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}
