﻿using Domain.Repositories.BookAuthorRepository;
using Domain.Shared.Exceptions.CustomException;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BookAuthorRepository;

public sealed class BookAuthorRepository : IBookAuthorRepository
{
    private readonly LibraryDBContext _dbContext;

    public BookAuthorRepository(LibraryDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddBookAuthor(Domain.DTOs.BookAuthorDTOs.BookAuthor bookAuthor)
    {
        var book = await _dbContext.Books
            .SingleOrDefaultAsync(x => x.Title == bookAuthor.BookName)
            ?? throw new LibraryNotFoundException("book not found");

        foreach (var authorDto in bookAuthor.AuthorName)
        {
            var author = await _dbContext.Authors.SingleOrDefaultAsync(x => x.Username == authorDto);
            
            book.Authors.Add(author);
        }
        _dbContext.Books.Update(book);
        return true;
    }
}
