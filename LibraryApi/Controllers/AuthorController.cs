using LibraryApi.Data;
using LibraryApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[Route("LibraryApi/author")]
[ApiController]
public class AuthorController (ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var authors = context.Authors.ToList()
            .Select(s => s.ToAuthorDto());

        return Ok(authors);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] long id)
    {
        var author = context.Authors.Find(id);

        if (author == null)
        {
            return NotFound();
        }

        return Ok(author.ToAuthorDto());
    }
}