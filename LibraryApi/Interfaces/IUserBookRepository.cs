using LibraryApi.Dtos.UserBook;
using LibraryApi.Models;

namespace LibraryApi.Interfaces;

public interface IUserBookRepository
{
    Task<List<UserBook>> GetAllAsync();
    Task<UserBook?> GetByIdAsync(int id);
    Task<UserBook?> UpdateAsync(int id, UpdateUserBookRequestDto updateDto);
    // Task<UserBook?> DeleteAsync(int id);
}