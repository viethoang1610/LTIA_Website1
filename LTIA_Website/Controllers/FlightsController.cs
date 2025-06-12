using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LTIA_website.Data;
using LTIA_website.Models;

namespace LTIA_website.Controllers
{
    public class FlightsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlightsController(ApplicationDbContext context)
            => _context = context;

        public async Task<IActionResult> Departures()
        {
            var flights = await _context.Flights
                .Where(f => f.Origin.Contains("Long Thanh"))
                .OrderBy(f => f.ScheduledTime)
                .ToListAsync();
            return View(flights);
        }

        public async Task<IActionResult> Arrivals()
        {
            var flights = await _context.Flights
                .Where(f => f.Destination.Contains("Long Thanh"))
                .OrderBy(f => f.ScheduledTime)
                .ToListAsync();
            return View(flights);
        }

        public IActionResult ProcedureGuide() => View();
    }
}
