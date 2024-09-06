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
            if (context.Books.Any() || context.Authors.Any())
            {
                return; // If there is already data, we stop
            }

            // Add authors and books
            var authors = new List<Author>
            {
                new Author
                {
                    FirstName = "George",
                    LastName = "Orwell",
                    Books = new List<Book>
                    {
                        new Book
                        {
                            Title = "1984",
                            Genre = BookGenre.Fiction,
                            Reviews = new List<Review>
                            {
                                new Review { Reviewer = "John Doe", Comment = "Great book!", Rating = 5 },
                                new Review { Reviewer = "Jane Smith", Comment = "Very thought-provoking.", Rating = 4 }
                            }
                        },
                        new Book
                        {
                            Title = "Animal Farm",
                            Genre = BookGenre.Fiction,
                            Reviews = new List<Review>
                            {
                                new Review { Reviewer = "Mark Johnson", Comment = "A timeless classic.", Rating = 5 },
                                new Review { Reviewer = "Lucy Adams", Comment = "Fantastic allegory.", Rating = 4 }
                            }
                        }
                    }
                },
                new Author
                {
                    FirstName = "J.K.",
                    LastName = "Rowling",
                    Books = new List<Book>
                    {
                        new Book
                        {
                            Title = "Harry Potter and the Philosopher's Stone",
                            Genre = BookGenre.Fantasy,
                            Reviews = new List<Review>
                            {
                                new Review { Reviewer = "Alice Brown", Comment = "Magical and exciting!", Rating = 5 },
                                new Review { Reviewer = "Tom White", Comment = "A wonderful adventure.", Rating = 5 }
                            }
                        },
                        new Book
                        {
                            Title = "Harry Potter and the Chamber of Secrets",
                            Genre = BookGenre.Fantasy,
                            Reviews = new List<Review>
                            {
                                new Review { Reviewer = "Diana Green", Comment = "Even better than the first!", Rating = 5 },
                                new Review { Reviewer = "Paul Black", Comment = "A great sequel.", Rating = 4 }
                            }
                        }
                    }
                },
                new Author
                {
                    FirstName = "J.R.R.",
                    LastName = "Tolkien",
                    Books = new List<Book>
                    {
                        new Book
                        {
                            Title = "The Hobbit",
                            Genre = BookGenre.Fantasy,
                            Reviews = new List<Review>
                            {
                                new Review { Reviewer = "Bilbo Baggins", Comment = "A fun and adventurous journey!", Rating = 5 },
                                new Review { Reviewer = "Gandalf the Grey", Comment = "An epic tale for all ages.", Rating = 5 }
                            }
                        },
                        new Book
                        {
                            Title = "The Lord of the Rings",
                            Genre = BookGenre.Fantasy,
                            Reviews = new List<Review>
                            {
                                new Review { Reviewer = "Aragorn", Comment = "An unforgettable epic.", Rating = 5 },
                                new Review { Reviewer = "Legolas", Comment = "The best fantasy series ever written.", Rating = 5 }
                            }
                        }
                    }
                }
            };

            // Add authors and books to the database
            context.Authors.AddRange(authors);
            context.SaveChanges();
        }
    }
}
