using Domain.Repositories.BookTransactionRepository;
using Domain.Shared.Enums;
using Domain.Shared.Exceptions.CustomException;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BookTransactionRepository;

public sealed class BookTransactionRepository : IBookTransactionRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public BookTransactionRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<Domain.DTOs.OrderDTOs.Order> ReserveBook
        (Guid bookId, Guid userId)
    {
        var book = await _libraryDbContext.Books.FindAsync(bookId);

        if (book.Count <= 0)
            throw new BadRequestException("book not Available");

        var user = await _libraryDbContext.Users
            .Include(x => x.Orders)
            .ThenInclude(x => x.OrderItems)
            .SingleOrDefaultAsync(x => x.Id == userId);

        if (user.Orders.Any
            (x => (x.StatusRequest == StatusRequest.Reserved
                   || x.StatusRequest == StatusRequest.CheckedOut) && x.OrderItems
                .Any(y => y.BookId == book.Id)))
        {
            throw new BadRequestException("order is already exists");
        }

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
        return order.Adapt<Domain.DTOs.OrderDTOs.Order>();
    }

    public async Task<Domain.DTOs.OrderDTOs.Order> CheckOutBook(Guid orderId)
    {
        var order = await _libraryDbContext.Orders
                        .Include(x => x.OrderItems)
                        .ThenInclude(x => x.Book)
                        .FirstOrDefaultAsync(o => o.Id == orderId && o.StatusRequest == StatusRequest.Reserved)
                    ?? throw new NotFoundException("order not found or not found order is reserved");
        order.StatusRequest = StatusRequest.CheckedOut;
        order.OrderDate = DateTime.UtcNow;
        var orderItem = order.OrderItems.FirstOrDefault()
                        ?? throw new NotFoundException("order item not found");

        var book = await _libraryDbContext.Books
                       .FindAsync(orderItem.BookId)
                   ?? throw new NotFoundException("book not found");
        orderItem.Price = book.Price;
        _libraryDbContext.OrderItems.Update(orderItem);
        await _libraryDbContext.SaveChangesAsync();

        book.Count -= 1;
        _libraryDbContext.Books.Update(book);

        orderItem.BorrowedDate = DateTime.UtcNow;
        _libraryDbContext.Orders.Update(order);

        _libraryDbContext.OrderItems.Update(orderItem);

        return order.Adapt<Domain.DTOs.OrderDTOs.Order>();
    }

    public async Task<Domain.DTOs.OrderDTOs.Order> AcceptReturnedBook(Guid orderId)
    {
        var order = await _libraryDbContext.Orders
                        .Include(x => x.OrderItems)
                        .ThenInclude(x => x.Book)
                        .FirstOrDefaultAsync(x => x.Id == orderId && x.StatusRequest == StatusRequest.CheckedOut)
                    ?? throw new NotFoundException("order not found or not found order is reserved");
        order.StatusRequest = StatusRequest.Returned;
        _libraryDbContext.Orders.Update(order);

        var orderItem = order.OrderItems.FirstOrDefault()
                        ?? throw new NotFoundException("order item not found");
        var book = await _libraryDbContext.Books
                       .FindAsync(orderItem.BookId)
                   ?? throw new NotFoundException("book not found");
        book.Count += 1;
        _libraryDbContext.Books.Update(book);

        orderItem.DateRetrieved = DateTime.UtcNow;
        _libraryDbContext.OrderItems.Update(orderItem);

        return order.Adapt<Domain.DTOs.OrderDTOs.Order>();
    }

    public async Task<Domain.DTOs.OrderDTOs.Order> RejectReserveBook(Guid orderId)
    {
        var order = await _libraryDbContext.Orders
                        .Include(x => x.OrderItems)
                        .ThenInclude(x => x.Book)
                        .FirstOrDefaultAsync
                            (o => o.Id == orderId && o.StatusRequest == StatusRequest.Reserved)
                    ?? throw new NotFoundException("order not found or not found order is reserved");
        ;
        order.StatusRequest = StatusRequest.Rejected;

        _libraryDbContext.Orders.Update(order);

        return order.Adapt<Domain.DTOs.OrderDTOs.Order>();
    }

    public async Task<List<Domain.DTOs.OrderDTOs.OverdueBook>> GetOverdueBooks()
    {
        var currentDate = DateTime.UtcNow;

        var overdueBooks = await _libraryDbContext.Orders
            .AsNoTracking()
            .Include(o => o.OrderItems)
            .ThenInclude(x=> x.Book)
            .ThenInclude(x=> x.Authors)
            .Include(x=> x.User)
            .Where(o => o.StatusRequest == StatusRequest.CheckedOut && o.OrderItems
                .Any(oi => oi.BorrowedDate.HasValue
                           && oi.BorrowedDate.Value.AddDays(10) < currentDate))
            .Select(x => new
            {
                x.UserId,
                Book = x.OrderItems.Select(b => b.Book).FirstOrDefault(),
                UpdatedPrice = x.OrderItems.Select
                    (y => y.UpdatedPrice).FirstOrDefault()
            })
            .ToListAsync();

        return overdueBooks.Adapt<List<Domain.DTOs.OrderDTOs.OverdueBook>>();
    }
}