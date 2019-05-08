using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vascernNew.Models
{
    public class DiseaseCenter
    {
        public int? Id { get; set; }

        public int DiseaseId { get; set; }
        public Disease Disease { get; set; }

        public int HcpCenterId { get; set; }
        public HcpCenter HcpCenter { get; set; }
    }
}
