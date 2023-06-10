using Domain.Shared.Enums;

namespace Domain.DTOs.OrderDTOs;

public record Order
(
    Guid Id,
    Guid UserId,
    DateTime OrderDate,
    StatusRequest StatusRequest,
    List<OrderItem> OrderItems
);