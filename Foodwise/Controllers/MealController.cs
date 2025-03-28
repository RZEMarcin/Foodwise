﻿using Foodwise.Data;
using Foodwise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodwise.Controllers
{
    public class MealController : Controller
    {
        private readonly CalorieTrackerDbContext _context;

        public MealController(CalorieTrackerDbContext context)
        {
            _context = context;
        }

        // GET: Meal
        public async Task<IActionResult> Index()
        {
            List<Meal> meals = await _context.Meals
                .Include(m => m.MealProducts)
                    .ThenInclude(mp => mp.Product)
                .ToListAsync();

            return View(meals);
        }

        // GET: Meal/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals
                .Include(m => m.MealProducts)
                .ThenInclude(mp => mp.Product)
                .FirstOrDefaultAsync(m => m.Id == id);



            if (meal == null)
            {
                return NotFound();
            }


            return View(meal);
        }

        // GET: Meal/Create
        public IActionResult Create()
        {
            ViewBag.Products = new SelectList(_context.Products);
            return View();
        }

        // POST: Meal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Meal meal, int[] ProductIds, int[] Weights)
        {
            if (ModelState.IsValid)
            {
                meal.MealProducts = new List<MealProduct>();
                for (int i = 0; i < ProductIds.Length; i++)
                {
                    var product = await _context.Products.FindAsync(ProductIds[i]);
                    if (product != null)
                    {
                        meal.MealProducts.Add(new MealProduct { Meal = meal, Product = product, Weight = Weights[i] });
                    }
                }
                _context.Add(meal);
                await _context.SaveChangesAsync();
                TempData["success"] = "Meal has been created successfully";
                return RedirectToAction("Index","TodayMeals");
            }
            ViewBag.Products = new SelectList(_context.Products);
            return View(meal);
        }

        // GET: Meal/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals
                .Include(m => m.MealProducts)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (meal == null)
            {
                return NotFound();
            }

            ViewBag.Products = new SelectList(_context.Products);
            return View(meal);
        }

        // POST: Meal/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Meal meal, int[] ProductIds, int[] Weights)
        {
            if (id != meal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var dbMeal = await _context.Meals
                        .Include(m => m.MealProducts)
                        .FirstOrDefaultAsync(m => m.Id == meal.Id);

                    if (dbMeal == null)
                    {
                        return NotFound();
                    }

                    dbMeal.Name = meal.Name;
                    dbMeal.DateTime = meal.DateTime;


                    dbMeal.MealProducts = new List<MealProduct>();
                    for (int i = 0; i < ProductIds.Length; i++)
                    {
                        var product = await _context.Products.FindAsync(ProductIds[i]);
                        if (product != null)
                        {
                            dbMeal.MealProducts.Add(new MealProduct { Meal = dbMeal, Product = product, Weight = Weights[i] });
                        }
                    }

                    _context.Update(dbMeal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealExists(meal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["success"] = "Meal has been updated successfully";
                return RedirectToAction("Index", "TodayMeals");
            }

            ViewBag.Products = new SelectList(_context.Products);
            return View(meal);
        }


        // GET: Meal/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals
                .Include(m => m.MealProducts)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // POST: Meal/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meal = await _context.Meals.FindAsync(id);
            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();
            TempData["success"] = "Meal has been deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool MealExists(int id)
        {
            return _context.Meals.Any(e => e.Id == id);
        }
        // GET: Meal/AddProducts
        public IActionResult AddProducts(int id)
        {
            var meal = _context.Meals.Include(m => m.MealProducts).ThenInclude(mp => mp.Product).FirstOrDefault(m => m.Id == id);
            if (meal == null)
            {
                return NotFound();
            }

            var productOptions = _context.Products.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name }).ToList();
            var model = new AddProductsViewModel { MealId = meal.Id, ProductOptions = productOptions };

            return View(model);
        }
        // Post: Meal/AddProducts
        [HttpPost]
        public IActionResult AddProducts(MealProduct mealProduct)
        {
            if (ModelState.IsValid)
            {
                var product = _context.Products.Find(mealProduct.ProductId);
                if (product == null)
                {
                    ModelState.AddModelError("ProductId", "Invalid product selection.");
                }
                else
                {
                    mealProduct.Id = 0;
                    mealProduct.Weight = mealProduct.Weight > 0 ? mealProduct.Weight : 100;
                    mealProduct.Kcal = product.Calories * mealProduct.Weight * mealProduct.Quantity / 100;
                    mealProduct.Protein = product.Protein * mealProduct.Weight * mealProduct.Quantity / 100;
                    mealProduct.Carbohydrates = product.Carbohydrates * mealProduct.Weight * mealProduct.Quantity / 100;
                    mealProduct.Fat = product.Fat * mealProduct.Weight * mealProduct.Quantity / 100;
                    _context.MealProducts.Add(mealProduct);
                    _context.SaveChanges();
                    TempData["success"] = "Product has been added successfully";
                    return RedirectToAction("Index","TodayMeals");
                }
            }

            var productOptions = _context.Products.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name }).ToList();
            var model = new AddProductsViewModel { MealId = mealProduct.MealId, ProductOptions = productOptions };
            return View(model);
        }

        // GET: Meal/RemoveProducts
        [HttpGet]
        public async Task<IActionResult> RemoveProducts(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealProduct = await _context.MealProducts
                .Include(mp => mp.Meal)
                .Include(mp => mp.Product)
                .FirstOrDefaultAsync(mp => mp.Id == id);

            if (mealProduct == null)
            {
                return NotFound();
            }

            return View(mealProduct);
        }

        // POST: Meal/RemoveProducts
        [HttpPost, ActionName("RemoveProducts")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveProductsConfirmed(int id)
        {
            var mealProduct = await _context.MealProducts.FindAsync(id);

            if (mealProduct == null)
            {
                return NotFound();
            }

            _context.MealProducts.Remove(mealProduct);
            await _context.SaveChangesAsync();
            TempData["success"] = "Product has been removed successfully";
            return RedirectToAction(nameof(Index), new { id = mealProduct.MealId });
        }


    }


}


