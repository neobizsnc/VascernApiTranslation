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
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AssociationTranslation.Include(a => a.Association).Include(a => a.Culture);
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
        public IActionResult Create()
        {
            ViewData["AssociationId"] = new SelectList(_context.Association, "Id", "Name");
            ViewData["CultureId"] = new SelectList(_context.Culture, "Id", "Name");
            return View();
        }

        // POST: AssociationTranslations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NameWorkingGroup,Country,City,Address,Zipcode,Contact,PhoneDirect,Fax,OpeningTime,HowToContact,EmailDirect,Website,Facebook,Twitter,Youtube,Linkedin,Instagram,Service,Lat,Lng,Type,CultureId,AssociationId")] AssociationTranslation associationTranslation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(associationTranslation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssociationId"] = new SelectList(_context.Association, "Id", "Name", associationTranslation.AssociationId);
            ViewData["CultureId"] = new SelectList(_context.Culture, "Id", "Name", associationTranslation.CultureId);
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
            return View(associationTranslation);
        }

        // POST: AssociationTranslations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NameWorkingGroup,Country,City,Address,Zipcode,Contact,PhoneDirect,Fax,OpeningTime,HowToContact,EmailDirect,Website,Facebook,Twitter,Youtube,Linkedin,Instagram,Service,Lat,Lng,Type,CultureId,AssociationId")] AssociationTranslation associationTranslation)
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssociationId"] = new SelectList(_context.Association, "Id", "Name", associationTranslation.AssociationId);
            ViewData["CultureId"] = new SelectList(_context.Culture, "Id", "Name", associationTranslation.CultureId);
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
            return RedirectToAction(nameof(Index));
        }

        private bool AssociationTranslationExists(int id)
        {
            return _context.AssociationTranslation.Any(e => e.Id == id);
        }
    }
}
