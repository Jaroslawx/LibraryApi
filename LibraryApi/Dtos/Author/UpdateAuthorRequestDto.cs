namespace LibraryApi.Dtos.Author;

public class UpdateAuthorRequestDto
{
    public string AuthorKey { get; set; }
    public string Pseudonym  { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Biography { get; set; }
}