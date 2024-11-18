using LibraryApi.Dtos.Book;
using LibraryApi.Models;

namespace LibraryApi.Interfaces;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int id);
    Task<Book> CreateAsync(Book book);
    Task<Book?> UpdateAsync(int id, UpdateBookRequestDto updateDto);
    Task<Book?> DeleteAsync(int id);
    Task<Book?> AddToBookshelfAsync(int id, AddToBookshelfRequestDto addToBookshelfRequestDto);
    Task<bool> BookExistsAsync(int id);
}