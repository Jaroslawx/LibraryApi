using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryApi.Data.Enum;

namespace LibraryApi.Models;

public class UserBook
{
    [Key]
    public int Id { get; init; }
    
    [ForeignKey("Book")]
    public int BookId { get; set; }
    public Book? Book { get; set; }
    
    [Required]
    public string? UserId { get; set; }
    
    [Required]
    public BookStatus Status { get; set; }
    
    public string? Note { get; set; }
    
    public DateTime? UpdateDate { get; set; }
    
    
}