using Inara.Contexts;
using Inara.Helpers;
using Inara.Models;
using Inara.ViewModel.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using System.IO;

namespace Inara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        InaraDbContext _db;

        public ServiceController(InaraDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Services.Select(s => new ServiceListItemVM
            {
                Id = s.Id,
                Image = s.Image,
                Description = s.Description,
                Title = s.Title,
            }).ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ServiceCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            Service data = new Service
            {
                Image = await vm.Image.SaveAsync(ExtenConst.Picture),
                Description = vm.Description,
                Title = vm.Title,
            };
            await _db.Services.AddAsync(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            var data = await _db.Services.FindAsync(id);
            if (data == null) return NotFound();

            var i = new ServiceUpdateVM
            {
                Description = data.Description,
                Title = data.Title,
            };
            return View(i);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, ServiceUpdateVM vm)
        {
            if (id == null || id <= 0) return BadRequest();
            if (!ModelState.IsValid) return View(vm);
            var data = await _db.Services.FindAsync(id);
            if (data == null) return NotFound();
            data.Title = vm.Title;
            data.Description = vm.Description;
            data.Image = await vm.Image.SaveAsync(ExtenConst.Picture);

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            var data = await _db.Services.FindAsync(id);
            if (data == null) return NotFound();
            _db.Services.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
