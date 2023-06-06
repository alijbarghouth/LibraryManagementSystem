using Application.Command.ReadingListCommand;
using Application.Handler.ReadingListHandler.AddReadingListHandler;
using Application.Handler.ReadingListHandler.DeleteReadingListHandler;
using Application.Handler.ReadingListHandler.GetAllReadingListQueryHandler;
using Application.Handler.ReadingListHandler.UpdateReadingListHandler;
using Application.Query.ReadingListQuery;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller.ReadingListController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingListsController : ControllerBase
    {
        private readonly IAddReadingListCommandHandler _addReadingListCommandHandler;
        private readonly IDeleteReadingListCommandHandler _deleteReadingListCommandHandler;
        private readonly IUpdateReadingListCommandHandler _updateReadingListCommandHandler;
        private readonly IGetAllReadingListQueryHandler _getAllReadingListQueryHandler;

        public ReadingListsController
        (IAddReadingListCommandHandler addReadingListCommandHandler,
            IDeleteReadingListCommandHandler deleteReadingListCommandHandler,
            IUpdateReadingListCommandHandler updateReadingListCommandHandler,
            IGetAllReadingListQueryHandler getAllReadingListQueryHandler)
        {
            _addReadingListCommandHandler = addReadingListCommandHandler;
            _deleteReadingListCommandHandler = deleteReadingListCommandHandler;
            _updateReadingListCommandHandler = updateReadingListCommandHandler;
            _getAllReadingListQueryHandler = getAllReadingListQueryHandler;
        }

        [HttpPost]
        public async Task<IActionResult> AddReadingList(AddReadingListCommand command)
        {
            return Ok(await _addReadingListCommandHandler.Handel(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReadingList(UpdateReadingListCommand command)
        {
            return Ok(await _updateReadingListCommandHandler.Handel(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReadingList([FromQuery] DeleteReadingListCommand command)
        {
            return Ok(await _deleteReadingListCommandHandler.Handel(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReadingList(GetAllReadingListQuery query)
        {
            return Ok(await _getAllReadingListQueryHandler.Handel(query));
        }
    }
}