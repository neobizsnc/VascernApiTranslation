using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace vascernNew.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int Type { get; set; }
        public int HcpCenterId { get; set; }
        public HcpCenter HcpCenter { get; set; }
        public int AssociationId { get; set; }
        public Association Association { get; set; }
    }
}
