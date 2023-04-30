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

                return View(meals);
            }
        }
    }
