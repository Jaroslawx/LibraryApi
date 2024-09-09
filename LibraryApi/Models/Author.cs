using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models;

public class Author
{
    [Key]
    public int Id { get; set; }
    [StringLength(50, ErrorMessage = "First name can't be longer than 50 characters.")]
    public string? FirstName { get; set; }
    [StringLength(50, ErrorMessage = "Last name can't be longer than 50 characters.")]
    public string? LastName { get; set; }
    public List<Book>? Books { get; set; }
}