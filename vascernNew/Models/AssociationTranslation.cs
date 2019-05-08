using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vascernNew.Models
{
    public class AssociationTranslation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameWorkingGroup { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Contact { get; set; }
        public string PhoneDirect { get; set; }
        public string Fax { get; set; }
        public string OpeningTime { get; set; }
        public string HowToContact { get; set; }
        public string EmailDirect { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
        public string Linkedin { get; set; }
        public string Instagram { get; set; }
        public string Service { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Type { get; set; }
        public int CultureId { get; set; }
        public Culture Culture { get; set; }
        public int AssociationId { get; set; }
        public Association Association { get; set; }
    }
}
