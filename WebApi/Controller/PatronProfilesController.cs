using Application.Handler.PatronProfileHandler;
using Application.Query.PatronProfile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filter;

namespace WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [LibraryExceptionHandlerFilter]
    public class PatronProfilesController : ControllerBase
    {
        private readonly IPatronProfileQueryHandler _patronProfileQueryHandler;

        public PatronProfilesController(IPatronProfileQueryHandler patronProfileQueryHandler)
        {
            _patronProfileQueryHandler = patronProfileQueryHandler;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetPatronProfile(PatronProfileQuery query)
        {
            return Ok(await _patronProfileQueryHandler.Handel(query));
        }
    }
}
