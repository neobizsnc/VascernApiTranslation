using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vascernNew.Models
{
    public class AssociationHcp
    {
        public int? Id { get; set; }

        public int AssociationId { get; set; }
        public Association Association { get; set; }

        public int HcpCenterId { get; set; }
        public HcpCenter HcpCenter { get; set; }
    }
}
