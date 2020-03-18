using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vascernNew.Data.Migrations
{
    public partial class secondwebsite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HcpSecondWebsite",
                table: "HcpCenterTraslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondWebsite",
                table: "AssociationTranslation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HcpSecondWebsite",
                table: "HcpCenterTraslations");

            migrationBuilder.DropColumn(
                name: "SecondWebsite",
                table: "AssociationTranslation");
        }
    }
}
