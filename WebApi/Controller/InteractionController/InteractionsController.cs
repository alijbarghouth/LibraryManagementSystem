using Application.Command.InteractionCommand;
using Application.Handler.InteractionHandler.AddInteractionCommandHandler;
using Application.Handler.InteractionHandler.DeleteInteractionCommandHandler;
using Application.Handler.InteractionHandler.GetAllInteractionQueryHandler;
using Application.Handler.InteractionHandler.UpdateInteractionCommandHandler;
using Application.Query.InteractionQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filter;

namespace WebApi.Controller.InteractionController
{
    [Route("api/[controller]")]
    [ApiController]
    [LibraryExceptionHandlerFilter]
    public class InteractionsController : ControllerBase
    {
        private readonly IAddInteractionCommandHandler _addInteractionCommandHandler;
        private readonly IUpdateInteractionCommandHandler _updateInteractionCommandHandler;
        private readonly IDeleteInteractionCommandHandler _deleteInteractionCommandHandler;
        private readonly IGetAllInteractionQueryHandler _getAllInteractionQueryHandler;

        public InteractionsController
        (IAddInteractionCommandHandler addInteractionCommandHandler,
            IUpdateInteractionCommandHandler updateInteractionCommandHandler,
            IDeleteInteractionCommandHandler deleteInteractionCommandHandler,
            IGetAllInteractionQueryHandler getAllInteractionQueryHandler)
        {
            _addInteractionCommandHandler = addInteractionCommandHandler;
            _updateInteractionCommandHandler = updateInteractionCommandHandler;
            _deleteInteractionCommandHandler = deleteInteractionCommandHandler;
            _getAllInteractionQueryHandler = getAllInteractionQueryHandler;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddInteraction(AddInteractionCommand command)
        {
            return Ok(await _addInteractionCommandHandler.Handel(command));
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateInteraction(UpdateInteractionCommand command)
        {
            return Ok(await _updateInteractionCommandHandler.Handel(command));
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteInteraction([FromQuery] DeleteInteractionCommand command)
        {
            return Ok(await _deleteInteractionCommandHandler.Handel(command));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllInteractionByBookReviewId([FromQuery] GetAllInteractionQuery query)
        {
            return Ok(await _getAllInteractionQueryHandler.Handel(query));
        }
    }
}