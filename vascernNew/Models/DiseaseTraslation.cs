using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vascernNew.Models
{
    public class DiseaseTraslation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CultureId { get; set; }
        public Culture Culture { get; set; }
        public int DiseaseId { get; set; }
        public Disease Disease { get; set; }
    }
}
