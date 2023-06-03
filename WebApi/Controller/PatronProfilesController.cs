using Application.Command.PatronProfileCommand;
using Application.Handler.PatronProfileHandler.GetPatronProfileQueryHandler;
using Application.Handler.PatronProfileHandler.ViewAndEditPatronProfileCommandHandler;
using Application.Query.PatronProfile;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filter;

namespace WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [LibraryExceptionHandlerFilter]
    public class PatronProfilesController : ControllerBase
    {
        private readonly IGetPatronProfileQueryHandler _getPatronProfileQueryHandler;
        private readonly IViewAndEditPatronProfileCommandHandler _viewAndEditPatronProfileCommandHandler;
        public PatronProfilesController(IGetPatronProfileQueryHandler getPatronProfileQueryHandler, IViewAndEditPatronProfileCommandHandler patronProfileCommandHandler)
        {
            _getPatronProfileQueryHandler = getPatronProfileQueryHandler;
            _viewAndEditPatronProfileCommandHandler = patronProfileCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetPatronProfile([FromQuery] PatronProfileQuery query)
        {
            return Ok(await _getPatronProfileQueryHandler.Handel(query));
        }
        [HttpPut]
        public async Task<IActionResult> ViewAndEditPatronProfile(ViewAndEditPatronProfileCommand command)
        {
            return Ok(await _viewAndEditPatronProfileCommandHandler.Handel(command));
        }
    }
}
