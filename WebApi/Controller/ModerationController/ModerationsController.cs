using Application.Command.ModerationCommand;
using Application.Handler.ModerationHandler;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller.ModerationController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModerationsController : ControllerBase
    {
        private readonly IDeleteReviewCommandHandler _deleteReviewCommandHandler;

        public ModerationsController(IDeleteReviewCommandHandler deleteReviewCommandHandler)
        {
            _deleteReviewCommandHandler = deleteReviewCommandHandler;
        }

        [HttpPut]
        public async Task<IActionResult> DeleteReview(DeleteReviewCommand command)
        {
            return Ok(await _deleteReviewCommandHandler.Handel(command));
        }
    }
}