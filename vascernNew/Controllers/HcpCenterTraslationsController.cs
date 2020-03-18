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
    public class HcpCenterTraslationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HcpCenterTraslationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HcpCenterTraslations
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.id = id;
            var applicationDbContext = _context.HcpCenterTraslations.Where(x => x.HcpCenterId == id).Include(h => h.Culture).Include(h => h.HcpCenter);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HcpCenterTraslations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hcpCenterTraslation = await _context.HcpCenterTraslations
                .Include(h => h.Culture)
                .Include(h => h.HcpCenter)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (hcpCenterTraslation == null)
            {
                return NotFound();
            }

            return View(hcpCenterTraslation);
        }

        // GET: HcpCenterTraslations/Create
        public IActionResult Create(int? id)
        {
            ViewData["CultureId"] = new SelectList(_context.Culture, "Id", "Name");
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name", id);
            ViewData["HcpCenterIdSingle"] = id;
            var hcpCenterTraslation =  _context.HcpCenterTraslations.SingleOrDefault(m => m.CultureId == 2 && m.HcpCenterId == id);
            if (hcpCenterTraslation == null)
            {
                return View();
            }
            return View(hcpCenterTraslation);
        }

        // POST: HcpCenterTraslations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( HcpCenterTraslation hcpCenterTraslation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hcpCenterTraslation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "HcpCenters");
            }
            ViewData["CultureId"] = new SelectList(_context.Culture, "Id", "Name", hcpCenterTraslation.CultureId);
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name", hcpCenterTraslation.HcpCenterId);
            ViewData["HcpCenterIdSingle"] = hcpCenterTraslation.HcpCenterId;
            return View(hcpCenterTraslation);
        }

        // GET: HcpCenterTraslations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hcpCenterTraslation = await _context.HcpCenterTraslations.SingleOrDefaultAsync(m => m.Id == id);
            if (hcpCenterTraslation == null)
            {
                return NotFound();
            }
            ViewData["CultureId"] = new SelectList(_context.Culture, "Id", "Name", hcpCenterTraslation.CultureId);
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name", hcpCenterTraslation.HcpCenterId);
            ViewData["HcpCenterIdSingle"] = id;
            return View(hcpCenterTraslation);
        }

        // POST: HcpCenterTraslations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HcpCenterTraslation hcpCenterTraslation)
        {
            if (id != hcpCenterTraslation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hcpCenterTraslation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HcpCenterTraslationExists(hcpCenterTraslation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "HcpCenters");
            }
            ViewData["CultureId"] = new SelectList(_context.Culture, "Id", "Name", hcpCenterTraslation.CultureId);
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name", hcpCenterTraslation.HcpCenterId);
            ViewData["HcpCenterIdSingle"] = id;
            return View(hcpCenterTraslation);
        }

        // GET: HcpCenterTraslations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hcpCenterTraslation = await _context.HcpCenterTraslations
                .Include(h => h.Culture)
                .Include(h => h.HcpCenter)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (hcpCenterTraslation == null)
            {
                return NotFound();
            }
            ViewData["HcpCenterIdSingle"] = id;
            return View(hcpCenterTraslation);
        }

        // POST: HcpCenterTraslations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hcpCenterTraslation = await _context.HcpCenterTraslations.SingleOrDefaultAsync(m => m.Id == id);
            _context.HcpCenterTraslations.Remove(hcpCenterTraslation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "HcpCenters");
        }

        private bool HcpCenterTraslationExists(int id)
        {
            return _context.HcpCenterTraslations.Any(e => e.Id == id);
        }
    }
}
