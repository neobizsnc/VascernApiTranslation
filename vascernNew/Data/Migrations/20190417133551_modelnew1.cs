using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vascernNew.Data.Migrations
{
    public partial class modelnew1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiseaseAssociation_DiseaseCenterAssociation_DiseaseCenterAssociationId",
                table: "DiseaseAssociation");

            migrationBuilder.DropForeignKey(
                name: "FK_DiseaseCenter_DiseaseCenterAssociation_DiseaseCenterAssociationId",
                table: "DiseaseCenter");

            migrationBuilder.DropTable(
                name: "DiseaseCenterAssociation");

            migrationBuilder.DropIndex(
                name: "IX_DiseaseCenter_DiseaseCenterAssociationId",
                table: "DiseaseCenter");

            migrationBuilder.DropIndex(
                name: "IX_DiseaseAssociation_DiseaseCenterAssociationId",
                table: "DiseaseAssociation");

            migrationBuilder.DropColumn(
                name: "DiseaseCenterAssociationId",
                table: "DiseaseCenter");

            migrationBuilder.DropColumn(
                name: "DiseaseCenterAssociationId",
                table: "DiseaseAssociation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiseaseCenterAssociationId",
                table: "DiseaseCenter",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiseaseCenterAssociationId",
                table: "DiseaseAssociation",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseCenter_DiseaseCenterAssociationId",
                table: "DiseaseCenter",
                column: "DiseaseCenterAssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseAssociation_DiseaseCenterAssociationId",
                table: "DiseaseAssociation",
                column: "DiseaseCenterAssociationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiseaseAssociation_DiseaseCenterAssociation_DiseaseCenterAssociationId",
                table: "DiseaseAssociation",
                column: "DiseaseCenterAssociationId",
                principalTable: "DiseaseCenterAssociation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DiseaseCenter_DiseaseCenterAssociation_DiseaseCenterAssociationId",
                table: "DiseaseCenter",
                column: "DiseaseCenterAssociationId",
                principalTable: "DiseaseCenterAssociation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
