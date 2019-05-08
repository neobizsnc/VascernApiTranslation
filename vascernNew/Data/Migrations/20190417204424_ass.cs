using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vascernNew.Data.Migrations
{
    public partial class ass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailDirect",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HowToContact",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lat",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Linkedin",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lng",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameWorkingGroup",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpeningTime",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneDirect",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Service",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Youtube",
                table: "Association",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zipcode",
                table: "Association",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "EmailDirect",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "HowToContact",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "Linkedin",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "NameWorkingGroup",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "OpeningTime",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "PhoneDirect",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "Service",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "Youtube",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "Zipcode",
                table: "Association");
        }
    }
}
