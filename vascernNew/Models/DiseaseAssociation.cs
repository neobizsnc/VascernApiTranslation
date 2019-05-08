using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vascernNew.Models
{
    public class DiseaseAssociation
    {
        public int? Id { get; set; }

        public int DiseaseId { get; set; }
        public Disease Disease { get; set; }

        public int AssociationId { get; set; }
        public Association Association { get; set; }
    }
}
