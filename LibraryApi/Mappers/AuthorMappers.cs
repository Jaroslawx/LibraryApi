﻿using LibraryApi.Dtos.Author;
using LibraryApi.Models;

namespace LibraryApi.Mappers;

public static class AuthorMappers
{
    public static AuthorDto ToAuthorDto(this Author author)
    {
        return new AuthorDto
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            Books = author.Books
        };
    }
    
    public static Author ToAuthorFromCreateDto (this CreateAuthorRequestDto authorDto)
    {
        return new Author
        {
            FirstName = authorDto.FirstName,
            LastName = authorDto.LastName,
        };
    }
}