using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealStateFollowUp.Data;
using RealStateFollowUp.Models;

namespace RealStateFollowUp.Controllers
{
    public class NeighborhoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NeighborhoodsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Neighborhood.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Neighborhood neighborhood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(neighborhood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(neighborhood);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhood
                .FirstOrDefaultAsync(m => m.ID == id);
            if (neighborhood == null)
            {
                return NotFound();
            }

            return View(neighborhood);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhood.FindAsync(id);
            if (neighborhood == null)
            {
                return NotFound();
            }
            return View(neighborhood);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Neighborhood neighborhood)
        {
            if (id != neighborhood.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(neighborhood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NeighborhoodExists(neighborhood.ID))
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
            return View(neighborhood);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhood
                .FirstOrDefaultAsync(m => m.ID == id);
            if (neighborhood == null)
            {
                return NotFound();
            }

            return View(neighborhood);
        }

        // POST: PropertyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var neighborhood = await _context.Neighborhood.FindAsync(id);
            _context.Neighborhood.Remove(neighborhood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NeighborhoodExists(int id)
        {
            return _context.Neighborhood.Any(e => e.ID == id);
        }


    }
}