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
    public class TypeBevaragesController : Controller
    {
        private readonly RestaurantDbContext _context;

        public TypeBevaragesController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: TypeBevarages
        public async Task<IActionResult> Index()
        {
              return View(await _context.TypeDrinks.ToListAsync());
        }

        // GET: TypeBevarages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeDrinks == null)
            {
                return NotFound();
            }

            var typeBevarage = await _context.TypeDrinks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeBevarage == null)
            {
                return NotFound();
            }

            return View(typeBevarage);
        }

        // GET: TypeBevarages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeBevarages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] TypeBevarage typeBevarage)
        {
            if (ModelState.IsValid)
            {
                typeBevarage.RegisterON=DateTime.Now;
                _context.TypeDrinks.Add(typeBevarage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeBevarage);
        }

        // GET: TypeBevarages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeDrinks == null)
            {
                return NotFound();
            }

            var typeBevarage = await _context.TypeDrinks.FindAsync(id);
            if (typeBevarage == null)
            {
                return NotFound();
            }
            return View(typeBevarage);
        }

        // POST: TypeBevarages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TypeBevarage typeBevarage)
        {
            if (id != typeBevarage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    typeBevarage.RegisterON = DateTime.Now;
                    _context.TypeDrinks.Update(typeBevarage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeBevarageExists(typeBevarage.Id))
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
            return View(typeBevarage);
        }

        // GET: TypeBevarages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeDrinks == null)
            {
                return NotFound();
            }

            var typeBevarage = await _context.TypeDrinks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeBevarage == null)
            {
                return NotFound();
            }

            return View(typeBevarage);
        }

        // POST: TypeBevarages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeDrinks == null)
            {
                return Problem("Entity set 'RestaurantDbContext.TypeDrinks'  is null.");
            }
            var typeBevarage = await _context.TypeDrinks.FindAsync(id);
            if (typeBevarage != null)
            {
                _context.TypeDrinks.Remove(typeBevarage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeBevarageExists(int id)
        {
          return _context.TypeDrinks.Any(e => e.Id == id);
        }
    }
}
