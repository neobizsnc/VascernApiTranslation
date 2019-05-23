using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vascernNew.Models
{
    public class HcpCenter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<HcpCenterTraslation> HcpCenterTraslation { get; set; }
        public ICollection<DiseaseCenter> DiseaseCenter { get; set; }
        public ICollection<AssociationHcp> AssociationHcp { get; set; }
        public ICollection<CenterEmail> CenterEmail { get; set; }
        public ICollection<CenterPhone> CenterPhone { get; set; }
    }
}
