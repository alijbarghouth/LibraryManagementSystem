namespace Domain.DTOs.ReportDTOs;

public record Report
(
    string Massage,
    Guid UserId,
    Guid BookReviewId
);