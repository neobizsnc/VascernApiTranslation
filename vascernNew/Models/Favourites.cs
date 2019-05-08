using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vascernNew.Models
{
    public class Favourites
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string Type { get; set; }
        public int StructureId { get; set; }
    }
}
