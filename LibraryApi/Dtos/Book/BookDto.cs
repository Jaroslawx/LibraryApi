using LibraryApi.Dtos.Review;

namespace LibraryApi.Dtos.Book;

public class BookDto
{
    public int Id { get; set; }
    public string BookKey { get; set; }
    public string? Title { get; set; }
    public string[]? Subjects { get; set; }
    public DateTime? PublishedDate { get; set; }
    public string? Description { get; set; }
    public int AuthorId { get; set; }
    public Models.Author? Author { get; set; }
    public List<ReviewDto>? Reviews { get; set; }
    public decimal AverageRating { get; set; }
}