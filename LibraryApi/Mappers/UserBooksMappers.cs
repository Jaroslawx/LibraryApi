using LibraryApi.Dtos.UserBook;
using LibraryApi.Models;

namespace LibraryApi.Mappers;

public static class UserBooksMappers
{
    public static UserBookDto ToUserBookDto(this UserBook userBook)
    {
        return new UserBookDto
        {
            Id = userBook.Id,
            BookId = userBook.BookId,
            Book = userBook.Book,
            UserId = userBook.UserId,
            Status = userBook.Status,
            Note = userBook.Note,
            LastUpdated = userBook.LastUpdated
        };
    }
    
    
}