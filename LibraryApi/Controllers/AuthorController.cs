using LibraryApi.Data;
using LibraryApi.Dtos.Author;
using LibraryApi.Interfaces;
using LibraryApi.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers;

[Route("LibraryApi/author")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorRepository _authorRepo;
    public AuthorController(IAuthorRepository authorRepo)
    {
        _authorRepo = authorRepo;
    }
        
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var authors = await _authorRepo.GetAllAsync();
        var authorsDto = authors.Select(s => s.ToAuthorDto());

        return Ok(authorsDto);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var author = await _authorRepo.GetByIdAsync(id);

        if (author == null)
        {
            return NotFound();
        }

        return Ok(author.ToAuthorDto());
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAuthorDto authorDto)
    {
        var authorModel = authorDto.ToAuthorFromCreate();
        await _authorRepo.CreateAsync(authorModel);
        
        return CreatedAtAction(nameof(GetById), new { id = authorModel.Id }, authorModel.ToAuthorDto());
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAuthorRequestDto updateDto)
    {
        var authorModel = await _authorRepo.UpdateAsync(id, updateDto);

        if (authorModel == null)
        {
            return NotFound();
        }

        return Ok(authorModel.ToAuthorDto());
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var authorModel = await _authorRepo.GetByIdAsync(id);

        if (authorModel == null)
        {
            return NotFound();
        }
        
        await _authorRepo.DeleteAsync(id);

        return NoContent();
    }
}