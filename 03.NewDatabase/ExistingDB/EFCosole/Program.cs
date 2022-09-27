using EFCosole;
using EFDbLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static System.Console;

Program1.BuildOptions();
Program1.ListPeople();




public static class Program1
{
    private static IConfigurationRoot? _configuration;
    private static DbContextOptionsBuilder<AdventureWorks2019Context>? _optionsBuilder;




    /// <summary>
    /// Method sets the options builder to a new instace of the optionsBuilder on the DbContext
    /// ad then tells the builder to use Sqlserver with the configuration settings for the connection strig
    /// </summary>
    public static void BuildOptions()
    {
        _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
        _optionsBuilder = new DbContextOptionsBuilder<AdventureWorks2019Context>();
        _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AdventureWorks"));
    }

   

    public static void ListPeople()
    {
        using (var db = new AdventureWorks2019Context(_optionsBuilder?.Options))
        {
            var people = db.People.OrderByDescending(x => x.LastName).Take(20).ToList();

            foreach (var person in people)
            {
                WriteLine($"{person.FirstName}  {person.LastName}");
            }
        }
    }
}
