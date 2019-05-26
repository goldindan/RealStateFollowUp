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
    public class MasterBedroomsController : Controller
    {
        private ApplicationDbContext _context;

        public MasterBedroomsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.MasterBedroom.ToListAsync());
        }
        // GET: PropertyTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masterBedroom = await _context.MasterBedroom
                .FirstOrDefaultAsync(m => m.ID == id);
            if (masterBedroom == null)
            {
                return NotFound();
            }

            return View(masterBedroom);
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
        public async Task<IActionResult> Create(MasterBedroom masterBedroom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(masterBedroom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(masterBedroom);
        }

        // GET: PropertyTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masterBedroom = await _context.MasterBedroom.FindAsync(id);
            if (masterBedroom == null)
            {
                return NotFound();
            }
            return View(masterBedroom);
        }

        // POST: PropertyTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MasterBedroom masterBedroom)
        {
            if (id != masterBedroom.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(masterBedroom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MasterBedroomExists(masterBedroom.ID))
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
            return View(masterBedroom);
        }

        // GET: PropertyTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masterBedroom = await _context.MasterBedroom
                .FirstOrDefaultAsync(m => m.ID == id);
            if (masterBedroom == null)
            {
                return NotFound();
            }

            return View(masterBedroom);
        }

        // POST: PropertyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var masterBedroom = await _context.MasterBedroom.FindAsync(id);
            _context.MasterBedroom.Remove(masterBedroom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MasterBedroomExists(int id)
        {
            return _context.MasterBedroom.Any(e => e.ID == id);
        }
    }
}
