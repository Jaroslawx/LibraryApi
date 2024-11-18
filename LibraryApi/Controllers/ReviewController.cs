using LibraryApi.Data;
using LibraryApi.Dtos.Review;
using LibraryApi.Interfaces;
using LibraryApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[Route("LibraryApi/review")]
[ApiController]
public class ReviewController (IReviewRepository reviewRepo, IBookRepository bookRepo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reviews = await reviewRepo.GetAllAsync();
        var reviewsDto = reviews.Select(s => s.ToReviewDto());

        return Ok(reviewsDto);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var review = await reviewRepo.GetByIdAsync(id);

        if (review == null)
        {
            return NotFound();
        }

        return Ok(review.ToReviewDto());
    }
    
    
    [HttpPost("{bookId}")]
    public async Task<IActionResult> Create([FromRoute] int bookId, CreateReviewDto reviewDto)
    {
        if (!await bookRepo.BookExistsAsync(bookId))
        {
            return BadRequest("Book does not exist.");
        }
        
        var reviewModel = reviewDto.ToReviewFromCreate(bookId);
        await reviewRepo.CreateAsync(reviewModel);
        
        return CreatedAtAction(nameof(GetById), new { id = reviewModel.Id }, reviewModel.ToReviewDto());
    }
}