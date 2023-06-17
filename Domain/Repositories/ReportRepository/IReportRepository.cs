using Domain.DTOs.ReportDTOs;

namespace Domain.Repositories.ReportRepository;

public interface IReportRepository
{
    Task<Report> AddReport(Report report);
}