using LibraryApi.Data.Enum;

namespace LibraryApi.Dtos.UserBook;

public class UpdateUserBookRequestDto
{
    public BookStatus Status { get; set; }
    public string? Note { get; set; }
}