using Application.Cashing;
using Application.Command.BookTransactionCommand;
using Domain.DTOs.NotificationDTOs;
using Domain.DTOs.OrderDTOs;
using Domain.Services.BookTransactionService;
using Domain.Services.NotificationService;

namespace Application.Handler.BookTransactionHandler.ReserveBook;

public sealed class ReserveBookCommandHandler : IReserveBookCommandHandler
{
    private readonly IBookTransactionService _bookTransactionService;
    private readonly ICashService _cashService;
    private readonly INotificationService _notificationService;
    private const string Massage = "You have Reserved the book... Will reply soon";
    private const string Subject = "Book Reserved";

    public ReserveBookCommandHandler(IBookTransactionService bookTransactionService,
        ICashService cashService,
        INotificationService notificationService)
    {
        _bookTransactionService = bookTransactionService;
        _cashService = cashService;
        _notificationService = notificationService;
    }

    public async Task<Order> Handel(ReserveBookCommand command)
    {
        var key = $"{command.UserId} PatronProfile";
        var order = await _bookTransactionService.ReserveBook(command.BookId, command.UserId);

        await _notificationService.SendEmail
            (order.UserId, Massage, Subject);
        await _cashService.RemoveAsync(key);
        return order;
    }
}