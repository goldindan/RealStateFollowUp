using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealStateFollowUp.Data;
using RealStateFollowUp.Models;
using RealStateFollowUp.Models.ClientViewModels;

namespace RealStateFollowUp.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var clients = _context.Client.Include(s => s.Agent);
            return View(await clients.ToListAsync());
        }

        public IActionResult Create()
        {
            ClientAndAgentViewModel clientAndAgentViewModel = new ClientAndAgentViewModel()
            {
                AgentList = _context.Agent.ToList(),
                Client = new Client()
            };
            return View(clientAndAgentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.Include(s=>s.Agent)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClientAndAgentViewModel clientAndAgentViewModel = new ClientAndAgentViewModel()
            {
                AgentList = _context.Agent.ToList(),
                Client = await _context.Client.Include(s => s.Agent).FirstOrDefaultAsync(s => s.ID == id)
            };

            //var client = await _context.Client.Include(s=>s.Agent).FirstOrDefaultAsync(s=>s.ID == id);
            if (clientAndAgentViewModel.Client == null)
            {
                return NotFound();
            }
            return View(clientAndAgentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Client client)
        {
            if (id != client.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ID))
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
            return View(client);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.Include(s=>s.Agent)
                .FirstOrDefaultAsync(m => m.ID == id);
            
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: PropertyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Client.FindAsync(id);
            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.ID == id);
        }


    }
}