using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vascernNew.Data.Migrations
{
    public partial class modelnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Association",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Association", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disease",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Orphacode = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disease", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseCenterAssociation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseCenterAssociation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Favourites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StructureId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Uuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssociationHcp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssociationId = table.Column<int>(nullable: false),
                    HcpCenterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociationHcp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssociationHcp_Association_AssociationId",
                        column: x => x.AssociationId,
                        principalTable: "Association",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssociationHcp_HcpCenters_HcpCenterId",
                        column: x => x.HcpCenterId,
                        principalTable: "HcpCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssociationTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    AssociationId = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CultureId = table.Column<int>(nullable: false),
                    EmailDirect = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    HowToContact = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Lat = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    Lng = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameWorkingGroup = table.Column<string>(nullable: true),
                    OpeningTime = table.Column<string>(nullable: true),
                    PhoneDirect = table.Column<string>(nullable: true),
                    Service = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Youtube = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociationTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssociationTranslation_Association_AssociationId",
                        column: x => x.AssociationId,
                        principalTable: "Association",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssociationTranslation_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseTraslation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CultureId = table.Column<int>(nullable: false),
                    DiseaseId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseTraslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiseaseTraslation_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiseaseTraslation_Disease_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Disease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseAssociation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssociationId = table.Column<int>(nullable: false),
                    DiseaseCenterAssociationId = table.Column<int>(nullable: true),
                    DiseaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseAssociation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiseaseAssociation_Association_AssociationId",
                        column: x => x.AssociationId,
                        principalTable: "Association",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiseaseAssociation_DiseaseCenterAssociation_DiseaseCenterAssociationId",
                        column: x => x.DiseaseCenterAssociationId,
                        principalTable: "DiseaseCenterAssociation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiseaseAssociation_Disease_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Disease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseCenter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiseaseCenterAssociationId = table.Column<int>(nullable: true),
                    DiseaseId = table.Column<int>(nullable: false),
                    HcpCenterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseCenter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiseaseCenter_DiseaseCenterAssociation_DiseaseCenterAssociationId",
                        column: x => x.DiseaseCenterAssociationId,
                        principalTable: "DiseaseCenterAssociation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiseaseCenter_Disease_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Disease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiseaseCenter_HcpCenters_HcpCenterId",
                        column: x => x.HcpCenterId,
                        principalTable: "HcpCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssociationHcp_AssociationId",
                table: "AssociationHcp",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssociationHcp_HcpCenterId",
                table: "AssociationHcp",
                column: "HcpCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_AssociationTranslation_AssociationId",
                table: "AssociationTranslation",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssociationTranslation_CultureId",
                table: "AssociationTranslation",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseAssociation_AssociationId",
                table: "DiseaseAssociation",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseAssociation_DiseaseCenterAssociationId",
                table: "DiseaseAssociation",
                column: "DiseaseCenterAssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseAssociation_DiseaseId",
                table: "DiseaseAssociation",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseCenter_DiseaseCenterAssociationId",
                table: "DiseaseCenter",
                column: "DiseaseCenterAssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseCenter_DiseaseId",
                table: "DiseaseCenter",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseCenter_HcpCenterId",
                table: "DiseaseCenter",
                column: "HcpCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseTraslation_CultureId",
                table: "DiseaseTraslation",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseTraslation_DiseaseId",
                table: "DiseaseTraslation",
                column: "DiseaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssociationHcp");

            migrationBuilder.DropTable(
                name: "AssociationTranslation");

            migrationBuilder.DropTable(
                name: "DiseaseAssociation");

            migrationBuilder.DropTable(
                name: "DiseaseCenter");

            migrationBuilder.DropTable(
                name: "DiseaseTraslation");

            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DropTable(
                name: "Association");

            migrationBuilder.DropTable(
                name: "DiseaseCenterAssociation");

            migrationBuilder.DropTable(
                name: "Disease");
        }
    }
}
