namespace LibraryApi.Dtos.Author;

public class AuthorDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Models.Book> Books { get; set; }
}