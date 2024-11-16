using LibraryApi.Data.Enum;

namespace LibraryApi.Dtos.Book;

public class AddToBookshelfRequestDto
{
    public string? UserId { get; set; }
    public BookStatus Status { get; set; }
    public string? Note { get; set; }
}