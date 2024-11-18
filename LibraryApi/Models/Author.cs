using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models;

public class Author
{
    [Key]
    public int Id { get; init; }
    
    [Required]
    public string OLAuthorKey { get; set; }
    
    [Required]
    [StringLength(50, ErrorMessage = "Pseudonym can't be longer than 50 characters.")]
    public string Pseudonym { get; set; }
    
    [StringLength(100, ErrorMessage = "First name can't be longer than 100 characters.")]
    public string? FirstName { get; set; }
    
    [StringLength(100, ErrorMessage = "Last name can't be longer than 100 characters.")]
    public string? LastName { get; set; }

    public DateTime? BirthDate { get; set; }

    [StringLength(500, ErrorMessage = "Biography can't be longer than 500 characters.")]
    public string? Biography { get; set; }
    
    public ICollection<Book>? Books { get; set; }
}