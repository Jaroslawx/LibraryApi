using LibraryApi.Dtos.Author;
using LibraryApi.Models;

namespace LibraryApi.Interfaces;

public interface IAuthorRepository
{
    Task<List<Author>> GetAllAsync();
    Task<Author?> GetByIdAsync(int id);
    Task<Author> CreateAsync(Author author);
    Task<Author?> UpdateAsync(int id, UpdateAuthorRequestDto updateDto);
    Task<Author?> DeleteAsync(int id);
}