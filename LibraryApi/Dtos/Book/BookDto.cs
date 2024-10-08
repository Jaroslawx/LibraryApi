﻿using LibraryApi.Data.Enum;
using LibraryApi.Models;

namespace LibraryApi.Dtos.Book;

public class BookDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public BookGenre Genre { get; set; }
    public int AuthorId { get; set; }
    public Models.Author? Author { get; set; }
    public ICollection<Models.Review>? Reviews { get; set; }
}