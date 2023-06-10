using Application.Command.ReadingListCommand;
using Domain.DTOs.ReadingListDTOs;
using Domain.DTOs.Response;

namespace Application.Handler.ReadingListHandler.AddReadingListHandler;

public interface IAddReadingListCommandHandler
{
    Task<Response<ReadingList>> Handel(AddReadingListCommand command);
}