namespace LibraryApi.Dtos.Review;

public class UpdateReviewRequestDto
{
    public int BookId { get; set; }
    public string Reviewer { get; set; }
    public string? Comment { get; set; }
    public int Rating { get; set; }
}