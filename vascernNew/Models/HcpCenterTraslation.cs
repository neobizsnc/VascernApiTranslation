using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vascernNew.Models
{
    public class HcpCenterTraslation
    {
        public int Id { get; set; }
        public string Website { get; set; }
        public string Name { get; set; }
        public string Deparment { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string Cordinator { get; set; }
        public string EmailDirect { get; set; }
        public string PhoneDirect { get; set; }
        public string Fax { get; set; }
        public string OpeningTime { get; set; }
        public string CoreService { get; set; }
        public string OtherSpecialistInside { get; set; }
        public string OtherSpecialistOutside { get; set; }
        public string Ish24 { get; set; }
        public string H24Number { get; set; }
        public string HcpWebsite { get; set; }
        public string Youtube { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string InfoPointInside { get; set; }
        public string InfoPointOutside { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Type { get; set; }
        public int CultureId { get; set; }
        public Culture Culture { get; set; }
        public int HcpCenterId { get; set; }
        public HcpCenter HcpCenter { get; set; }
    }
}
