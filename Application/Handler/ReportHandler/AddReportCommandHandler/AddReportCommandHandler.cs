using Application.Command.ReportCommand;
using Domain.DTOs.ReportDTOs;
using Domain.Services.ReportService;

namespace Application.Handler.ReportHandler.AddReportCommandHandler;

public sealed class AddReportCommandHandler : IAddReportCommandHandler
{
    private readonly IReportService _reportService;

    public AddReportCommandHandler(IReportService reportService)
    {
        _reportService = reportService;
    }

    public async Task<Report> Handel(AddReportCommand command)
    {
        return await _reportService.AddReport(command.Report);
    }
}