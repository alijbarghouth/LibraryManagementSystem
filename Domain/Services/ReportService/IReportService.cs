using Domain.DTOs.ReportDTOs;

namespace Domain.Services.ReportService;

public interface IReportService
{
    Task<Report> AddReport
        (Report report, CancellationToken cancellationToken = default);
}