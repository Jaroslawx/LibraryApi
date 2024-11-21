using LibraryApi.Data;
using LibraryApi.Dtos.Book;
using LibraryApi.Helpers;
using LibraryApi.Interfaces;
using LibraryApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repository;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;
    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Book>> GetAllAsync(QueryObject query)
    {
        var books = _context.Books.Include(r => r.Reviews).AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(query.Title))
        {
            books = books.Where(b => b.Title.Contains(query.Title));
        }
        
        if(!string.IsNullOrWhiteSpace(query.Author))
        {
            books = books.Where(b => b.Author.Pseudonym.Contains(query.Author));
        }

        return await books.ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _context.Books.Include(r => r.Reviews).FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Book> CreateAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<Book?> UpdateAsync(int id, UpdateBookRequestDto updateDto)
    {
        var bookModel = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        
        if(bookModel == null)
        {
            return null;
        }
        
        bookModel.OlBookKey = updateDto.OLBookKey;
        bookModel.Title = updateDto.Title;
        bookModel.Subjects = updateDto.Subjects;
        bookModel.PublishedDate = updateDto.PublishedDate;
        bookModel.Description = updateDto.Description;
        bookModel.AuthorId = updateDto.AuthorId;
        
        await _context.SaveChangesAsync();
        
        return bookModel;
    }

    public async Task<Book?> DeleteAsync(int id)
    {
        var bookModel = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        
        if(bookModel == null)
        {
            return null;
        }
        
        _context.Books.Remove(bookModel);
        await _context.SaveChangesAsync();
        return bookModel;
    }
    
    public async Task<Book?> AddToBookshelfAsync(int id, AddToBookshelfRequestDto addToBookshelfRequestDto)
    {
        var bookModel = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        
        if(bookModel == null)
        {
            return null;
        }
        
        var userBook = new UserBook
        {
            BookId = bookModel.Id,
            UserId = addToBookshelfRequestDto.UserId,
            Status = addToBookshelfRequestDto.Status,
            Note = addToBookshelfRequestDto.Note,
            LastUpdated = DateTime.Now
        };
        
        await _context.UserBooks.AddAsync(userBook);
        await _context.SaveChangesAsync();
        
        return bookModel;
    }

    public async Task<bool> BookExistsAsync(int id)
    {
        return await _context.Books.AnyAsync(b => b.Id == id);
    }
}