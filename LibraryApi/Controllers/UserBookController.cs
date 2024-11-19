using LibraryApi.Dtos.UserBook;
using LibraryApi.Interfaces;
using LibraryApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[Route("LibraryApi/userbook")]
[ApiController]
public class UserBookController : ControllerBase
{
    private readonly IUserBookRepository _userBookRepo;
    public UserBookController(IUserBookRepository userBookRepo)
    {
        _userBookRepo = userBookRepo;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userBooks = await _userBookRepo.GetAllAsync();
        var userBooksDto = userBooks.Select(s => s.ToUserBookDto());

        return Ok(userBooksDto);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var userBook = await _userBookRepo.GetByIdAsync(id);

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
        var userBookModel = await _userBookRepo.UpdateAsync(id, updateDto);

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
        var userBook = await _userBookRepo.GetByIdAsync(id);

        if (userBook == null)
        {
            return NotFound();
        }

        await _userBookRepo.DeleteAsync(id);

        return NoContent();
    }
}