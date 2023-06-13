namespace Domain.DTOs.ReadingListDTOs;

public record ReadingList
(
    Guid UserId,
    Guid BookId
);