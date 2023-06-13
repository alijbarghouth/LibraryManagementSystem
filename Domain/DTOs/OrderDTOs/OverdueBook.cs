using Domain.DTOs.BookDTOs;

namespace Domain.DTOs.OrderDTOs;

public record OverdueBook
(
  Guid UserId,
  Book Book,
  decimal Price
);