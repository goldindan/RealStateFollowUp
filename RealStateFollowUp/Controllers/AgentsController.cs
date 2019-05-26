using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealStateFollowUp.Data;

namespace RealStateFollowUp.Controllers
{
    public class AgentsController : Controller
    {
        private ApplicationDbContext _context;

        public AgentsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agent.ToListAsync());
        }


    }
}