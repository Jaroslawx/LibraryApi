using LibraryApi.Data.Enum;

namespace LibraryApi.Dtos.Book;

public class UpdateBookRequestDto
{
    public string? Title { get; set; }
    public BookGenre Genre { get; set; }
    public int AuthorId { get; set; }
}