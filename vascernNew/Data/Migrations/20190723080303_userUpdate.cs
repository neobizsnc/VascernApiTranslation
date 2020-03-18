using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vascernNew.Data.Migrations
{
    public partial class userUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HcpCenterId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HcpCenterId",
                table: "AspNetUsers",
                column: "HcpCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_HcpCenters_HcpCenterId",
                table: "AspNetUsers",
                column: "HcpCenterId",
                principalTable: "HcpCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_HcpCenters_HcpCenterId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HcpCenterId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HcpCenterId",
                table: "AspNetUsers");
        }
    }
}
