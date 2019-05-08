using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vascernNew.Data;
using vascernNew.Models;

namespace vascernNew.Controllers
{
    public class ScriptUpdateTranslationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScriptUpdateTranslationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var count = 1;
            List<Association> hcp = _context.Association.ToList();

            foreach(var a in hcp)
            {
                if(count != 0)
                {
                    var translation = new AssociationTranslation();
                    translation.Name = a.Name;
                    translation.CultureId = 2;
                    translation.AssociationId = a.Id;
                    _context.AssociationTranslation.Add(translation);
                    _context.SaveChanges();
                }
                count++;
            }

            return View();
        }
    }
}