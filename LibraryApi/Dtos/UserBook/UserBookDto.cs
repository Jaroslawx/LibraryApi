using LibraryApi.Data.Enum;

namespace LibraryApi.Dtos.UserBook;

public class UserBookDto
{
    public int Id { get; init; }
    public int BookId { get; set; }
    public Models.Book? Book { get; set; }
    public string? UserId { get; set; }
    public BookStatus Status { get; set; }
    public string? Note { get; set; }
    public Priority? Priority { get; set; }
    public DateTime? LastUpdated { get; set; }
}