using DbLibrary;
using InventoryDataMigrator;
using InventoryHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

class Program
{
    static IConfigurationRoot _configuration;
    static DbContextOptionsBuilder<InventoryDbContext> _optionsBuilder;
    static void BuildOptions()
    {
        _configuration = ConfigurationBuilderSingleton.
        ConfigurationRoot;
        _optionsBuilder = new DbContextOptionsBuilder<InventoryDbContext>();
        _optionsBuilder.UseSqlServer(_configuration.GetConnectionString
        ("AuthInventoryManager"));

        Console.WriteLine(_configuration.GetConnectionString("AuthInventoryManager"));
    }
    static void Main(string[] args)
    {
        BuildOptions();
        ApplyMigrations();
        ExecuteCustomSeedData();
    }

    private static void ExecuteCustomSeedData()
    {
        using (var context = new InventoryDbContext(_optionsBuilder.Options))
        {
            var categories = new BuildCategories(context);
            categories.ExecuteSeed();

            var items = new BuildItems(context);
            items.ExecuteSeed();

        }
    }

    private static void ApplyMigrations()
    {
       using(var db = new InventoryDbContext(_optionsBuilder.Options))
        {
            db.Database.Migrate();
        }
    }
}