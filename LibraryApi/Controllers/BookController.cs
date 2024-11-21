using LibraryApi.Data;
using LibraryApi.Dtos.Book;
using LibraryApi.Helpers;
using LibraryApi.Interfaces;
using LibraryApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[Route("LibraryApi/book")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepo;
    public BookController(IBookRepository bookRepo)
    {
        _bookRepo = bookRepo;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var books = await _bookRepo.GetAllAsync(query);
        
        var booksDto = books.Select(s => s.ToBookDto());

        return Ok(booksDto);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var book = await _bookRepo.GetByIdAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return Ok(book.ToBookDto());
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookDto bookDto)
    {
        var bookModel = bookDto.ToBookFromCreate();
        await _bookRepo.CreateAsync(bookModel);
        
        return CreatedAtAction(nameof(GetById), new { id = bookModel.Id }, bookModel.ToBookDto());
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookRequestDto updateDto)
    {
        var bookModel = await _bookRepo.UpdateAsync(id, updateDto);

        if (bookModel == null)
        {
            return NotFound();
        }

        return Ok(bookModel.ToBookDto());
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var bookModel = await _bookRepo.GetByIdAsync(id);

        if (bookModel == null)
        {
            return NotFound();
        }

        await _bookRepo.DeleteAsync(id);

        return NoContent();
    }
    
    [HttpPost]
    [Route("{id}")]
    public async Task<IActionResult> AddToBookshelf([FromRoute] int id, [FromBody] AddToBookshelfRequestDto requestDto)
    {
        var bookModel = await _bookRepo.AddToBookshelfAsync(id, requestDto);

        if (bookModel == null)
        {
            return NotFound();
        }

        return Ok(bookModel.ToBookDto());
    }
    
}