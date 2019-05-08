using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vascernNew.Data;
using vascernNew.Models;

namespace vascernNew.Controllers.API
{
    [Produces("application/json")]
    [Route("api/DiseasesApi")]
    public class DiseasesApiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiseasesApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DiseasesApi
        [HttpGet]
        public IEnumerable<Disease> GetDisease()
        {
            return _context.Disease;
        }

        [HttpGet("GetDiseaseHcpByCenterId/{id}/{culture}")]
        public async Task<IActionResult> GetDiseaseHcpByCenterId([FromRoute] int id, [FromRoute] string culture)
        {
            var cultureId = _context.Culture.Where(x => x.Name == culture).Select(x => x.Id).SingleOrDefault();
            List<DiseaseCenter> result = await _context.DiseaseCenter.Where(x => x.HcpCenterId == id).Include(k => k.Disease).ThenInclude(z=>z.DiseaseTraslation).ToListAsync();
            List<DiseaseTraslation> translationFinal = new List<DiseaseTraslation>();
            foreach (var a in result)
            {
                foreach (var b in a.Disease.DiseaseTraslation)
                {
                    if (b.CultureId == cultureId)
                    {
                        translationFinal.Add(b);
                    }
                }

                a.Disease.DiseaseTraslation = translationFinal;
                translationFinal = new List<DiseaseTraslation>();
            }
            return Ok(result);
        }

        [HttpGet("GetDiseaseAssociationByCenterId/{id}/{culture}")]
        public async Task<IActionResult> GetDiseaseAssociationByCenterId([FromRoute] int id, [FromRoute] string culture)
        {
            var cultureId = _context.Culture.Where(x => x.Name == culture).Select(x => x.Id).SingleOrDefault();
            List<DiseaseAssociation> result = await _context.DiseaseAssociation.Where(x => x.AssociationId == id).Include(k => k.Disease).ThenInclude(z => z.DiseaseTraslation).ToListAsync();
            List<DiseaseTraslation> translationFinal = new List<DiseaseTraslation>();
            foreach (var a in result)
            {
                foreach (var b in a.Disease.DiseaseTraslation)
                {
                    if (b.CultureId == cultureId)
                    {
                        translationFinal.Add(b);
                    }
                }

                a.Disease.DiseaseTraslation = translationFinal;
                translationFinal = new List<DiseaseTraslation>();
            }
            return Ok(result);
        }

        // GET: api/DiseasesApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDisease([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var disease = await _context.Disease.SingleOrDefaultAsync(m => m.Id == id);

            if (disease == null)
            {
                return NotFound();
            }

            return Ok(disease);
        }

        // GET: api/DiseasesApi/GetDiseaseByCulture/en
        [HttpGet("GetDiseaseByCulture/{culture}")]
        public async Task<IActionResult> GetDiseaseByCulture([FromRoute] string culture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var disease = await _context.DiseaseTraslation.Where(x => x.Culture.Name == culture).Include(k=>k.Disease).ToListAsync();
            //var disease = await _context.Disease.Include(x => x.DiseaseTraslation).Where(c => c.DiseaseTraslation.Any(i => i.Culture.Name == culture)).ToListAsync();

            if (disease == null)
            {
                return NotFound();
            }

            return Ok(disease);
        }

        // PUT: api/DiseasesApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisease([FromRoute] int id, [FromBody] Disease disease)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != disease.Id)
            {
                return BadRequest();
            }

            _context.Entry(disease).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiseaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DiseasesApi
        [HttpPost]
        public async Task<IActionResult> PostDisease([FromBody] Disease disease)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Disease.Add(disease);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisease", new { id = disease.Id }, disease);
        }

        // DELETE: api/DiseasesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisease([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var disease = await _context.Disease.SingleOrDefaultAsync(m => m.Id == id);
            if (disease == null)
            {
                return NotFound();
            }

            _context.Disease.Remove(disease);
            await _context.SaveChangesAsync();

            return Ok(disease);
        }

        private bool DiseaseExists(int id)
        {
            return _context.Disease.Any(e => e.Id == id);
        }
    }
}