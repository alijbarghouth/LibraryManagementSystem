using Domain.DTOs.OrderDTOs;
using Domain.Shared.Enums;

namespace Domain.DTOs.PatronProfileDTOs;

public record PatronProfile
(
    Guid Id,
    Guid UserId,
    DateTime OrderDate,
    StatusRequest StatusRequest,
    List<OrderItem> OrderItems
);