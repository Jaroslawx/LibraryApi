using LibraryApi.Data;
using LibraryApi.Dtos.Author;
using LibraryApi.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers;

[Route("LibraryApi/author")]
[ApiController]
public class AuthorController (ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var authors = await context.Authors.ToListAsync();
        var authorsDto = authors.Select(s => s.ToAuthorDto());

        return Ok(authorsDto);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var author = await context.Authors.FindAsync(id);

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
        await context.Authors.AddAsync(authorModel);
        await context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetById), new { id = authorModel.Id }, authorModel.ToAuthorDto());
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAuthorRequestDto updateDto)
    {
        var authorModel = await context.Authors.FirstOrDefaultAsync(x => x.Id == id);

        if (authorModel == null)
        {
            return NotFound();
        }
        
        authorModel.FirstName = updateDto.FirstName;
        authorModel.LastName = updateDto.LastName;
        
        await context.SaveChangesAsync();

        return Ok(authorModel.ToAuthorDto());
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var authorModel = await context.Authors.FirstOrDefaultAsync(x => x.Id == id);

        if (authorModel == null)
        {
            return NotFound();
        }
        
        context.Authors.Remove(authorModel);
        await context.SaveChangesAsync();

        return NoContent();
    }
}