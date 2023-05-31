﻿using Domain.DTOs.BookDTOs;
using Domain.DTOs.PaginationsDTOs;

namespace Domain.Services.BookService;

public interface IBookService
{
    Task<PagedResponse<Book>> SearchBookByTitle(string bookTitle, PaginationFilter filter);
    Task<PagedResponse<Book>> SearchBookByAuthor(string bookTitle, PaginationFilter filter);
}