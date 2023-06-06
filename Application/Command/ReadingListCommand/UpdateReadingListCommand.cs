using Domain.DTOs.ReadingListDTOs;

namespace Application.Command.ReadingListCommand;

public record UpdateReadingListCommand
(
    Guid ReadingListId,
    ReadingList ReadingList
);