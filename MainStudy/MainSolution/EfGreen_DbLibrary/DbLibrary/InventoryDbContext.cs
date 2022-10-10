using InventoryModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DbLibrary
{
    public class InventoryDbContext : DbContext
    {
        private static IConfigurationRoot _configuration;
        private const string _systemUserId = "2fd28110-93d0-427d-9207-d55dbca680fa";
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryDetail> CategoryDetails { get; set; }
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
                var cnstr = _configuration.GetConnectionString("AuthInventoryManager");
                optionsBuilder.UseSqlServer(cnstr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defining the May to any Relationship by overridig the OnModelCreate method
            modelBuilder.Entity<Item>()
                .HasMany(x => x.Players)
                .WithMany(p => p.Items)
                .UsingEntity<Dictionary<string, object>>(

                "ItemPlayers",
                ip => ip.HasOne<Player>()
                .WithMany()
                .HasForeignKey("PlayerId")
                .HasConstraintName("FK_ItemPlayer_Players_PlayerId")
                .OnDelete(DeleteBehavior.Cascade),

                ip => ip.HasOne<Item>()
                .WithMany()
                .HasForeignKey("ItemId")
                .HasConstraintName("FK_PlayerItem_Items_ItemId")
                .OnDelete(DeleteBehavior.ClientCascade)
                        );
        }

        public override int SaveChanges()
        {
            var tracker = ChangeTracker;

            foreach (var entry in tracker.Entries())
            {
                if (entry.Entity is FullAuditModel)
                {
                    var referenceEntity = entry.Entity as FullAuditModel;

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            referenceEntity.CreatedDate = DateTime.Now;
                            if (string.IsNullOrWhiteSpace(referenceEntity.CreatedByUserId))
                            {
                                referenceEntity.CreatedByUserId = _systemUserId;
                            }
                            break;
                        case EntityState.Deleted:
                        case EntityState.Modified:
                            if (string.IsNullOrWhiteSpace(referenceEntity.LastModifiedUserId))
                            {
                                referenceEntity.LastModifiedUserId = _systemUserId;
                                referenceEntity.LastModifiedDate = DateTime.Now;
                            }
                            break;
                        default:
                            break;

                    }
                }
            }
            return base.SaveChanges();
        }
    }
}