using LibraryApi.Data.Enum;

namespace LibraryApi.Dtos.Book;

public class UpdateBookRequestDto
{
    public string BookKey { get; set; }
    public string? Title { get; set; }
    public string[]? Subjects { get; set; }
    public DateTime? PublishedDate { get; set; }
    public string? Description { get; set; }
    public int AuthorId { get; set; }
}