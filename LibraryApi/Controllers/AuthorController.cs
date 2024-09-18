using LibraryApi.Data;
using LibraryApi.Dtos.Author;
using LibraryApi.Interfaces;
using LibraryApi.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers;

[Route("LibraryApi/author")]
[ApiController]
public class AuthorController (IAuthorRepository authorRepo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var authors = await authorRepo.GetAllAsync();
        var authorsDto = authors.Select(s => s.ToAuthorDto());

        return Ok(authorsDto);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var author = await authorRepo.GetByIdAsync(id);

        if (author == null)
        {
            return NotFound();
        }

        return Ok(author.ToAuthorDto());
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAuthorRequestDto authorDto)
    {
        var authorModel = authorDto.ToAuthorFromCreateDto();
        await authorRepo.CreateAsync(authorModel);
        
        return CreatedAtAction(nameof(GetById), new { id = authorModel.Id }, authorModel.ToAuthorDto());
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAuthorRequestDto updateDto)
    {
        var authorModel = await authorRepo.UpdateAsync(id, updateDto);

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
        var authorModel = await authorRepo.GetByIdAsync(id);

        if (authorModel == null)
        {
            return NotFound();
        }
        
        await authorRepo.DeleteAsync(id);

        return NoContent();
    }
}