using Application.Command.ReportCommand;
using Domain.DTOs.ReportDTOs;

namespace Application.Handler.ReportHandler.AddReportCommandHandler;

public interface IAddReportCommandHandler
{
    Task<Report> Handel(AddReportCommand command);
}