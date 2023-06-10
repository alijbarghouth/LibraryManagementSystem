using Application.Cashing;
using Application.Command.BookTransactionCommand;
using Domain.DTOs.OrderDTOs;
using Domain.Services.BookTransactionService;
using Domain.Services.NotificationService;

namespace Application.Handler.BookTransactionHandler.CheckOutBook;

public sealed class CheckOutBookCommandHandler : ICheckOutBookCommandHandler
{
    private readonly IBookTransactionService _bookTransactionService;
    private readonly ICashService _cashService;
    private readonly INotificationService _notificationService;

    private readonly string _massage = $"You have booked the book is due on " +
                                       $"{DateTime.UtcNow.AddDays(10)}." +
                                       $" Please return it on time.";

    private const string Subject = "Book Due Date Reminder";

    public CheckOutBookCommandHandler
    (IBookTransactionService bookTransactionService,
        ICashService cashService,
        INotificationService notificationService)
    {
        _bookTransactionService = bookTransactionService;
        _cashService = cashService;
        _notificationService = notificationService;
    }

    public async Task<Order> Handel(CheckOutBookCommand command)
    {
        var key = $"{command.UserId} PatronProfile";
        var order = await _bookTransactionService.CheckOutBook(command.OrderId);
        await _notificationService.SendEmail
            (order.UserId, _massage, Subject);
        await _cashService.RemoveAsync(key);
        return order;
    }
}