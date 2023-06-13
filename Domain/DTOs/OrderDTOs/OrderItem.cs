namespace Domain.DTOs.OrderDTOs;

public record OrderItem
(
    Guid Id,
    Guid OrderId,
    Guid BookId,
    decimal? UpdatedPrice,
    DateTime? BorrowedDate,
    DateTime RequestDate,
    DateTime? DateRetrieved
);