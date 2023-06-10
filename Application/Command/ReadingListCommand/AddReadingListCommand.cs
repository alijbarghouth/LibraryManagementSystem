using Domain.DTOs.ReadingListDTOs;

namespace Application.Command.ReadingListCommand;

public record AddReadingListCommand
(
    ReadingList ReadingList
);