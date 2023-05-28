using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;

namespace Restaurant.Controllers
{
    public class MealsController : Controller
    {
        private readonly RestaurantDbContext _context;

        public MealsController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: Meals
        public async Task<IActionResult> Index()
        {
            var restaurantDbContext = _context.Meals.Include(m => m.TypeMeals);
            return View(await restaurantDbContext.ToListAsync());
        }

        // GET: Meals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Meals == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals
                .Include(m => m.TypeMeals)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // GET: Meals/Create
        public IActionResult Create()
        {
            ViewData["TypeMealId"] = new SelectList(_context.TypeMeals, "Id", "Id");
            return View();
        }

        // POST: Meals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,ImageUrl,Alergens,Weight,Price,TypeMealId")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeMealId"] = new SelectList(_context.TypeMeals, "Id", "Id", meal.TypeMealId);
            return View(meal);
        }

        // GET: Meals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Meals == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals.FindAsync(id);
            if (meal == null)
            {
                return NotFound();
            }
            ViewData["TypeMealId"] = new SelectList(_context.TypeMeals, "Id", "Id", meal.TypeMealId);
            return View(meal);
        }

        // POST: Meals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,ImageUrl,Alergens,Weight,Price,TypeMealId")] Meal meal)
        {
            if (id != meal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meal);
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeMealId"] = new SelectList(_context.TypeMeals, "Id", "Id", meal.TypeMealId);
            return View(meal);
        }

        // GET: Meals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Meals == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals
                .Include(m => m.TypeMeals)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // POST: Meals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Meals == null)
            {
                return Problem("Entity set 'RestaurantDbContext.Meals'  is null.");
            }
            var meal = await _context.Meals.FindAsync(id);
            if (meal != null)
            {
                _context.Meals.Remove(meal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealExists(int id)
        {
          return (_context.Meals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
