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
    public class BevaragesController : Controller
    {
        private readonly RestaurantDbContext _context;

        public BevaragesController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: Bevarages
        public async Task<IActionResult> Index()
        {
            var restaurantDbContext = _context.Drinks.Include(b => b.TypeBevarages);
            return View(await restaurantDbContext.ToListAsync());
        }

        // GET: Bevarages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Drinks == null)
            {
                return NotFound();
            }

            var bevarage = await _context.Drinks
                .Include(b => b.TypeBevarages)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bevarage == null)
            {
                return NotFound();
            }

            return View(bevarage);
        }

        // GET: Bevarages/Create
        public IActionResult Create()
        {
            ViewData["TypeBevarageId"] = new SelectList(_context.TypeDrinks, "Id", "Name");
            return View();
        }

        // POST: Bevarages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,ImageUrl,Litre,Price,TypeBevarageId")] Bevarage bevarage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bevarage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeBevarageId"] = new SelectList(_context.TypeDrinks, "Id", "Name", bevarage.TypeBevarageId);
            return View(bevarage);
        }

        // GET: Bevarages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Drinks == null)
            {
                return NotFound();
            }

            var bevarage = await _context.Drinks.FindAsync(id);
            if (bevarage == null)
            {
                return NotFound();
            }
            ViewData["TypeBevarageId"] = new SelectList(_context.TypeDrinks, "Id", "Name", bevarage.TypeBevarageId);
            return View(bevarage);
        }

        // POST: Bevarages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImageUrl,Litre,Price,TypeBevarageId")] Bevarage bevarage)
        {
            if (id != bevarage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bevarage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BevarageExists(bevarage.Id))
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
            ViewData["TypeBevarageId"] = new SelectList(_context.TypeDrinks, "Id", "Name", bevarage.TypeBevarageId);
            return View(bevarage);
        }

        // GET: Bevarages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Drinks == null)
            {
                return NotFound();
            }

            var bevarage = await _context.Drinks
                .Include(b => b.TypeBevarages)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bevarage == null)
            {
                return NotFound();
            }

            return View(bevarage);
        }

        // POST: Bevarages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Drinks == null)
            {
                return Problem("Entity set 'RestaurantDbContext.Drinks'  is null.");
            }
            var bevarage = await _context.Drinks.FindAsync(id);
            if (bevarage != null)
            {
                _context.Drinks.Remove(bevarage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BevarageExists(int id)
        {
          return _context.Drinks.Any(e => e.Id == id);
        }
    }
}
