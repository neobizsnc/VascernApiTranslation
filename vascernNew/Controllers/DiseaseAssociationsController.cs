using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vascernNew.Data;
using vascernNew.Models;

namespace vascernNew.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DiseaseAssociationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiseaseAssociationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DiseaseAssociations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DiseaseAssociation.Include(d => d.Association).Include(d => d.Disease);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DiseaseAssociations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseaseAssociation = await _context.DiseaseAssociation
                .Include(d => d.Association)
                .Include(d => d.Disease)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (diseaseAssociation == null)
            {
                return NotFound();
            }

            return View(diseaseAssociation);
        }

        // GET: DiseaseAssociations/Create
        public IActionResult Create()
        {
            ViewData["AssociationId"] = new SelectList(_context.Association, "Id", "Name");
            ViewData["DiseaseId"] = new SelectList(_context.Disease, "Id", "Name");
            return View();
        }

        // POST: DiseaseAssociations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DiseaseId,AssociationId")] DiseaseAssociation diseaseAssociation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diseaseAssociation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssociationId"] = new SelectList(_context.Association, "Id", "Name", diseaseAssociation.AssociationId);
            ViewData["DiseaseId"] = new SelectList(_context.Disease, "Id", "Name", diseaseAssociation.DiseaseId);
            return View(diseaseAssociation);
        }

        // GET: DiseaseAssociations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseaseAssociation = await _context.DiseaseAssociation.SingleOrDefaultAsync(m => m.Id == id);
            if (diseaseAssociation == null)
            {
                return NotFound();
            }
            ViewData["AssociationId"] = new SelectList(_context.Association, "Id", "Name", diseaseAssociation.AssociationId);
            ViewData["DiseaseId"] = new SelectList(_context.Disease, "Id", "Name", diseaseAssociation.DiseaseId);
            return View(diseaseAssociation);
        }

        // POST: DiseaseAssociations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,DiseaseId,AssociationId")] DiseaseAssociation diseaseAssociation)
        {
            if (id != diseaseAssociation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diseaseAssociation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiseaseAssociationExists(diseaseAssociation.Id))
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
            ViewData["AssociationId"] = new SelectList(_context.Association, "Id", "Name", diseaseAssociation.AssociationId);
            ViewData["DiseaseId"] = new SelectList(_context.Disease, "Id", "Name", diseaseAssociation.DiseaseId);
            return View(diseaseAssociation);
        }

        // GET: DiseaseAssociations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseaseAssociation = await _context.DiseaseAssociation
                .Include(d => d.Association)
                .Include(d => d.Disease)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (diseaseAssociation == null)
            {
                return NotFound();
            }

            return View(diseaseAssociation);
        }

        // POST: DiseaseAssociations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var diseaseAssociation = await _context.DiseaseAssociation.SingleOrDefaultAsync(m => m.Id == id);
            _context.DiseaseAssociation.Remove(diseaseAssociation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiseaseAssociationExists(int? id)
        {
            return _context.DiseaseAssociation.Any(e => e.Id == id);
        }
    }
}
