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
    public class DiseaseCentersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiseaseCentersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DiseaseCenters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DiseaseCenter.Include(d => d.Disease).Include(d => d.HcpCenter);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DiseaseCenters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseaseCenter = await _context.DiseaseCenter
                .Include(d => d.Disease)
                .Include(d => d.HcpCenter)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (diseaseCenter == null)
            {
                return NotFound();
            }

            return View(diseaseCenter);
        }

        // GET: DiseaseCenters/Create
        public IActionResult Create()
        {
            ViewData["DiseaseId"] = new SelectList(_context.Disease, "Id", "Name");
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name");
            return View();
        }

        // POST: DiseaseCenters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DiseaseId,HcpCenterId")] DiseaseCenter diseaseCenter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diseaseCenter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiseaseId"] = new SelectList(_context.Disease, "Id", "Name", diseaseCenter.DiseaseId);
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name", diseaseCenter.HcpCenterId);
            return View(diseaseCenter);
        }

        // GET: DiseaseCenters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseaseCenter = await _context.DiseaseCenter.SingleOrDefaultAsync(m => m.Id == id);
            if (diseaseCenter == null)
            {
                return NotFound();
            }
            ViewData["DiseaseId"] = new SelectList(_context.Disease, "Id", "Name", diseaseCenter.DiseaseId);
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name", diseaseCenter.HcpCenterId);
            return View(diseaseCenter);
        }

        // POST: DiseaseCenters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,DiseaseId,HcpCenterId")] DiseaseCenter diseaseCenter)
        {
            if (id != diseaseCenter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diseaseCenter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiseaseCenterExists(diseaseCenter.Id))
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
            ViewData["DiseaseId"] = new SelectList(_context.Disease, "Id", "Name", diseaseCenter.DiseaseId);
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name", diseaseCenter.HcpCenterId);
            return View(diseaseCenter);
        }

        // GET: DiseaseCenters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseaseCenter = await _context.DiseaseCenter
                .Include(d => d.Disease)
                .Include(d => d.HcpCenter)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (diseaseCenter == null)
            {
                return NotFound();
            }

            return View(diseaseCenter);
        }

        // POST: DiseaseCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var diseaseCenter = await _context.DiseaseCenter.SingleOrDefaultAsync(m => m.Id == id);
            _context.DiseaseCenter.Remove(diseaseCenter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiseaseCenterExists(int? id)
        {
            return _context.DiseaseCenter.Any(e => e.Id == id);
        }
    }
}
