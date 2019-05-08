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
    public class FavouritesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavouritesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetPersonalFavorites/{uuid}")]
        public async Task<IActionResult> GetPersonalFavorites([FromRoute] string uuid)
        {
            var res = await _context.Favourites.Where(f => f.Uuid == uuid).ToListAsync();
            return Ok(res);
        }

        [HttpGet("DeletePersonalFavorites/{uuid}/{structureId}")]
        public async Task<IActionResult> DeletePersonalFavorites([FromRoute] string uuid, [FromRoute] int structureId)
        {
            var res = await _context.Favourites.Where(f => f.Uuid == uuid && f.StructureId == structureId).SingleOrDefaultAsync();
            if (res != null)
            {
                _context.Favourites.Remove(res);
                await _context.SaveChangesAsync();
                return Ok(true);
            }
            return Ok(false);
        }


        [HttpGet("ChekFavorites/{uuid}/{structureId}/{type}")]
        public async Task<IActionResult> ChekFavorites([FromRoute] string uuid, [FromRoute] int structureId, [FromRoute] string type)
        {
            var res = await _context.Favourites.Where(f => f.Uuid == uuid && f.StructureId == structureId).SingleOrDefaultAsync();

            if (res != null) //ESISTE
            {
                _context.Favourites.Remove(res);
                await _context.SaveChangesAsync();
                return Ok(true);
            }
            else
            {
                var favorites = new Favourites();
                favorites.StructureId = structureId;
                favorites.Type = type;
                favorites.Uuid = uuid;

                _context.Favourites.Add(favorites);
                await _context.SaveChangesAsync();
                return Ok(false);
            }
        }

        [HttpGet("ChekOnlyFavorites/{uuid}/{structureId}/{type}")]
        public async Task<IActionResult> ChekOnlyFavorites([FromRoute] string uuid, [FromRoute] int structureId, [FromRoute] string type)
        {
            var res = await _context.Favourites.Where(f => f.Uuid == uuid && f.StructureId == structureId).SingleOrDefaultAsync();

            if (res != null) //ESISTE
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        // GET: Favourites
        public async Task<IActionResult> Index()
        {
            return View(await _context.Favourites.ToListAsync());
        }

        // GET: Favourites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favourites = await _context.Favourites
                .SingleOrDefaultAsync(m => m.Id == id);
            if (favourites == null)
            {
                return NotFound();
            }

            return View(favourites);
        }

        // GET: Favourites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Favourites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Uuid,Type,StructureId")] Favourites favourites)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favourites);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(favourites);
        }

        // GET: Favourites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favourites = await _context.Favourites.SingleOrDefaultAsync(m => m.Id == id);
            if (favourites == null)
            {
                return NotFound();
            }
            return View(favourites);
        }

        // POST: Favourites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Uuid,Type,StructureId")] Favourites favourites)
        {
            if (id != favourites.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favourites);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavouritesExists(favourites.Id))
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
            return View(favourites);
        }

        // GET: Favourites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favourites = await _context.Favourites
                .SingleOrDefaultAsync(m => m.Id == id);
            if (favourites == null)
            {
                return NotFound();
            }

            return View(favourites);
        }

        // POST: Favourites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favourites = await _context.Favourites.SingleOrDefaultAsync(m => m.Id == id);
            _context.Favourites.Remove(favourites);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavouritesExists(int id)
        {
            return _context.Favourites.Any(e => e.Id == id);
        }
    }
}
