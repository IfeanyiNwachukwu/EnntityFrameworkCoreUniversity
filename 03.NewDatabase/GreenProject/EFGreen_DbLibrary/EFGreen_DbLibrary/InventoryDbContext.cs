using InventoryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace EFGreen_DbLibrary
{
    public class InventoryDbContext : DbContext
    {
        private static IConfigurationRoot _configuration;
        public virtual DbSet<Item> Items { get; set; }
        // Default constructor for when scaffolding is needed
        public InventoryDbContext()
        {

        }
        // Complex constructor for allowing Dependency Injection
        public InventoryDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                _configuration = builder.Build();
                var cnstr = _configuration.GetConnectionString("InventoryManager");
                optionsBuilder.UseSqlServer(cnstr);
            }
        }

        //public static void DisplayConnectionString()
        //{
        //    var builder = new ConfigurationBuilder()
        //                     .SetBasePath(Directory.GetCurrentDirectory())
        //                     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        //    _configuration = builder.Build();
        //    var cnstr = _configuration.GetConnectionString("InventoryManager");

        //    if(cnstr != null)
        //    {
        //        Console.WriteLine(cnstr);
        //    }
        //    else
        //    {
        //        Console.WriteLine("No connection string found");
        //    }
        //}
    }
}