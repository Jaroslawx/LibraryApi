namespace LibraryApi.Dtos.Review;

public class ReviewDto
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public Models.Book Book { get; set; }
    public string Reviewer { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}