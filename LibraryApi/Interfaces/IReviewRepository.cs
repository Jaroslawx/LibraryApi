using LibraryApi.Dtos.Review;
using LibraryApi.Models;

namespace LibraryApi.Interfaces;

public interface IReviewRepository
{
    Task<List<Review>> GetAllAsync();
    Task<Review?> GetByIdAsync(int id);
    Task<Review> CreateAsync(Review review);
    Task<Review?> UpdateAsync(int id, UpdateReviewRequestDto updateDto);
    Task<Review?> DeleteAsync(int id);
}