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
    public class MainDirectionsController : Controller
    {
        private ApplicationDbContext _context;

        public MainDirectionsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.MainDirection.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainDirection = await _context.MainDirection
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mainDirection == null)
            {
                return NotFound();
            }

            return View(mainDirection);
        }

        // GET: PropertyTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PropertyTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MainDirection mainDirection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mainDirection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mainDirection);
        }

        // GET: PropertyTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainDirection = await _context.MainDirection.FindAsync(id);
            if (mainDirection == null)
            {
                return NotFound();
            }
            return View(mainDirection);
        }

        // POST: PropertyTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MainDirection mainDirection)
        {
            if (id != mainDirection.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainDirection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainDirectionExists(mainDirection.ID))
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
            return View(mainDirection);
        }

        // GET: PropertyTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainDirection = await _context.MainDirection
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mainDirection == null)
            {
                return NotFound();
            }

            return View(mainDirection);
        }

        // POST: PropertyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mainDirection = await _context.MainDirection.FindAsync(id);
            _context.MainDirection.Remove(mainDirection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainDirectionExists(int id)
        {
            return _context.MainDirection.Any(e => e.ID == id);
        }
    }
}
