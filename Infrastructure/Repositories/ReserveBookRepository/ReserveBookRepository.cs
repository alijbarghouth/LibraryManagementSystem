using Domain.Repositories.ReserveBookRepository;
using Domain.Shared.Enums;
using Domain.Shared.Exceptions.CustomException;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ReserveBookRepository;

public sealed class ReserveBookRepository : IReserveBookRepository
{
    private readonly LibraryDBContext _libraryDbContext;

    public ReserveBookRepository(LibraryDBContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<bool> ReserveBook(Guid bookId, Guid userId)
    {
        var book = await _libraryDbContext.Books.FindAsync(bookId)
                   ?? throw new NotFoundException("book is not found");
        var user = await _libraryDbContext.Users.FindAsync(userId)
                   ?? throw new NotFoundException("user is not found");
        if (book.BookStatus != BookStatus.Available)
        {
             throw new NotFoundException("book is not Available");
        }

        var orderItem = new OrderItem
        {
            BookId = book.Id,
            BorrowedAt = DateTime.Now
        };

        var order = new Order
        {
            UserId = userId,
            RequestDate = DateTime.Now,
            StatusRequest = StatusRequest.Pending,
            OrderItems = new List<OrderItem> { orderItem }
        };

        _libraryDbContext.Orders.Add(order);
        return true;
    }
}