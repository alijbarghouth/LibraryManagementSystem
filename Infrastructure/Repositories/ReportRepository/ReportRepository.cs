using Domain.Repositories.ReportRepository;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Mapster;

namespace Infrastructure.Repositories.ReportRepository;

public sealed class ReportRepository : IReportRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public ReportRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<Domain.DTOs.ReportDTOs.Report> AddReport
        (Domain.DTOs.ReportDTOs.Report report)
    {
        await _libraryDbContext.Reports.AddAsync(report.Adapt<Report>());
        return report;
    }
}