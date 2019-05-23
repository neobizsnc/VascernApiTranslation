using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vascernNew.Data.Migrations
{
    public partial class emailphone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CenterEmail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    HcpCenterId = table.Column<int>(nullable: false),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenterEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CenterEmail_HcpCenters_HcpCenterId",
                        column: x => x.HcpCenterId,
                        principalTable: "HcpCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CenterPhone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HcpCenterId = table.Column<int>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenterPhone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CenterPhone_HcpCenters_HcpCenterId",
                        column: x => x.HcpCenterId,
                        principalTable: "HcpCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CenterEmail_HcpCenterId",
                table: "CenterEmail",
                column: "HcpCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CenterPhone_HcpCenterId",
                table: "CenterPhone",
                column: "HcpCenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CenterEmail");

            migrationBuilder.DropTable(
                name: "CenterPhone");
        }
    }
}
