using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vascernNew.Models
{
    public class Association
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AssociationTranslation> AssociationTranslation { get; set; }
        public ICollection<AssociationHcp> AssociationHcp { get; set; }
        public ICollection<DiseaseAssociation> DiseaseAssociation { get; set; }
    }
}
