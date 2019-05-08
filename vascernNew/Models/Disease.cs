using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vascernNew.Models
{
    public class Disease
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Orphacode { get; set; }
        public string Website { get; set; }
        public ICollection<DiseaseCenter> DiseaseCenter { get; set; }
        public ICollection<DiseaseAssociation> DiseaseAssociation { get; set; }
        public ICollection<DiseaseTraslation> DiseaseTraslation { get; set; }
    }
}
