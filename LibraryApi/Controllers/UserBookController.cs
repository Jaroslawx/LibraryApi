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
}