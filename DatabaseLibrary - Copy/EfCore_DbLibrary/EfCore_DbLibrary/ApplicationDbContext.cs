using Microsoft.EntityFrameworkCore;

namespace EfCore_DbLibrary
{
    public class ApplicationDbContext : DbContext
    {
        // Default constructor in case scaffoding is needed
        public ApplicationDbContext()
        {

        }
        //Complex constructor for allowing Dependency injection
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            // The DbContextOptios parameter contains critical info such as the Db Connection string
        }
    }
}