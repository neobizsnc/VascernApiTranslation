using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vascernNew.Models
{
    public class DiseaseCenterAssociation
    {
        public List<DiseaseCenter> diseaseCenter { get; set; }
        public List<DiseaseAssociation> diseaseAssociation { get; set; }
    }
}
