using Application.Command.BookTransactionCommand;
using Domain.DTOs.OrderDTOs;

namespace Application.Handler.BookTransactionHandler.CheckOutBook;

public interface ICheckOutBookCommandHandler
{
    Task<Order> Handel(CheckOutBookCommand command);
}