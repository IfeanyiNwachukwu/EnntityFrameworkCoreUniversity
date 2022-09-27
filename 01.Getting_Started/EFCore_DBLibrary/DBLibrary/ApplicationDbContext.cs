using Microsoft.EntityFrameworkCore;

namespace DBLibrary
{
    public class ApplicationDbContext : DbContext
    {
        // Default constructor in case scaffoding is needed
        public ApplicationDbContext()
        {

        }
        // Complex constructor for allowinf Dependency Injection
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            //The DbCotextOptions parameter includes critical information such as the connection string of the database
        }
    }
}