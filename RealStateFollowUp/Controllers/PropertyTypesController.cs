﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealStateFollowUp.Data;
using RealStateFollowUp.Models;

namespace RealStateFollowUp.Controllers
{
    public class PropertyTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertyTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PropertyTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PropertyType.ToListAsync());
        }

        // GET: PropertyTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyType = await _context.PropertyType
                .FirstOrDefaultAsync(m => m.ID == id);
            if (propertyType == null)
            {
                return NotFound();
            }

            return View(propertyType);
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
        public async Task<IActionResult> Create(PropertyType propertyType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propertyType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propertyType);
        }

        // GET: PropertyTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyType = await _context.PropertyType.FindAsync(id);
            if (propertyType == null)
            {
                return NotFound();
            }
            return View(propertyType);
        }

        // POST: PropertyTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PropertyType propertyType)
        {
            if (id != propertyType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyTypeExists(propertyType.ID))
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
            return View(propertyType);
        }

        // GET: PropertyTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyType = await _context.PropertyType
                .FirstOrDefaultAsync(m => m.ID == id);
            if (propertyType == null)
            {
                return NotFound();
            }

            return View(propertyType);
        }

        // POST: PropertyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propertyType = await _context.PropertyType.FindAsync(id);
            _context.PropertyType.Remove(propertyType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyTypeExists(int id)
        {
            return _context.PropertyType.Any(e => e.ID == id);
        }
    }
}
