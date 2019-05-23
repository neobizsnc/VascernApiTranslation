using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vascernNew.Models;

namespace vascernNew.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Culture> Culture { get; set; }
        public DbSet<HcpCenter> HcpCenters { get; set; }
        public DbSet<HcpCenterTraslation> HcpCenterTraslations { get; set; }
        public DbSet<Disease> Disease { get; set; }
        public DbSet<DiseaseTraslation> DiseaseTraslation { get; set; }
        public DbSet<Association> Association { get; set; }
        public DbSet<AssociationTranslation> AssociationTranslation { get; set; }
        public DbSet<AssociationHcp> AssociationHcp { get; set; }
        public DbSet<DiseaseAssociation> DiseaseAssociation { get; set; }
        public DbSet<DiseaseCenter> DiseaseCenter { get; set; }
        public DbSet<Favourites> Favourites { get; set; }
        public DbSet<CenterEmail> CenterEmail { get; set; }
        public DbSet<CenterPhone> CenterPhone { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
