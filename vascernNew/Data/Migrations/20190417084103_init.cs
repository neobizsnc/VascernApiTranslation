using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vascernNew.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "Culture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Culture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HcpCenters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HcpCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HcpCenterTraslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Cordinator = table.Column<string>(nullable: true),
                    CoreService = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CultureId = table.Column<int>(nullable: false),
                    Deparment = table.Column<string>(nullable: true),
                    EmailDirect = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    H24Number = table.Column<string>(nullable: true),
                    HcpCenterId = table.Column<int>(nullable: false),
                    HcpWebsite = table.Column<string>(nullable: true),
                    InfoPointInside = table.Column<string>(nullable: true),
                    InfoPointOutside = table.Column<string>(nullable: true),
                    Ish24 = table.Column<string>(nullable: true),
                    Lat = table.Column<string>(nullable: true),
                    Lng = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OpeningTime = table.Column<string>(nullable: true),
                    OtherSpecialistInside = table.Column<string>(nullable: true),
                    OtherSpecialistOutside = table.Column<string>(nullable: true),
                    PhoneDirect = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Youtube = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HcpCenterTraslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HcpCenterTraslations_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HcpCenterTraslations_HcpCenters_HcpCenterId",
                        column: x => x.HcpCenterId,
                        principalTable: "HcpCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HcpCenterTraslations_CultureId",
                table: "HcpCenterTraslations",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_HcpCenterTraslations_HcpCenterId",
                table: "HcpCenterTraslations",
                column: "HcpCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "HcpCenterTraslations");

            migrationBuilder.DropTable(
                name: "Culture");

            migrationBuilder.DropTable(
                name: "HcpCenters");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
