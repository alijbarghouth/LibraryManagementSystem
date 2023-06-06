using Application.Command.ReadingListCommand;
using Domain.DTOs.ReadingListDTOs;
using Domain.DTOs.Response;

namespace Application.Handler.ReadingListHandler.UpdateReadingListHandler;

public interface IUpdateReadingListCommandHandler
{
    Task<Response<ReadingList>> Handel(UpdateReadingListCommand command);
}