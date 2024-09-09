using LibraryApi.Data;
using LibraryApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[Route("LibraryApi/review")]
[ApiController]
public class ReviewController (ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var reviews = context.Reviews.ToList()
            .Select(s => s.ToReviewDto());

        return Ok(reviews);
    }
}