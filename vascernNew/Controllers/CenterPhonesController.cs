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
    public class CenterPhonesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CenterPhonesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CenterPhones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CenterPhone.Include(c => c.HcpCenter);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CenterPhones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centerPhone = await _context.CenterPhone
                .Include(c => c.HcpCenter)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (centerPhone == null)
            {
                return NotFound();
            }

            return View(centerPhone);
        }

        // GET: CenterPhones/Create
        public IActionResult Create()
        {
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name");
            return View();
        }

        // POST: CenterPhones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label,Phone,HcpCenterId")] CenterPhone centerPhone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centerPhone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name", centerPhone.HcpCenterId);
            return View(centerPhone);
        }

        // GET: CenterPhones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centerPhone = await _context.CenterPhone.SingleOrDefaultAsync(m => m.Id == id);
            if (centerPhone == null)
            {
                return NotFound();
            }
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name", centerPhone.HcpCenterId);
            return View(centerPhone);
        }

        // POST: CenterPhones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label,Phone,HcpCenterId")] CenterPhone centerPhone)
        {
            if (id != centerPhone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centerPhone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CenterPhoneExists(centerPhone.Id))
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
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name", centerPhone.HcpCenterId);
            return View(centerPhone);
        }

        // GET: CenterPhones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centerPhone = await _context.CenterPhone
                .Include(c => c.HcpCenter)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (centerPhone == null)
            {
                return NotFound();
            }

            return View(centerPhone);
        }

        // POST: CenterPhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var centerPhone = await _context.CenterPhone.SingleOrDefaultAsync(m => m.Id == id);
            _context.CenterPhone.Remove(centerPhone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CenterPhoneExists(int id)
        {
            return _context.CenterPhone.Any(e => e.Id == id);
        }
    }
}
