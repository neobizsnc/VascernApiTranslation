﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using vascernNew.Data;

namespace vascernNew.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191028080522_affiliated")]
    partial class affiliated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("vascernNew.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("AssociationId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("HcpCenterId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<int>("Type");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AssociationId");

                    b.HasIndex("HcpCenterId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("vascernNew.Models.Association", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Association");
                });

            modelBuilder.Entity("vascernNew.Models.AssociationHcp", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssociationId");

                    b.Property<int>("HcpCenterId");

                    b.HasKey("Id");

                    b.HasIndex("AssociationId");

                    b.HasIndex("HcpCenterId");

                    b.ToTable("AssociationHcp");
                });

            modelBuilder.Entity("vascernNew.Models.AssociationTranslation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("AssociationId");

                    b.Property<string>("City");

                    b.Property<string>("Contact");

                    b.Property<string>("Country");

                    b.Property<int>("CultureId");

                    b.Property<string>("EmailDirect");

                    b.Property<string>("Facebook");

                    b.Property<string>("Fax");

                    b.Property<string>("HowToContact");

                    b.Property<string>("Instagram");

                    b.Property<string>("Lat");

                    b.Property<string>("Linkedin");

                    b.Property<string>("Lng");

                    b.Property<string>("Name");

                    b.Property<string>("NameWorkingGroup");

                    b.Property<string>("OpeningTime");

                    b.Property<string>("PhoneDirect");

                    b.Property<string>("Service");

                    b.Property<string>("Twitter");

                    b.Property<string>("Type");

                    b.Property<string>("Website");

                    b.Property<string>("Youtube");

                    b.Property<string>("Zipcode");

                    b.HasKey("Id");

                    b.HasIndex("AssociationId");

                    b.HasIndex("CultureId");

                    b.ToTable("AssociationTranslation");
                });

            modelBuilder.Entity("vascernNew.Models.CenterEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<int>("HcpCenterId");

                    b.Property<string>("Label");

                    b.HasKey("Id");

                    b.HasIndex("HcpCenterId");

                    b.ToTable("CenterEmail");
                });

            modelBuilder.Entity("vascernNew.Models.CenterPhone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HcpCenterId");

                    b.Property<string>("Label");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.HasIndex("HcpCenterId");

                    b.ToTable("CenterPhone");
                });

            modelBuilder.Entity("vascernNew.Models.Culture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Culture");
                });

            modelBuilder.Entity("vascernNew.Models.Disease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Orphacode");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.ToTable("Disease");
                });

            modelBuilder.Entity("vascernNew.Models.DiseaseAssociation", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssociationId");

                    b.Property<int>("DiseaseId");

                    b.HasKey("Id");

                    b.HasIndex("AssociationId");

                    b.HasIndex("DiseaseId");

                    b.ToTable("DiseaseAssociation");
                });

            modelBuilder.Entity("vascernNew.Models.DiseaseCenter", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DiseaseId");

                    b.Property<int>("HcpCenterId");

                    b.HasKey("Id");

                    b.HasIndex("DiseaseId");

                    b.HasIndex("HcpCenterId");

                    b.ToTable("DiseaseCenter");
                });

            modelBuilder.Entity("vascernNew.Models.DiseaseTraslation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CultureId");

                    b.Property<int>("DiseaseId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CultureId");

                    b.HasIndex("DiseaseId");

                    b.ToTable("DiseaseTraslation");
                });

            modelBuilder.Entity("vascernNew.Models.Favourites", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("StructureId");

                    b.Property<string>("Type");

                    b.Property<string>("Uuid");

                    b.HasKey("Id");

                    b.ToTable("Favourites");
                });

            modelBuilder.Entity("vascernNew.Models.HcpCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("HcpCenters");
                });

            modelBuilder.Entity("vascernNew.Models.HcpCenterTraslation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Cordinator");

                    b.Property<string>("CoreService");

                    b.Property<string>("Country");

                    b.Property<int>("CultureId");

                    b.Property<string>("Deparment");

                    b.Property<string>("EmailDirect");

                    b.Property<string>("Facebook");

                    b.Property<string>("Fax");

                    b.Property<string>("H24Number");

                    b.Property<int>("HcpCenterId");

                    b.Property<string>("HcpWebsite");

                    b.Property<string>("InfoPointInside");

                    b.Property<string>("InfoPointOutside");

                    b.Property<bool>("IsAffiliated");

                    b.Property<bool>("IsEarn");

                    b.Property<string>("Ish24");

                    b.Property<string>("Lat");

                    b.Property<string>("Lng");

                    b.Property<string>("Name");

                    b.Property<string>("OpeningTime");

                    b.Property<string>("OtherSpecialistInside");

                    b.Property<string>("OtherSpecialistOutside");

                    b.Property<string>("PhoneDirect");

                    b.Property<string>("Twitter");

                    b.Property<string>("Type");

                    b.Property<string>("Website");

                    b.Property<string>("Youtube");

                    b.Property<string>("Zipcode");

                    b.HasKey("Id");

                    b.HasIndex("CultureId");

                    b.HasIndex("HcpCenterId");

                    b.ToTable("HcpCenterTraslations");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("vascernNew.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("vascernNew.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vascernNew.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("vascernNew.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vascernNew.Models.ApplicationUser", b =>
                {
                    b.HasOne("vascernNew.Models.Association", "Association")
                        .WithMany("ApplicationUser")
                        .HasForeignKey("AssociationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vascernNew.Models.HcpCenter", "HcpCenter")
                        .WithMany("ApplicationUser")
                        .HasForeignKey("HcpCenterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vascernNew.Models.AssociationHcp", b =>
                {
                    b.HasOne("vascernNew.Models.Association", "Association")
                        .WithMany("AssociationHcp")
                        .HasForeignKey("AssociationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vascernNew.Models.HcpCenter", "HcpCenter")
                        .WithMany("AssociationHcp")
                        .HasForeignKey("HcpCenterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vascernNew.Models.AssociationTranslation", b =>
                {
                    b.HasOne("vascernNew.Models.Association", "Association")
                        .WithMany("AssociationTranslation")
                        .HasForeignKey("AssociationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vascernNew.Models.Culture", "Culture")
                        .WithMany("AssociationTranslation")
                        .HasForeignKey("CultureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vascernNew.Models.CenterEmail", b =>
                {
                    b.HasOne("vascernNew.Models.HcpCenter", "HcpCenter")
                        .WithMany("CenterEmail")
                        .HasForeignKey("HcpCenterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vascernNew.Models.CenterPhone", b =>
                {
                    b.HasOne("vascernNew.Models.HcpCenter", "HcpCenter")
                        .WithMany("CenterPhone")
                        .HasForeignKey("HcpCenterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vascernNew.Models.DiseaseAssociation", b =>
                {
                    b.HasOne("vascernNew.Models.Association", "Association")
                        .WithMany("DiseaseAssociation")
                        .HasForeignKey("AssociationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vascernNew.Models.Disease", "Disease")
                        .WithMany("DiseaseAssociation")
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vascernNew.Models.DiseaseCenter", b =>
                {
                    b.HasOne("vascernNew.Models.Disease", "Disease")
                        .WithMany("DiseaseCenter")
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vascernNew.Models.HcpCenter", "HcpCenter")
                        .WithMany("DiseaseCenter")
                        .HasForeignKey("HcpCenterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vascernNew.Models.DiseaseTraslation", b =>
                {
                    b.HasOne("vascernNew.Models.Culture", "Culture")
                        .WithMany("DiseaseTraslation")
                        .HasForeignKey("CultureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vascernNew.Models.Disease", "Disease")
                        .WithMany("DiseaseTraslation")
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vascernNew.Models.HcpCenterTraslation", b =>
                {
                    b.HasOne("vascernNew.Models.Culture", "Culture")
                        .WithMany("HcpCenterTraslation")
                        .HasForeignKey("CultureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vascernNew.Models.HcpCenter", "HcpCenter")
                        .WithMany("HcpCenterTraslation")
                        .HasForeignKey("HcpCenterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
