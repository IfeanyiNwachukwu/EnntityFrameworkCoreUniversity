using DbLibrary;
using InventoryHelper;
using InventoryModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

Program1.BuildOptions();
Program1.EnsureItems();
Program1.DeleteAllItems();
//InventoryDbContext.DisplayConnectionString();
public static class Program1
{
    private static IConfigurationRoot _configuration;

    private static DbContextOptionsBuilder<InventoryDbContext> _optionsBuilder;



    public static void BuildOptions()
    {
        _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
        _optionsBuilder = new DbContextOptionsBuilder<InventoryDbContext>();
        _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AuthInventoryManager"));

    }

    public static void EnsureItem(string name)
    {
        using var db = new InventoryDbContext(_optionsBuilder.Options);
        // determine if item exists:
        var existigItem = db.Items.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

        if (existigItem == null)
        {
            // doesn't exist, add it.

            var item = new Item()
            {
                Name = name,
            };

            db.Items.Add(item);
            db.SaveChanges();
        }
    }

    public static void DeleteAllItems()
    {
        using (var db = new InventoryDbContext(_optionsBuilder.Options))
        {
            var items = db.Items.ToList();
            db.Items.RemoveRange(items);
            db.SaveChanges();
        }
    }
    public static void EnsureItems()
    {
        EnsureItem("Batman Begins");
        EnsureItem("Inception");
        EnsureItem("Remember the Titans");
        EnsureItem("Star Wars: The Empire Strikes Back");
        EnsureItem("Top Gun");
    }

    public static void ListInventory()
    {
        using (var db = new InventoryDbContext(_optionsBuilder.Options))
        {
            var items = db.Items.OrderBy(x => x.Name).ToList();

            items.ForEach(x => Console.WriteLine($"New Item: {x.Name}"));
        }
    }
}
