using DbLibrary;
using InventoryHelper;
using InventoryModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

Program1.BuildOptions();
Program1.EnsureItems();
Program1.UpdateItems();
//Program1.DeleteAllItems();
//InventoryDbContext.DisplayConnectionString();
public static class Program1
{
    private static IConfigurationRoot _configuration;

    private static DbContextOptionsBuilder<InventoryDbContext> _optionsBuilder;

    private const string _systemUserId = "2fd28110-93d0-427d-9207-d55dbca680fa";
    private const string _loggedInUserId = "e2eb8989-a81a-4151-8e86-eb95a7961da2";


    public static void BuildOptions()
    {
        _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
        _optionsBuilder = new DbContextOptionsBuilder<InventoryDbContext>();
        _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AuthInventoryManager"));

    }

    public static void EnsureItem(string name, string description, string notes)
    {
        Random r = new Random();
        using var db = new InventoryDbContext(_optionsBuilder.Options);
        // determine if item exists:
        var existigItem = db.Items.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

        if (existigItem == null)
        {
            // doesn't exist, add it.

            var item = new Item()
            {
                Name = name,
                CreatedByUserId = _loggedInUserId,
                IsActive = true,
                Quantity = r.Next(1,1000),
                Description = description,
                Notes = notes
            };

            db.Items.Add(item);
            db.SaveChanges();
        }
    }

    public static void UpdateItems()
    {
        using (var db = new InventoryDbContext(_optionsBuilder.Options))
        {
            var items = db.Items.ToList();

            foreach (var item in items)
            {
                item.CurrentOrFinalPrice = 9.99M;
            }
            db.Items.UpdateRange(items);
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
        EnsureItem("Batman Begins", "You either die the hero or live long enough to see yourself become the villain", "Christian Bale, Katie Holmes");
        EnsureItem("Inception", "You mustn't be afraid to dream a little bigger,darling", "Leonardo DiCaprio, Tom Hardy, Joseph Gordon - Levitt");
        EnsureItem("Remember the Titans", "Left Side, Strong Side", "Denzell Washington, Will Patton");
        EnsureItem("Star Wars: The Empire Strikes Back", "He will join us or die, master", "Harrison Ford, Carrie Fisher, Mark Hamill");
        EnsureItem("Top Gun", "I feel the need, the need for speed!", "Tom Cruise, Anthony Edwards, Val Kilmer");
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
