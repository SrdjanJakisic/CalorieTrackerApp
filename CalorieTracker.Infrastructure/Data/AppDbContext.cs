using CalorieTracker.Domain.Entities;
using CalorieTracker.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<FoodSuggestion> FoodSuggestions { get; set; }
        public DbSet<DayEntry> DayEntries { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeItem> RecipeItems { get; set; }
        public DbSet<RecipeImage> RecipeImages { get; set; }
        public DbSet<WeightEntry> WeightEntries { get; set; }
        public DbSet<FoodServing> FoodServings { get; set; }
        public DbSet<FoodLogEntry> FoodLogEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserProfile>()
                .HasOne<ApplicationUser>()
                .WithOne()
                .HasForeignKey<UserProfile>(p => p.UserId);

            modelBuilder.Entity<FoodItem>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FoodSuggestion>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DayEntry>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DayEntry>()
                .HasIndex(x => new { x.UserId, x.Date })
                .IsUnique();

            modelBuilder.Entity<DayEntry>()
                .HasMany(x => x.Entries)
                .WithOne(x => x.DayEntry)
                .HasForeignKey(x => x.DayEntryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Recipe>()
                .HasMany(x => x.Items)
                .WithOne(x => x.Recipe)
                .HasForeignKey(x => x.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Recipe>()
                .HasMany(x => x.Images)
                .WithOne(x => x.Recipe)
                .HasForeignKey(x => x.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RecipeItem>()
                .HasOne(x => x.FoodItem)
                .WithMany()
                .HasForeignKey(x => x.FoodItemId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Recipe>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            modelBuilder.Entity<WeightEntry>()
                .HasIndex(x => new { x.UserId, x.Date })
                .IsUnique();

            modelBuilder.Entity<WeightEntry>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FoodItem>()
                .HasMany(x => x.Servings)
                .WithOne(x => x.FoodItem)
                .HasForeignKey(x => x.FoodItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FoodServing>()
                .Property(x => x.Name).HasMaxLength(50);

            modelBuilder.Entity<FoodLogEntry>()
                .HasOne(x => x.FoodItem)
                .WithMany()
                .HasForeignKey(x => x.FoodItemId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FoodLogEntry>()
                .Property(x => x.ServingName).HasMaxLength(50);
        }
    }
}
