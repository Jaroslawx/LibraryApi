using LibraryApi.Dtos.Author;
using LibraryApi.Dtos.Book;
using LibraryApi.Models;

namespace LibraryApi.Mappers;

public static class AuthorMappers
{
    public static AuthorDto ToAuthorDto(this Author author)
    {
        return new AuthorDto
        {
            Id = author.Id,
            OlAuthorKey = author.OlAuthorKey,
            Pseudonym = author.Pseudonym,
            FirstName = author.FirstName,
            LastName = author.LastName,
            BirthDate = author.BirthDate,
            Biography = author.Biography,
            Books = author.Books?.Select(b => b.ToBookDto()).ToList() ?? new List<BookDto>()
        };
    }
    
    public static Author ToAuthorFromCreate (this CreateAuthorDto authorDto)
    {
        return new Author
        {
            OlAuthorKey = authorDto.OlAuthorKey,
            Pseudonym = authorDto.Pseudonym,
            FirstName = authorDto.FirstName,
            LastName = authorDto.LastName,
            BirthDate = authorDto.BirthDate,
            Biography = authorDto.Biography
        };
    }
}