using Foodwise.Data;
using Foodwise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Foodwise.Controllers
{
    
        public class TodayMealsController : Controller
        {
            private readonly CalorieTrackerDbContext _context;

            public TodayMealsController(CalorieTrackerDbContext context)
            {
                _context = context;
            }

        // GET: TodayMeals
        public async Task<IActionResult> Index()
        {
            DateTime today = DateTime.Today;
            List<Meal> meals = await _context.Meals
                .Include(m => m.MealProducts)
                    .ThenInclude(mp => mp.Product)
                .Where(m => m.DateTime.Date == today)
                .ToListAsync();

            var todayMeals = new TodayMeals
            {
                Date = today,
                Meals = meals
            };

            return View(todayMeals);
        }
        // GET: TodayMeals/Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var meal = await _context.Meals.FindAsync(id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // POST: TodayMeals/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meal = await _context.Meals.FindAsync(id);
            if (meal == null)
            {
                return NotFound();
            }

            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();
            TempData["success"] = "Meal has been deleted successfully";
            return RedirectToAction(nameof(Index));
        }


    }
}
