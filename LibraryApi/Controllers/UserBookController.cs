using LibraryApi.Dtos.UserBook;
using LibraryApi.Interfaces;
using LibraryApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[Route("LibraryApi/userbook")]
[ApiController]
public class UserBookController(IUserBookRepository userBookRepo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userBooks = await userBookRepo.GetAllAsync();
        var userBooksDto = userBooks.Select(s => s.ToUserBookDto());

        return Ok(userBooksDto);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var userBook = await userBookRepo.GetByIdAsync(id);

        if (userBook == null)
        {
            return NotFound();
        }

        return Ok(userBook.ToUserBookDto());
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserBookRequestDto updateDto)
    {
        var userBookModel = await userBookRepo.UpdateAsync(id, updateDto);

        if (userBookModel == null)
        {
            return NotFound();
        }

        return Ok(userBookModel.ToUserBookDto());
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var userBook = await userBookRepo.GetByIdAsync(id);

        if (userBook == null)
        {
            return NotFound();
        }

        await userBookRepo.DeleteAsync(id);

        return NoContent();
    }
}