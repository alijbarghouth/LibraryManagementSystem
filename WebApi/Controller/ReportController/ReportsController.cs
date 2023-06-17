using Application.Command.ReportCommand;
using Application.Handler.ReportHandler.AddReportCommandHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller.ReportController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IAddReportCommandHandler _addReportCommandHandler;

        public ReportsController(IAddReportCommandHandler addReportCommandHandler)
        {
            _addReportCommandHandler = addReportCommandHandler;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddReport(AddReportCommand command)
        {
            return Ok(await _addReportCommandHandler.Handel(command));
        }
    }
}