using LibraryApi.Data;
using LibraryApi.Dtos.Author;
using LibraryApi.Interfaces;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repository;

public class AuthorRepository (ApplicationDbContext context) : IAuthorRepository
{
    public async Task<List<Author>> GetAllAsync()
    {
        return await context.Authors.ToListAsync();
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        return await context.Authors.FindAsync(id);
    }

    public async Task<Author> CreateAsync(Author author)
    {
        await context.Authors.AddAsync(author);
        await context.SaveChangesAsync();
        return author;
    }

    public async Task<Author?> UpdateAsync(int id, UpdateAuthorRequestDto updateDto)
    {
        var authorModel = await context.Authors.FirstOrDefaultAsync(x => x.Id == id);
        
        if(authorModel == null)
        {
            return null;
        }
        
        authorModel.AuthorKey = updateDto.AuthorKey;
        authorModel.Pseudonym = updateDto.Pseudonym;
        authorModel.FirstName = updateDto.FirstName;
        authorModel.LastName = updateDto.LastName;
        authorModel.BirthDate = updateDto.BirthDate;
        authorModel.Biography = updateDto.Biography;
        
        await context.SaveChangesAsync();
        
        return authorModel;
    }

    public async Task<Author?> DeleteAsync(int id)
    {
        var authorModel = await context.Authors.FirstOrDefaultAsync(x => x.Id == id);
        
        if(authorModel == null)
        {
            return null;
        }
        
        context.Authors.Remove(authorModel);
        await context.SaveChangesAsync();
        return authorModel;
    }
}