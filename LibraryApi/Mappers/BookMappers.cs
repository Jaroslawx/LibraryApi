using LibraryApi.Dtos.Book;
using LibraryApi.Models;

namespace LibraryApi.Mappers;

public static class BookMappers
{
    public static BookDto ToBookDto(this Book bookDtoModel)
    {
        return new BookDto
        {
            Id = bookDtoModel.Id,
            Title = bookDtoModel.Title,
            Genre = bookDtoModel.Genre,
            AuthorId = bookDtoModel.AuthorId,
            Author = bookDtoModel.Author,
            Reviews = bookDtoModel.Reviews
        };
    }
    
    public static Book ToBookFromCreateDto (this CreateBookRequestDto bookDto)
    {
        return new Book
        {
            Title = bookDto.Title,
            Genre = bookDto.Genre,
            AuthorId = bookDto.AuthorId,
        };
    }
}