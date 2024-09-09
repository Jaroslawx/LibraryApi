using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Models;

public class Review
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Book")]
    public int BookId { get; set; }
    public Book? Book { get; set; }
    [StringLength(25, ErrorMessage = "Name can't be longer than 50 characters.")]
    public string? Reviewer { get; set; }
    [StringLength(150, ErrorMessage = "Comment can't be longer than 50 characters.")]
    public string? Comment { get; set; }
    [Range(0, 10, ErrorMessage = "Rating must be between 0 and 10.")]
    public int Rating { get; set; }
    
}