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
    [Route("api/HcpCentersApi")]
    public class HcpCentersApiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HcpCentersApiController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("GetRelatedAssociation/{id}/{culture}")]
        public async Task<IActionResult> GetRelatedAssociation([FromRoute] int id, [FromRoute] string culture)
        {
            var cultureId = _context.Culture.Where(x => x.Name == culture).Select(x => x.Id).SingleOrDefault();
            List<AssociationHcp> result = await _context.AssociationHcp.Where(x => x.HcpCenterId == id).Include(k => k.Association).ThenInclude(z => z.AssociationTranslation).ToListAsync();
            List<AssociationTranslation> translationFinal = new List<AssociationTranslation>();
            foreach (var a in result)
            {
                foreach (var b in a.Association.AssociationTranslation)
                {
                    if (b.CultureId == cultureId)
                    {
                        translationFinal.Add(b);
                    }
                }
                a.Association.AssociationTranslation = translationFinal;
                translationFinal = new List<AssociationTranslation>();
            }
            return Ok(result);
        }

        [HttpGet("GetHcpByIdCulture/{id}/{culture}")]
        public async Task<IActionResult> GetHcpByIdCulture([FromRoute] int id, [FromRoute] string culture)
        {
            var cultureId = _context.Culture.Where(x => x.Name == culture).Select(x => x.Id).SingleOrDefault();
            HcpCenter res = await _context.HcpCenters.Where(x => x.Id == id).Include(z => z.HcpCenterTraslation).FirstOrDefaultAsync();
            HcpCenterTraslation res1 = res.HcpCenterTraslation.Where(x => x.CultureId == cultureId).FirstOrDefault();
            return Ok(res1);
        }

        [HttpGet("GetAssByIdCulture/{id}/{culture}")]
        public async Task<IActionResult> GetAssByIdCulture([FromRoute] int id, [FromRoute] string culture)
        {
            var cultureId = _context.Culture.Where(x => x.Name == culture).Select(x => x.Id).SingleOrDefault();
            Association res = await _context.Association.Where(x => x.Id == id).Include(z => z.AssociationTranslation).FirstOrDefaultAsync();
            AssociationTranslation res1 = res.AssociationTranslation.Where(x => x.CultureId == cultureId).FirstOrDefault();
            return Ok(res1);
        }



        [HttpGet("GetRelatedHcp/{id}/{culture}")]
        public async Task<IActionResult> GetRelatedHcp([FromRoute] int id, [FromRoute] string culture)
        {
            var cultureId = _context.Culture.Where(x => x.Name == culture).Select(x => x.Id).SingleOrDefault();
            List<AssociationHcp> result = await _context.AssociationHcp.Where(x => x.AssociationId == id).Include(k => k.HcpCenter).ThenInclude(z => z.HcpCenterTraslation).ToListAsync();
            List<HcpCenterTraslation> translationFinal = new List<HcpCenterTraslation>();
            foreach (var a in result)
            {
                foreach (var b in a.HcpCenter.HcpCenterTraslation)
                {
                    if (b.CultureId == cultureId)
                    {
                        translationFinal.Add(b);
                    }
                }
                a.HcpCenter.HcpCenterTraslation = translationFinal;
                translationFinal = new List<HcpCenterTraslation>();
            }
            return Ok(result);
        }





        [HttpGet("GetCentersByCountryNew/{culture}")]
        public async Task<IActionResult> GetCentersByCountryNew([FromRoute] string culture)
        {
            //var hcp = await _context.HcpCenters.Include(e => e.CenterEmail).Include(e => e.CenterPhone).ToListAsync();
            List<HcpCenterTraslation> hcp = await _context.HcpCenterTraslations.Where(x=>x.Culture.Name == culture).Include(x=>x.HcpCenter).ToListAsync();
            var ass = await _context.AssociationTranslation.Where(x => x.Culture.Name == culture).ToListAsync();
            
            
            List<Object> union = new List<Object>();

            foreach (var j in hcp)
            {
                j.HcpCenter.CenterEmail = _context.CenterEmail.Where(x => x.HcpCenterId == j.HcpCenterId).ToList();
                j.HcpCenter.CenterPhone = _context.CenterPhone.Where(x => x.HcpCenterId == j.HcpCenterId).ToList();
                union.Add(j);
            }
            foreach (var j in ass)
            {
                union.Add(j);
            }
            return Ok(union);
        }

        [HttpGet("GetCentersByDiseaseId/{id}/{culture}")]
        public async Task<IActionResult> GetCentersByDiseaseId([FromRoute] int id, [FromRoute] string culture)
        {
            var cultureId = _context.Culture.Where(x => x.Name == culture).Select(x=>x.Id).SingleOrDefault();
            List<DiseaseCenter> result = await _context.DiseaseCenter.Where(x => x.DiseaseId == id).Include(k => k.HcpCenter).Include(e => e.HcpCenter.CenterEmail).Include(e => e.HcpCenter.CenterPhone).Include(z=>z.HcpCenter.HcpCenterTraslation).ToListAsync();
            List<DiseaseAssociation> resultAss = await _context.DiseaseAssociation.Where(x => x.DiseaseId == id).Include(k => k.Association).ThenInclude(z => z.AssociationTranslation).ToListAsync();

            List<HcpCenterTraslation> translationFinal = new List<HcpCenterTraslation>();
            List<AssociationTranslation> translationAssFinal = new List<AssociationTranslation>();

            //Rimuovo le lingue che non mi interessano dai centri
            foreach (var a in result)
            {
                foreach(var b in a.HcpCenter.HcpCenterTraslation)
                {
                    if(b.CultureId == cultureId)
                    {
                        translationFinal.Add(b);
                    }
                }

                a.HcpCenter.HcpCenterTraslation = translationFinal;
                translationFinal = new List<HcpCenterTraslation>();
            }

            //Rimuovo le lingue che non mi interessano dalle associazioni
            foreach (var a in resultAss)
            {
                foreach (var b in a.Association.AssociationTranslation)
                {
                    if (b.CultureId == cultureId)
                    {
                        translationAssFinal.Add(b);
                    }
                }
                a.Association.AssociationTranslation = translationAssFinal;
                translationAssFinal = new List<AssociationTranslation>();
            }



            DiseaseCenterAssociation res = new DiseaseCenterAssociation();
            res.diseaseCenter = result;
            res.diseaseAssociation = resultAss;

            return Ok(res);
        }

        // GET: api/HcpCentersApi
        [HttpGet]
        public IEnumerable<HcpCenter> GetHcpCenters()
        {
            return _context.HcpCenters;
        }

        // GET: api/HcpCentersApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHcpCenter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hcpCenter = await _context.HcpCenters.SingleOrDefaultAsync(m => m.Id == id);

            if (hcpCenter == null)
            {
                return NotFound();
            }

            return Ok(hcpCenter);
        }

        // PUT: api/HcpCentersApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHcpCenter([FromRoute] int id, [FromBody] HcpCenter hcpCenter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hcpCenter.Id)
            {
                return BadRequest();
            }

            _context.Entry(hcpCenter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HcpCenterExists(id))
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

        // POST: api/HcpCentersApi
        [HttpPost]
        public async Task<IActionResult> PostHcpCenter([FromBody] HcpCenter hcpCenter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HcpCenters.Add(hcpCenter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHcpCenter", new { id = hcpCenter.Id }, hcpCenter);
        }

        // DELETE: api/HcpCentersApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHcpCenter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hcpCenter = await _context.HcpCenters.SingleOrDefaultAsync(m => m.Id == id);
            if (hcpCenter == null)
            {
                return NotFound();
            }

            _context.HcpCenters.Remove(hcpCenter);
            await _context.SaveChangesAsync();

            return Ok(hcpCenter);
        }

        private bool HcpCenterExists(int id)
        {
            return _context.HcpCenters.Any(e => e.Id == id);
        }
    }
}