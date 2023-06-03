using Domain.DTOs.PatronProfileDTOs;

namespace Application.Command.PatronProfileCommand;

public record ViewAndEditPatronProfileCommand
(
    PatronProfile PatronProfile,
    Guid OrderId
);