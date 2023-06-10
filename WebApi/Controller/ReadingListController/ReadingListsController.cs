using Application.Command.ReadingListCommand;
using Application.Handler.ReadingListHandler.AddReadingListHandler;
using Application.Handler.ReadingListHandler.DeleteReadingListHandler;
using Application.Handler.ReadingListHandler.GetAllReadingListQueryHandler;
using Application.Query.ReadingListQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filter;

namespace WebApi.Controller.ReadingListController
{
    [Route("api/[controller]")]
    [ApiController]
    [LibraryExceptionHandlerFilter]
    public class ReadingListsController : ControllerBase
    {
        private readonly IAddReadingListCommandHandler _addReadingListCommandHandler;
        private readonly IDeleteReadingListCommandHandler _deleteReadingListCommandHandler;
        private readonly IGetAllReadingListQueryHandler _getAllReadingListQueryHandler;

        public ReadingListsController
        (IAddReadingListCommandHandler addReadingListCommandHandler,
            IDeleteReadingListCommandHandler deleteReadingListCommandHandler,
            IGetAllReadingListQueryHandler getAllReadingListQueryHandler)
        {
            _addReadingListCommandHandler = addReadingListCommandHandler;
            _deleteReadingListCommandHandler = deleteReadingListCommandHandler;
            _getAllReadingListQueryHandler = getAllReadingListQueryHandler;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddReadingList(AddReadingListCommand command)
        {
            return Ok(await _addReadingListCommandHandler.Handel(command));
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteReadingList([FromQuery] DeleteReadingListCommand command)
        {
            return Ok(await _deleteReadingListCommandHandler.Handel(command));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllReadingList([FromQuery] GetAllReadingListQuery query)
        {
            return Ok(await _getAllReadingListQueryHandler.Handel(query));
        }
    }
}