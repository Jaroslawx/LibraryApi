using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Models;

public class Book
{
    [Key]
    public int Id { get; init; }

    [Required]
    public string BookKey { get; set; }

    [StringLength(75, ErrorMessage = "Title can't be longer than 75 characters.")]
    public string? Title { get; set; }

    public string[]? Subjects { get; set; }
    
    public DateTime? PublishedDate { get; set; }

    [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
    public string? Description { get; set; }

    [ForeignKey("Author")]
    public int AuthorId { get; set; }
    public Author? Author { get; set; }
    
    public ICollection<Review>? Reviews { get; set; }
    
    [Range(0, 10, ErrorMessage = "Rating must be between 0 and 10.")]
    public decimal AverageRating
    {
        get
        {
            if (Reviews == null || Reviews.Count == 0)
                return 0;

            decimal totalRating = Reviews.Sum(r => r.Rating);
            return Math.Round(totalRating / Reviews.Count, 2);
        }
        private set { }
    }
}