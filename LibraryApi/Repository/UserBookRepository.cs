﻿using LibraryApi.Data;
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
}