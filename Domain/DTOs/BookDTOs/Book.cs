﻿using Domain.Shared.Enums;

namespace Domain.DTOs.BookDTOs;

public record Book
(
    string Title,
    List<string> Author,
    DateTime PublicationDate,
    List<string> Genre,
    BookStatus BookStatus,
    int Count
);