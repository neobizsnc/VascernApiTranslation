using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vascernNew.Data;
using vascernNew.Models;

namespace vascernNew.Controllers
{
    public class CenterEmailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CenterEmailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CenterEmails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CenterEmail.Include(c => c.HcpCenter);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CenterEmails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centerEmail = await _context.CenterEmail
                .Include(c => c.HcpCenter)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (centerEmail == null)
            {
                return NotFound();
            }

            return View(centerEmail);
        }

        // GET: CenterEmails/Create
        public IActionResult Create()
        {
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name");
            return View();
        }

        // POST: CenterEmails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label,Email,HcpCenterId")] CenterEmail centerEmail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centerEmail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name", centerEmail.HcpCenterId);
            return View(centerEmail);
        }

        // GET: CenterEmails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centerEmail = await _context.CenterEmail.SingleOrDefaultAsync(m => m.Id == id);
            if (centerEmail == null)
            {
                return NotFound();
            }
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name", centerEmail.HcpCenterId);
            return View(centerEmail);
        }

        // POST: CenterEmails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label,Email,HcpCenterId")] CenterEmail centerEmail)
        {
            if (id != centerEmail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centerEmail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CenterEmailExists(centerEmail.Id))
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
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name", centerEmail.HcpCenterId);
            return View(centerEmail);
        }

        // GET: CenterEmails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centerEmail = await _context.CenterEmail
                .Include(c => c.HcpCenter)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (centerEmail == null)
            {
                return NotFound();
            }

            return View(centerEmail);
        }

        // POST: CenterEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var centerEmail = await _context.CenterEmail.SingleOrDefaultAsync(m => m.Id == id);
            _context.CenterEmail.Remove(centerEmail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CenterEmailExists(int id)
        {
            return _context.CenterEmail.Any(e => e.Id == id);
        }
    }
}
