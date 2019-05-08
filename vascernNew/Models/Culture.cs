using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vascernNew.Models
{
    public class Culture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<HcpCenterTraslation> HcpCenterTraslation { get; set; }
        public ICollection<DiseaseTraslation> DiseaseTraslation { get; set; }
        public ICollection<AssociationTranslation> AssociationTranslation { get; set; }
    }
}
