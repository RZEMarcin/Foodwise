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
    }
}
