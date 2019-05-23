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
    public class DiseaseTraslationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiseaseTraslationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DiseaseTraslations
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.id = id;
            var applicationDbContext = _context.DiseaseTraslation.Where(x=>x.DiseaseId == id).Include(d => d.Culture).Include(d => d.Disease);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DiseaseTraslations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseaseTraslation = await _context.DiseaseTraslation
                .Include(d => d.Culture)
                .Include(d => d.Disease)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (diseaseTraslation == null)
            {
                return NotFound();
            }

            return View(diseaseTraslation);
        }

        // GET: DiseaseTraslations/Create
        public IActionResult Create(int? id)
        {
            ViewData["CultureId"] = new SelectList(_context.Culture, "Id", "Name");
            ViewData["DiseaseId"] = new SelectList(_context.Disease, "Id", "Name", id);
            return View();
        }

        // POST: DiseaseTraslations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DiseaseTraslation diseaseTraslation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diseaseTraslation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "Diseases");
            }
            ViewData["CultureId"] = new SelectList(_context.Culture, "Id", "Name", diseaseTraslation.CultureId);
            ViewData["DiseaseId"] = new SelectList(_context.Disease, "Id", "Name", diseaseTraslation.DiseaseId);
            return View(diseaseTraslation);
        }

        // GET: DiseaseTraslations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseaseTraslation = await _context.DiseaseTraslation.SingleOrDefaultAsync(m => m.Id == id);
            if (diseaseTraslation == null)
            {
                return NotFound();
            }
            ViewData["CultureId"] = new SelectList(_context.Culture, "Id", "Name", diseaseTraslation.CultureId);
            ViewData["DiseaseId"] = new SelectList(_context.Disease, "Id", "Name", diseaseTraslation.DiseaseId);
            return View(diseaseTraslation);
        }

        // POST: DiseaseTraslations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CultureId,DiseaseId")] DiseaseTraslation diseaseTraslation)
        {
            if (id != diseaseTraslation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diseaseTraslation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiseaseTraslationExists(diseaseTraslation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Diseases");
            }
            ViewData["CultureId"] = new SelectList(_context.Culture, "Id", "Name", diseaseTraslation.CultureId);
            ViewData["DiseaseId"] = new SelectList(_context.Disease, "Id", "Name", diseaseTraslation.DiseaseId);
            return View(diseaseTraslation);
        }

        // GET: DiseaseTraslations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseaseTraslation = await _context.DiseaseTraslation
                .Include(d => d.Culture)
                .Include(d => d.Disease)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (diseaseTraslation == null)
            {
                return NotFound();
            }

            return View(diseaseTraslation);
        }

        // POST: DiseaseTraslations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diseaseTraslation = await _context.DiseaseTraslation.SingleOrDefaultAsync(m => m.Id == id);
            _context.DiseaseTraslation.Remove(diseaseTraslation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Diseases");
        }

        private bool DiseaseTraslationExists(int id)
        {
            return _context.DiseaseTraslation.Any(e => e.Id == id);
        }
    }
}
