using InventoryModel;
using InventoryModel.DTOs;
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
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<GetItemsForListingDto> ItemsForListing { get; set; }
        public virtual DbSet<AllItemsPipeDelimitedStringDTO> AllItemsOutput { get; set; }
        public virtual DbSet<GetItemsTotalValueDTO> GetItemsTotalValues { get; set; }
        public virtual DbSet<FullItemDetailDTO> FullItemDetailDTOs { get; set; }


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
            // Defining the Many to Many Relationship by overridig the OnModelCreate method
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

            modelBuilder.Entity<GetItemsForListingDto>(x =>
            {
                x.HasNoKey();
                x.ToView("ItemsForListing");
            });

            modelBuilder.Entity<AllItemsPipeDelimitedStringDTO>(x =>
            {
                x.HasNoKey();
                x.ToView("AllItemsOutput");
            });

            modelBuilder.Entity<GetItemsTotalValueDTO>(x =>
            {
                x.HasNoKey();
                x.ToView("GetItemsTotalValues");
            });

            modelBuilder.Entity<FullItemDetailDTO>(x =>
            {
                x.HasNoKey();
                x.ToView("FullItemDetailDTOs");
            });

            // Seed Data usig the FLUENT Api
            var genreCreateDate = new DateTime(2021, 01, 01);
            modelBuilder.Entity<Genre>(x =>
            {
                x.HasData(
                new Genre()
                {
                    Id = 1,
                    CreatedDate = genreCreateDate,
                    IsActive =
                true,
                    IsDeleted = false,
                    Name = "Fantasy"
                },
                new Genre()
                {
                    Id = 2,
                    CreatedDate = genreCreateDate,
                    IsActive =
                true,
                    IsDeleted = false,
                    Name = "Sci/Fi"
                },
                new Genre()
                {
                    Id = 3,
                    CreatedDate = genreCreateDate,
                    IsActive =
                true,
                    IsDeleted = false,
                    Name = "Horror"
                },
                new Genre()
                {
                    Id = 4,
                    CreatedDate = genreCreateDate,
                    IsActive =
                true,
                    IsDeleted = false,
                    Name = "Comedy"
                },
                new Genre()
                {
                    Id = 5,
                    CreatedDate = genreCreateDate,
                    IsActive =
                true,
                    IsDeleted = false,
                    Name = "Drama"
                }
                );
            });
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