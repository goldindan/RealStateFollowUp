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
    public class ClientRequestStatusesController : Controller
    {
        private ApplicationDbContext _context;

        public ClientRequestStatusesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientRequestStatus.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientRequestStatus = await _context.ClientRequestStatus
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clientRequestStatus == null)
            {
                return NotFound();
            }

            return View(clientRequestStatus);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(ClientRequestStatus clientRequestStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientRequestStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientRequestStatus);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientRequestStatus = await _context.ClientRequestStatus.FindAsync(id);
            if (clientRequestStatus == null)
            {
                return NotFound();
            }
            return View(clientRequestStatus);
        }

        // POST: PropertyTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClientRequestStatus clientRequestStatus)
        {
            if (id != clientRequestStatus.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientRequestStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientRequestStatusExists(clientRequestStatus.ID))
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
            return View(clientRequestStatus);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientRequestStatus = await _context.ClientRequestStatus
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clientRequestStatus == null)
            {
                return NotFound();
            }

            return View(clientRequestStatus);
        }

        private bool ClientRequestStatusExists(int id)
        {
            return _context.ClientRequestStatus.Any(e => e.ID == id);
        }

    }
}