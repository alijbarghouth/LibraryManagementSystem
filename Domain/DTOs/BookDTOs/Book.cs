namespace Domain.DTOs.BookDTOs;

public record Book(

     string Title,
     List<string> Author,
     DateTime PublicationDate,
     List<string> Genre,
     bool Availability,
     int Count
);
