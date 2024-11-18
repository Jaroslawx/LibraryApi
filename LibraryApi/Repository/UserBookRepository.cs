using LibraryApi.Data;
using LibraryApi.Dtos.UserBook;
using LibraryApi.Interfaces;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repository;

public class UserBookRepository (ApplicationDbContext context) : IUserBookRepository
{
    public async Task<List<UserBook>> GetAllAsync()
    {
        return await context.UserBooks.ToListAsync();
    }
    
    public async Task<UserBook?> GetByIdAsync(int id)
    {
        return await context.UserBooks.FirstOrDefaultAsync(f => f.Id == id);
    }
    
    public async Task<UserBook?> UpdateAsync(int id, UpdateUserBookRequestDto updateDto)
    {
        var userBookModel = await context.UserBooks.FirstOrDefaultAsync(f => f.Id == id);
        
        if (userBookModel == null)
        {
            return null;
        }
        
        userBookModel.Status = updateDto.Status;
        userBookModel.Note = updateDto.Note;
        userBookModel.Priority = updateDto.Priority;
        userBookModel.LastUpdated = DateTime.Now;
        
        await context.SaveChangesAsync();
        
        return userBookModel;
    }
    
    public async Task<UserBook?> DeleteAsync(int id)
    {
        var userBook = await context.UserBooks.FirstOrDefaultAsync(f => f.Id == id);
        
        if (userBook == null)
        {
            return null;
        }
        
        context.UserBooks.Remove(userBook);
        await context.SaveChangesAsync();
        
        return userBook;
    }
}