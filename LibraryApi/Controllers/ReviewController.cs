using LibraryApi.Data;
using LibraryApi.Interfaces;
using LibraryApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[Route("LibraryApi/review")]
[ApiController]
public class ReviewController (IReviewRepository reviewRepo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reviews = await reviewRepo.GetAllAsync();
        var reviewsDto = reviews.Select(s => s.ToReviewDto());

        return Ok(reviewsDto);
    }
}