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
        }
    }
}
