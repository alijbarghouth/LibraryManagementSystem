using Domain.Shared.Enums;

namespace Domain.DTOs.InteractionDTOs;

public record Interaction
(
    Guid UserId,
    Guid BookReviewId,
    InteractionType Type
);