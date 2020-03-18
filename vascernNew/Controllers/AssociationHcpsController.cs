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
    public class AssociationHcpsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssociationHcpsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AssociationHcps
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AssociationHcp.Include(a => a.Association).Include(a => a.HcpCenter);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AssociationHcps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associationHcp = await _context.AssociationHcp
                .Include(a => a.Association)
                .Include(a => a.HcpCenter)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (associationHcp == null)
            {
                return NotFound();
            }

            return View(associationHcp);
        }

        // GET: AssociationHcps/Create
        public IActionResult Create()
        {
            ViewData["AssociationId"] = new SelectList(_context.Association, "Id", "Name");
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name");
            return View();
        }

        // POST: AssociationHcps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssociationId,HcpCenterId")] AssociationHcp associationHcp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(associationHcp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssociationId"] = new SelectList(_context.Association, "Id", "Name", associationHcp.AssociationId);
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name", associationHcp.HcpCenterId);
            return View(associationHcp);
        }

        // GET: AssociationHcps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associationHcp = await _context.AssociationHcp.SingleOrDefaultAsync(m => m.Id == id);
            if (associationHcp == null)
            {
                return NotFound();
            }
            ViewData["AssociationId"] = new SelectList(_context.Association, "Id", "Name", associationHcp.AssociationId);
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name", associationHcp.HcpCenterId);
            return View(associationHcp);
        }

        // POST: AssociationHcps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,AssociationId,HcpCenterId")] AssociationHcp associationHcp)
        {
            if (id != associationHcp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(associationHcp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociationHcpExists(associationHcp.Id))
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
            ViewData["AssociationId"] = new SelectList(_context.Association, "Id", "Name", associationHcp.AssociationId);
            ViewData["HcpCenterId"] = new SelectList(_context.HcpCenters, "Id", "Name", associationHcp.HcpCenterId);
            return View(associationHcp);
        }

        // GET: AssociationHcps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associationHcp = await _context.AssociationHcp
                .Include(a => a.Association)
                .Include(a => a.HcpCenter)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (associationHcp == null)
            {
                return NotFound();
            }

            return View(associationHcp);
        }

        // POST: AssociationHcps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var associationHcp = await _context.AssociationHcp.SingleOrDefaultAsync(m => m.Id == id);
            _context.AssociationHcp.Remove(associationHcp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssociationHcpExists(int? id)
        {
            return _context.AssociationHcp.Any(e => e.Id == id);
        }
    }
}
