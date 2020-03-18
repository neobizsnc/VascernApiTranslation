using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vascernNew.Data;
using vascernNew.Models;

namespace vascernNew.Controllers
{
    [Authorize(Roles = "Admin, Hcp")]
    public class HcpCentersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _manager;

        public HcpCentersController(ApplicationDbContext context, UserManager<ApplicationUser> manager)
        {
            _manager = manager;
            _context = context;
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _manager.GetUserAsync(HttpContext.User);
        }

        // GET: HcpCenters
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUser();

            if (user.Type == 2) //ASS
            {
                return RedirectToAction("AccessDenied", "Account");
            }
            else if (user.Type == 1)
            {
                return View(await _context.HcpCenters.Where(x => x.Id == user.HcpCenterId).ToListAsync());
            }
            else
            {
                return View(await _context.HcpCenters.ToListAsync());
            }

        }

        // GET: HcpCenters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hcpCenter = await _context.HcpCenters
                .SingleOrDefaultAsync(m => m.Id == id);
            if (hcpCenter == null)
            {
                return NotFound();
            }

            return View(hcpCenter);
        }

        // GET: HcpCenters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HcpCenters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] HcpCenter hcpCenter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hcpCenter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hcpCenter);
        }

        // GET: HcpCenters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hcpCenter = await _context.HcpCenters.SingleOrDefaultAsync(m => m.Id == id);
            if (hcpCenter == null)
            {
                return NotFound();
            }
            return View(hcpCenter);
        }

        // POST: HcpCenters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] HcpCenter hcpCenter)
        {
            if (id != hcpCenter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hcpCenter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HcpCenterExists(hcpCenter.Id))
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
            return View(hcpCenter);
        }

        // GET: HcpCenters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hcpCenter = await _context.HcpCenters
                .SingleOrDefaultAsync(m => m.Id == id);
            if (hcpCenter == null)
            {
                return NotFound();
            }

            return View(hcpCenter);
        }

        // POST: HcpCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hcpCenter = await _context.HcpCenters.SingleOrDefaultAsync(m => m.Id == id);
            _context.HcpCenters.Remove(hcpCenter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HcpCenterExists(int id)
        {
            return _context.HcpCenters.Any(e => e.Id == id);
        }
    }
}
