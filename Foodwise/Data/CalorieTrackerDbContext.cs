using Foodwise.Models;
using Microsoft.EntityFrameworkCore;
namespace Foodwise.Data
  
{
    public class CalorieTrackerDbContext : DbContext
    {
        public CalorieTrackerDbContext(DbContextOptions<CalorieTrackerDbContext> options) : base (options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealProduct> MealProducts { get; set; }
        public DbSet<TodayMeals> TodayMeals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MealProduct>()
                .HasOne(mp => mp.Product)
                .WithMany()
                .HasForeignKey(mp => mp.ProductId)
                .IsRequired();

            modelBuilder.Entity<MealProduct>()
                .HasOne(mp => mp.Meal)
                .WithMany(m => m.MealProducts)
                .HasForeignKey(mp => mp.MealId)
                .IsRequired();

            modelBuilder.Entity<MealProduct>()
                .Property(mp => mp.Quantity)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
