﻿using LibraryApi.Dtos.Book;
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
            Reviews = bookDtoModel.Reviews,
            AverageRating = bookDtoModel.AverageRating
        };
    }
    
    public static Book ToBookFromCreateDto (this CreateBookRequestDto bookDto)
    {
        return new Book
        {
            BookKey = bookDto.BookKey,
            Title = bookDto.Title,
            Subjects = bookDto.Subjects,
            PublishedDate = bookDto.PublishedDate,
            Description = bookDto.Description,
            AuthorId = bookDto.AuthorId,
        };
    }
}