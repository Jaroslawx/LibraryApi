using LibraryApi.Data.Enum;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Make sure the database is updated
            context.Database.Migrate();

            // Check if there is no data already
            if (context.Books.Any())
            {
                return; // If there is already data, we stop
            }
            
            // Create example authors
            var author1 = new Author
            {
                Pseudonym = "J.K. Rowling",
                FirstName = "Joanne",
                LastName = "Rowling",
                BirthDate = new DateTime(1965, 7, 31),
                Biography = "J.K. Rowling is a British author, best known for writing the Harry Potter series."
            };

            var author2 = new Author
            {
                Pseudonym = "George R. R. Martin",
                FirstName = "George",
                LastName = "Martin",
                BirthDate = new DateTime(1948, 9, 20),
                Biography = "George R. R. Martin is an American novelist and short story writer, famous for the 'A Song of Ice and Fire' series."
            };

            context.Authors.AddRange(author1, author2);
            context.SaveChanges();

            // Create example books
            var book1 = new Book
            {
                Title = "Harry Potter and the Sorcerer's Stone",
                Subjects = new string[] { "Fantasy", "Adventure", "Magic" },
                PublishedDate = new DateTime(1997, 6, 26),
                Description = "The first book in the Harry Potter series, following the journey of a young wizard.",
                AuthorId = author1.Id
            };

            var book2 = new Book
            {
                Title = "A Game of Thrones",
                Subjects = new string[] { "Fantasy", "Epic", "Drama" },
                PublishedDate = new DateTime(1996, 8, 6),
                Description = "The first book in the A Song of Ice and Fire series, setting the stage for a brutal battle for the throne.",
                AuthorId = author2.Id
            };

            context.Books.AddRange(book1, book2);
            context.SaveChanges();

            // Create example reviews
            var review1 = new Review
            {
                BookId = book1.Id,
                Reviewer = "Alice",
                Comment = "A magical start to an unforgettable series.",
                Rating = 9
            };

            var review2 = new Review
            {
                BookId = book2.Id,
                Reviewer = "Bob",
                Comment = "A gripping tale full of twists and turns.",
                Rating = 8
            };

            context.Reviews.AddRange(review1, review2);
            context.SaveChanges();
        }
    }
}
