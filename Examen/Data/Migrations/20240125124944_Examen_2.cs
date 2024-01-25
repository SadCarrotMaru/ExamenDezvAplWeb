using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Migrations
{
    /// <inheritdoc />
    public partial class Examen2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carti_Edituri_IdEditura",
                table: "Carti");

            migrationBuilder.DropIndex(
                name: "IX_Carti_IdEditura",
                table: "Carti");

            migrationBuilder.DropColumn(
                name: "IdEditura",
                table: "Carti");

            migrationBuilder.AddColumn<Guid>(
                name: "IdEditura",
                table: "Autori",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Autori_IdEditura",
                table: "Autori",
                column: "IdEditura");

            migrationBuilder.AddForeignKey(
                name: "FK_Autori_Edituri_IdEditura",
                table: "Autori",
                column: "IdEditura",
                principalTable: "Edituri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autori_Edituri_IdEditura",
                table: "Autori");

            migrationBuilder.DropIndex(
                name: "IX_Autori_IdEditura",
                table: "Autori");

            migrationBuilder.DropColumn(
                name: "IdEditura",
                table: "Autori");

            migrationBuilder.AddColumn<Guid>(
                name: "IdEditura",
                table: "Carti",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Carti_IdEditura",
                table: "Carti",
                column: "IdEditura");

            migrationBuilder.AddForeignKey(
                name: "FK_Carti_Edituri_IdEditura",
                table: "Carti",
                column: "IdEditura",
                principalTable: "Edituri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
