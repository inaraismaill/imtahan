using Inara.Contexts;
using Inara.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Inara.Controllers
{
    public class HomeController : Controller
    {
        InaraDbContext _context;

		public HomeController(InaraDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
        {
            return View(await _context.Services.ToListAsync());
        }

       
    }
}