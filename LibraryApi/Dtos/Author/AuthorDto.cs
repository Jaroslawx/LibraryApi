﻿using LibraryApi.Dtos.Book;

namespace LibraryApi.Dtos.Author;

public class AuthorDto
{
    public int Id { get; set; }
    public string? OlAuthorKey { get; set; }
    public string? Pseudonym  { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Biography { get; set; }
    public ICollection<AuthorBookDto>? AuthorBooks { get; set; }
}