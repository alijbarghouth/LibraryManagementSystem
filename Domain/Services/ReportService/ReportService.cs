using Domain.DTOs.ReportDTOs;
using Domain.Repositories.ReportRepository;
using Domain.Repositories.SharedRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.ReportService;

public sealed class ReportService : IReportService
{
    private readonly IReportRepository _reportRepository;
    private readonly ISharedUserRepository _sharedUserRepository;
    private readonly ISharedBookManagementRepository _sharedBookManagementRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReportService(IReportRepository reportRepository,
        ISharedUserRepository sharedUserRepository,
        ISharedBookManagementRepository sharedBookManagementRepository,
        IUnitOfWork unitOfWork)
    {
        _reportRepository = reportRepository;
        _sharedUserRepository = sharedUserRepository;
        _sharedBookManagementRepository = sharedBookManagementRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Report> AddReport
        (Report report, CancellationToken cancellationToken = default)
    {
        if (!await _sharedUserRepository.IsUserExistsUserId(report.UserId))
            throw new NotFoundException("user not found");
        if (!await _sharedBookManagementRepository.IsBookReviewExistsByBookReviewId(report.BookReviewId))
            throw new NotFoundException("book review not found");
        await _reportRepository.AddReport(report);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return report;
    }
}