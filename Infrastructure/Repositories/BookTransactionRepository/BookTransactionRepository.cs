using Domain.Repositories.ReserveBookRepository;
using Domain.Shared.Enums;
using Domain.Shared.Exceptions.CustomException;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BookTransactionRepository;

public sealed class BookTransactionRepository : IReserveBookRepository
{
    private readonly LibraryDBContext _libraryDbContext;

    public BookTransactionRepository(LibraryDBContext libraryDbContext)
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
            RequestDate = DateTime.Now
        };

        var order = new Order
        {
            UserId = userId,
            StatusRequest = StatusRequest.Reserved,
            OrderItems = new List<OrderItem> { orderItem }
        };

        await _libraryDbContext.Orders.AddAsync(order);
        return true;
    }

    public async Task CheckOutBook(Guid orderId)
    {
        var order = await _libraryDbContext.Orders
                        .FirstOrDefaultAsync(o => o.Id == orderId && o.StatusRequest == StatusRequest.Reserved)
                    ?? throw new NotFoundException("order not found or not found order is reserved");
        order.StatusRequest = StatusRequest.CheckedOut;
        order.OrderDate = DateTime.UtcNow;
        // Set the borrowed date of the associated order item
        var orderItem = order.OrderItems.FirstOrDefault()
                        ?? throw new NotFoundException("order item not found");

        orderItem.BorrowedDate = DateTime.UtcNow;
        orderItem.DateRetrieved = DateTime.UtcNow.AddDays(10);
        _libraryDbContext.Orders.Update(order);
        await _libraryDbContext.SaveChangesAsync();
        _libraryDbContext.OrderItems.Update(orderItem);
        await _libraryDbContext.SaveChangesAsync();
    }

    public async Task AcceptReturnedBook(Guid orderId)
    {
        var order = await _libraryDbContext.Orders
                        .FirstOrDefaultAsync(x => x.Id == orderId && x.StatusRequest == StatusRequest.CheckedOut)
                    ?? throw new NotFoundException("order not found or not found order is reserved");
        order.StatusRequest = StatusRequest.Returned;
        _libraryDbContext.Orders.Update(order);
        await _libraryDbContext.SaveChangesAsync();

        var orderItem = order.OrderItems.FirstOrDefault()
                        ?? throw new NotFoundException("order item not found");
        orderItem.DateRetrieved = DateTime.UtcNow;
        _libraryDbContext.OrderItems.Update(orderItem);
        await _libraryDbContext.SaveChangesAsync();
    }

    public async Task<List<Domain.DTOs.OrderDTOs.Order>> GetOverdueBooks()
    {
        var currentDate = DateTime.UtcNow;

        var overdueBooks = await _libraryDbContext.Orders
            .Include(o => o.OrderItems)
            .Where(o => o.StatusRequest == StatusRequest.CheckedOut && o.OrderItems
                .Any(oi => oi.BorrowedDate.HasValue
                           && oi.BorrowedDate.Value.AddDays(10) < currentDate))
            .ToListAsync();

        return overdueBooks.Adapt<List<Domain.DTOs.OrderDTOs.Order>>();
    }
}