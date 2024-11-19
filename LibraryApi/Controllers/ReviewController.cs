using LibraryApi.Data;
using LibraryApi.Dtos.Review;
using LibraryApi.Interfaces;
using LibraryApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[Route("LibraryApi/review")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewRepository _reviewRepo;
    private readonly IBookRepository _bookRepo;
    public ReviewController(IReviewRepository reviewRepo, IBookRepository bookRepo)
    {
        _reviewRepo = reviewRepo;
        _bookRepo = bookRepo;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reviews = await _reviewRepo.GetAllAsync();
        var reviewsDto = reviews.Select(s => s.ToReviewDto());

        return Ok(reviewsDto);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var review = await _reviewRepo.GetByIdAsync(id);

        if (review == null)
        {
            return NotFound();
        }

        return Ok(review.ToReviewDto());
    }
    
    
    [HttpPost("{bookId}")]
    public async Task<IActionResult> Create([FromRoute] int bookId, CreateReviewDto reviewDto)
    {
        if (!await _bookRepo.BookExistsAsync(bookId))
        {
            return BadRequest("Book does not exist.");
        }
        
        var reviewModel = reviewDto.ToReviewFromCreate(bookId);
        await _reviewRepo.CreateAsync(reviewModel);
        
        return CreatedAtAction(nameof(GetById), new { id = reviewModel.Id }, reviewModel.ToReviewDto());
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var reviewModel = await _reviewRepo.DeleteAsync(id);

        if (reviewModel == null)
        {
            return NotFound("Review does not exist.");
        }

        return Ok(reviewModel);
    }
    
}