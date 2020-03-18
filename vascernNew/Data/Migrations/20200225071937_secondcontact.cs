using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vascernNew.Data.Migrations
{
    public partial class secondcontact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecondEmail",
                table: "HcpCenterTraslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondPhone",
                table: "HcpCenterTraslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondEmail",
                table: "AssociationTranslation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondPhone",
                table: "AssociationTranslation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondEmail",
                table: "HcpCenterTraslations");

            migrationBuilder.DropColumn(
                name: "SecondPhone",
                table: "HcpCenterTraslations");

            migrationBuilder.DropColumn(
                name: "SecondEmail",
                table: "AssociationTranslation");

            migrationBuilder.DropColumn(
                name: "SecondPhone",
                table: "AssociationTranslation");
        }
    }
}
