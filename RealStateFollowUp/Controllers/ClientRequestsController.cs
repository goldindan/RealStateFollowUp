using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealStateFollowUp.Data;
using RealStateFollowUp.Models;
using RealStateFollowUp.Models.ClientRequestViewModel;

namespace RealStateFollowUp.Controllers
{
    public class ClientRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        [BindProperty]
        public ClientRequestDataViewModel ClientRequestDataVM { get; set; }


        [TempData]
        public String StatusMessage { get; set; }

        public ClientRequestsController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            ClientRequestDataVM = new ClientRequestDataViewModel()
            {
                ClientRequest = new ClientRequest(),
                ClientRequestStatuses = _context.ClientRequestStatus.ToList(),
                MainDirections = _context.MainDirection.ToList(),
                MasterBedrooms = _context.MasterBedroom.ToList(),
                Neighborhoods = _context.Neighborhood.ToList(),
                PropertyTypes = _context.PropertyType.ToList()
            };
        }
        public async Task<IActionResult> Index(int clientID)
        {
            ClientRequestAndClientNameViewModel clientRequestAndClientNameVM = new ClientRequestAndClientNameViewModel()
            {
                ClientRequests = await _context.ClientRequest.Where(r => r.ClientID == clientID).ToListAsync(),
                ClientName = _context.Client.Find(clientID).Name,
                ClientID = clientID
            };

            return View(clientRequestAndClientNameVM);
        }

        public IActionResult Create(int clientID)
        {
            ClientRequestDataVM.ClientRequest.ClientID = clientID;
            return View(ClientRequestDataVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create()
        {
            if (ModelState.IsValid)
            {
                if (false)
                {
                    StatusMessage = "Error : Test";
                }
                else
                {
                    _context.Add(ClientRequestDataVM.ClientRequest);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new { clientID = ClientRequestDataVM.ClientRequest.ClientID });
                }
            }

            ClientRequestDataViewModel modelVM = new ClientRequestDataViewModel()
            {
                ClientRequest = ClientRequestDataVM.ClientRequest,
                ClientRequestStatuses = await _context.ClientRequestStatus.ToListAsync(),
                MainDirections = await _context.MainDirection.ToListAsync(),
                MasterBedrooms = await _context.MasterBedroom.ToListAsync(),
                Neighborhoods = await _context.Neighborhood.ToListAsync(),
                PropertyTypes = await _context.PropertyType.ToListAsync(),
                StatusMessage = StatusMessage

            };
            return View(modelVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClientRequestDataVM.ClientRequest = await _context.ClientRequest
                                                    .Include(cr => cr.ClientRequestStatus)
                                                    .Include(cr => cr.MainDirection)
                                                    .Include(cr => cr.MasterBedroom)
                                                    .Include(cr => cr.Neighborhood)
                                                    .SingleOrDefaultAsync(cr => cr.ID == id);
            ClientRequestDataVM.ClientRequestStatuses = await _context.ClientRequestStatus.ToListAsync();
            ClientRequestDataVM.MainDirections = await _context.MainDirection.ToListAsync();
            ClientRequestDataVM.MasterBedrooms = await _context.MasterBedroom.ToListAsync();
            ClientRequestDataVM.Neighborhoods = await _context.Neighborhood.ToListAsync();
            ClientRequestDataVM.PropertyTypes = await _context.PropertyType.ToListAsync();

            if (ClientRequestDataVM.ClientRequest == null)
            {
                return NotFound();
            }

            return View(ClientRequestDataVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id != ClientRequestDataVM.ClientRequest.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ClientRequestDataVM.ClientRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientRequestExists(ClientRequestDataVM.ClientRequest.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { clientID = ClientRequestDataVM.ClientRequest.ClientID });
            }
            return View(ClientRequestDataVM);
        }

        private bool ClientRequestExists(int id)
        {
            return _context.ClientRequest.Any(e => e.ID == id);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClientRequestDataVM.ClientRequest = await _context.ClientRequest
                                                    .Include(cr => cr.ClientRequestStatus)
                                                    .Include(cr => cr.MainDirection)
                                                    .Include(cr => cr.MasterBedroom)
                                                    .Include(cr => cr.Neighborhood)
                                                    .SingleOrDefaultAsync(cr => cr.ID == id);

            if (ClientRequestDataVM.ClientRequest == null)
            {
                return NotFound();
            }

            return View(ClientRequestDataVM);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClientRequestDataVM.ClientRequest = await _context.ClientRequest
                                                    .Include(cr => cr.ClientRequestStatus)
                                                    .Include(cr => cr.MainDirection)
                                                    .Include(cr => cr.MasterBedroom)
                                                    .Include(cr => cr.Neighborhood)
                                                    .SingleOrDefaultAsync(cr => cr.ID == id);

            if (ClientRequestDataVM.ClientRequest == null)
            {
                return NotFound();
            }

            return View(ClientRequestDataVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteClientRequest(int id)
        {
            ClientRequest clientRequest = await _context.ClientRequest.FindAsync(id);

            if (clientRequest != null)
            {
                _context.ClientRequest.Remove(clientRequest);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index), new { clientID = clientRequest.ClientID });
        }
    }
}