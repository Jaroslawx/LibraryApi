using LibraryApi.Data;
using LibraryApi.Interfaces;
using LibraryApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[Route("LibraryApi/book")]
[ApiController]
public class BookController(IBookRepository bookRepo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await bookRepo.GetAllAsync();
        var booksDto = books.Select(s => s.ToBookDto());

        return Ok(booksDto);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var book = await bookRepo.GetByIdAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return Ok(book.ToBookDto());
    }
}