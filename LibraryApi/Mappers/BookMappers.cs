using LibraryApi.Dtos.Book;
using LibraryApi.Dtos.Review;
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
            Subjects = bookDtoModel.Subjects,
            PublishedDate = bookDtoModel.PublishedDate,
            Description = bookDtoModel.Description,
            AuthorId = bookDtoModel.AuthorId,
            Author = bookDtoModel.Author,
            Reviews = bookDtoModel.Reviews?.Select(r => r.ToReviewDto()).ToList() ?? new List<ReviewDto>()
        };
    }
    
    public static AuthorBookDto ToAuthorBookDto(this Book authorBookDtoModel)
    {
        return new AuthorBookDto
        {
            Id = authorBookDtoModel.Id,
            Title = authorBookDtoModel.Title,
            Subjects = authorBookDtoModel.Subjects,
            PublishedDate = authorBookDtoModel.PublishedDate,
            Description = authorBookDtoModel.Description,
        };
    }
    
    public static Book ToBookFromCreate (this CreateBookDto bookDto)
    {
        return new Book
        {
            OlBookKey = bookDto.OlBookKey,
            Title = bookDto.Title,
            Subjects = bookDto.Subjects,
            PublishedDate = bookDto.PublishedDate,
            Description = bookDto.Description,
            AuthorId = bookDto.AuthorId,
        };
    }
}