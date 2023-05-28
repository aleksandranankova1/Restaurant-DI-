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
    public class TypeMealsController : Controller
    {
        private readonly RestaurantDbContext _context;

        public TypeMealsController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: TypeMeals
        public async Task<IActionResult> Index()
        {
              return _context.TypeMeals != null ? 
                          View(await _context.TypeMeals.ToListAsync()) :
                          Problem("Entity set 'RestaurantDbContext.TypeMeals'  is null.");
        }

        // GET: TypeMeals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeMeals == null)
            {
                return NotFound();
            }

            var typeMeal = await _context.TypeMeals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeMeal == null)
            {
                return NotFound();
            }

            return View(typeMeal);
        }

        // GET: TypeMeals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeMeals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,RegisterON")] TypeMeal typeMeal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeMeal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeMeal);
        }

        // GET: TypeMeals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeMeals == null)
            {
                return NotFound();
            }

            var typeMeal = await _context.TypeMeals.FindAsync(id);
            if (typeMeal == null)
            {
                return NotFound();
            }
            return View(typeMeal);
        }

        // POST: TypeMeals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,RegisterON")] TypeMeal typeMeal)
        {
            if (id != typeMeal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeMeal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeMealExists(typeMeal.Id))
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
            return View(typeMeal);
        }

        // GET: TypeMeals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeMeals == null)
            {
                return NotFound();
            }

            var typeMeal = await _context.TypeMeals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeMeal == null)
            {
                return NotFound();
            }

            return View(typeMeal);
        }

        // POST: TypeMeals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeMeals == null)
            {
                return Problem("Entity set 'RestaurantDbContext.TypeMeals'  is null.");
            }
            var typeMeal = await _context.TypeMeals.FindAsync(id);
            if (typeMeal != null)
            {
                _context.TypeMeals.Remove(typeMeal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeMealExists(int id)
        {
          return (_context.TypeMeals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
