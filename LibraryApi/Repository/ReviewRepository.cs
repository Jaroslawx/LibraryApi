using LibraryApi.Data;
using LibraryApi.Dtos.Review;
using LibraryApi.Interfaces;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repository;

public class ReviewRepository (ApplicationDbContext context) : IReviewRepository
{
    public async Task<List<Review>> GetAllAsync()
    {
        return await context.Reviews.ToListAsync();
    }

    public async Task<Review?> GetByIdAsync(int id)
    {
        return await context.Reviews.FindAsync(id);
    }

    public async Task<Review> CreateAsync(Review review)
    {
        await context.Reviews.AddAsync(review);
        await context.SaveChangesAsync();
        return review;
    }

    public async Task<Review?> UpdateAsync(int id, UpdateReviewRequestDto updateDto)
    {
        var reviewModel = await context.Reviews.FirstOrDefaultAsync(x => x.Id == id);
        
        if(reviewModel == null)
        {
            return null;
        }
        
        reviewModel.BookId = updateDto.BookId;
        reviewModel.Reviewer = updateDto.Reviewer;
        reviewModel.Rating = updateDto.Rating;
        reviewModel.Comment = updateDto.Comment;
        
        await context.SaveChangesAsync();
        
        return reviewModel;
    }

    public async Task<Review?> DeleteAsync(int id)
    {
        var reviewModel = await context.Reviews.FirstOrDefaultAsync(x => x.Id == id);
        
        if(reviewModel == null)
        {
            return null;
        }
        
        context.Reviews.Remove(reviewModel);
        await context.SaveChangesAsync();
        return reviewModel;
    }
}