using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models;

public class Author
{
    [Key]
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Book> Books { get; set; }
}