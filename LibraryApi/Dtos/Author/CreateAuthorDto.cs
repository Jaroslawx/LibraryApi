namespace LibraryApi.Dtos.Author;

public class CreateAuthorDto
{
    public string? OlAuthorKey { get; set; }
    public string? Pseudonym  { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Biography { get; set; }
}