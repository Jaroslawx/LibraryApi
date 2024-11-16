using LibraryApi.Models;

namespace LibraryApi.Interfaces;

public interface IUserBookRepository
{
    Task<List<UserBook>> GetAllAsync();
}