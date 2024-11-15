namespace LibraryApi.Dtos.Author;

public class AuthorDto
{
    public int Id { get; set; }
    public string AuthorKey { get; set; }
    public string Pseudonym  { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Biography { get; set; }
    public ICollection<Models.Book>? Books { get; set; }
}