using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vascernNew.Data.Migrations
{
    public partial class modelnew2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cordinator",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoreService",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Deparment",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailDirect",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "H24Number",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HcpWebsite",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoPointInside",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoPointOutside",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ish24",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lat",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lng",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpeningTime",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherSpecialistInside",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherSpecialistOutside",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneDirect",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Youtube",
                table: "HcpCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zipcode",
                table: "HcpCenters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "City",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "Cordinator",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "CoreService",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "Deparment",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "EmailDirect",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "H24Number",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "HcpWebsite",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "InfoPointInside",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "InfoPointOutside",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "Ish24",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "OpeningTime",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "OtherSpecialistInside",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "OtherSpecialistOutside",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "PhoneDirect",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "Youtube",
                table: "HcpCenters");

            migrationBuilder.DropColumn(
                name: "Zipcode",
                table: "HcpCenters");
        }
    }
}
