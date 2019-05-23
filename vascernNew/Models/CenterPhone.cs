using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vascernNew.Models
{
    public class CenterPhone
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Phone { get; set; }
        public int HcpCenterId { get; set; }
        public HcpCenter HcpCenter { get; set; }
    }
}
