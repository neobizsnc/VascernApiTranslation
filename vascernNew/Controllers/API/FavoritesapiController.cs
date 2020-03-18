using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vascernNew.Data;
using vascernNew.Models;

namespace vascernNew.Controllers.API
{
    [Produces("application/json")]
    [Route("api/FavaritesApi")]
    public class FavoritesapiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavoritesapiController(ApplicationDbContext context)
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
    }
}