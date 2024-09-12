using LibraryApi.Data;
using LibraryApi.Dtos.Book;
using LibraryApi.Interfaces;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repository;

public class BookRepository (ApplicationDbContext context) : IBookRepository
{
    public async Task<List<Book>> GetAllAsync()
    {
        return await context.Books.ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await context.Books.FindAsync(id);
    }

    public async Task<Book> CreateAsync(Book book)
    {
        await context.Books.AddAsync(book);
        await context.SaveChangesAsync();
        return book;
    }

    public async Task<Book?> UpdateAsync(int id, UpdateBookRequestDto updateDto)
    {
        var bookModel = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
        
        if(bookModel == null)
        {
            return null;
        }
        
        bookModel.Title = updateDto.Title;
        bookModel.Genre = updateDto.Genre;
        bookModel.AuthorId = updateDto.AuthorId;
        
        await context.SaveChangesAsync();
        
        return bookModel;
    }

    public async Task<Book?> DeleteAsync(int id)
    {
        var bookModel = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
        
        if(bookModel == null)
        {
            return null;
        }
        
        context.Books.Remove(bookModel);
        await context.SaveChangesAsync();
        return bookModel;
    }
}