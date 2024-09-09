using LibraryApi.Data;
using LibraryApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[Route("LibraryApi/book")]
[ApiController]
public class BookController(ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var books = context.Books.ToList()
            .Select(s => s.ToBookDto());

        return Ok(books);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var book = context.Books.Find(id);

        if (book == null)
        {
            return NotFound();
        }

        return Ok(book.ToBookDto());
    }
}