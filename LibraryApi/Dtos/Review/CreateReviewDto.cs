namespace LibraryApi.Dtos.Review;

public class CreateReviewDto
{
    public string Reviewer { get; set; }
    public string? Comment { get; set; }
    public int Rating { get; set; }
}