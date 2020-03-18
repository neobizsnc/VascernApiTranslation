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
    public class AssociationTranslationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssociationTranslationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AssociationTranslations
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.id = id;
            var applicationDbContext = _context.AssociationTranslation.Where(x => x.AssociationId == id).Include(a => a.Association).Include(a => a.Culture);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AssociationTranslations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associationTranslation = await _context.AssociationTranslation
                .Include(a => a.Association)
                .Include(a => a.Culture)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (associationTranslation == null)
            {
                return NotFound();
            }

            return View(associationTranslation);
        }

        // GET: AssociationTranslations/Create
        public IActionResult Create(int? id)
        {
            ViewData["AssociationId"] = new SelectList(_context.Association, "Id", "Name", id);
            ViewData["CultureId"] = new SelectList(_context.Culture, "Id", "Name");
            ViewData["AssociationIdSingle"] = id;
            var assTraslation = _context.AssociationTranslation.SingleOrDefault(m => m.CultureId == 2 && m.AssociationId == id);
            if (assTraslation == null)
            {
                return View();
            }
            return View(assTraslation);
        }

        // POST: AssociationTranslations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssociationTranslation associationTranslation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(associationTranslation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "Associations");
            }
            ViewData["AssociationId"] = new SelectList(_context.Association, "Id", "Name", associationTranslation.AssociationId);
            ViewData["CultureId"] = new SelectList(_context.Culture, "Id", "Name", associationTranslation.CultureId);
            ViewData["AssociationIdSingle"] = associationTranslation.AssociationId;
            return View(associationTranslation);
        }

        // GET: AssociationTranslations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associationTranslation = await _context.AssociationTranslation.SingleOrDefaultAsync(m => m.Id == id);
            if (associationTranslation == null)
            {
                return NotFound();
            }
            ViewData["AssociationId"] = new SelectList(_context.Association, "Id", "Name", associationTranslation.AssociationId);
            ViewData["CultureId"] = new SelectList(_context.Culture, "Id", "Name", associationTranslation.CultureId);
            ViewData["AssociationIdSingle"] = id;
            return View(associationTranslation);
        }

        // POST: AssociationTranslations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AssociationTranslation associationTranslation)
        {
            if (id != associationTranslation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(associationTranslation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociationTranslationExists(associationTranslation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Associations");
            }
            ViewData["AssociationId"] = new SelectList(_context.Association, "Id", "Name", associationTranslation.AssociationId);
            ViewData["CultureId"] = new SelectList(_context.Culture, "Id", "Name", associationTranslation.CultureId);
            ViewData["AssociationIdSingle"] = id;
            return View(associationTranslation);
        }

        // GET: AssociationTranslations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associationTranslation = await _context.AssociationTranslation
                .Include(a => a.Association)
                .Include(a => a.Culture)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (associationTranslation == null)
            {
                return NotFound();
            }
            ViewData["AssociationIdSingle"] = id;
            return View(associationTranslation);
        }

        // POST: AssociationTranslations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var associationTranslation = await _context.AssociationTranslation.SingleOrDefaultAsync(m => m.Id == id);
            _context.AssociationTranslation.Remove(associationTranslation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Associations");
        }

        private bool AssociationTranslationExists(int id)
        {
            return _context.AssociationTranslation.Any(e => e.Id == id);
        }
    }
}
