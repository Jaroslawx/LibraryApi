using LibraryApi.Dtos.Author;
using LibraryApi.Models;

namespace LibraryApi.Mappers;

public static class AuthorMappers
{
    public static AuthorDto ToAuthorDto(this Author author)
    {
        return new AuthorDto
        {
            Id = author.Id,
            AuthorKey = author.AuthorKey,
            Pseudonym = author.Pseudonym,
            FirstName = author.FirstName,
            LastName = author.LastName,
            BirthDate = author.BirthDate,
            Biography = author.Biography,
            Books = author.Books
        };
    }
    
    public static Author ToAuthorFromCreateDto (this CreateAuthorRequestDto authorDto)
    {
        return new Author
        {
            AuthorKey = authorDto.AuthorKey,
            Pseudonym = authorDto.Pseudonym,
            FirstName = authorDto.FirstName,
            LastName = authorDto.LastName,
            BirthDate = authorDto.BirthDate,
            Biography = authorDto.Biography
        };
    }
}