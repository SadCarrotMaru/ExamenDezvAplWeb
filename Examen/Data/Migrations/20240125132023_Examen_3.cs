using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Migrations
{
    /// <inheritdoc />
    public partial class Examen3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autori_Edituri_IdEditura",
                table: "Autori");

            migrationBuilder.DropTable(
                name: "CartiAutori");

            migrationBuilder.DropIndex(
                name: "IX_Autori_IdEditura",
                table: "Autori");

            migrationBuilder.AddColumn<Guid>(
                name: "EdituraCarteId",
                table: "Autori",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ModelsRelation",
                columns: table => new
                {
                    AutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelsRelation", x => new { x.AutorId, x.CarteId });
                    table.ForeignKey(
                        name: "FK_ModelsRelation_Autori_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelsRelation_Carti_CarteId",
                        column: x => x.CarteId,
                        principalTable: "Carti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autori_EdituraCarteId",
                table: "Autori",
                column: "EdituraCarteId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelsRelation_CarteId",
                table: "ModelsRelation",
                column: "CarteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autori_Edituri_EdituraCarteId",
                table: "Autori",
                column: "EdituraCarteId",
                principalTable: "Edituri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autori_Edituri_EdituraCarteId",
                table: "Autori");

            migrationBuilder.DropTable(
                name: "ModelsRelation");

            migrationBuilder.DropIndex(
                name: "IX_Autori_EdituraCarteId",
                table: "Autori");

            migrationBuilder.DropColumn(
                name: "EdituraCarteId",
                table: "Autori");

            migrationBuilder.CreateTable(
                name: "CartiAutori",
                columns: table => new
                {
                    AutoriId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartiAutori", x => new { x.AutoriId, x.CartiId });
                    table.ForeignKey(
                        name: "FK_CartiAutori_Autori_AutoriId",
                        column: x => x.AutoriId,
                        principalTable: "Autori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartiAutori_Carti_CartiId",
                        column: x => x.CartiId,
                        principalTable: "Carti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autori_IdEditura",
                table: "Autori",
                column: "IdEditura");

            migrationBuilder.CreateIndex(
                name: "IX_CartiAutori_CartiId",
                table: "CartiAutori",
                column: "CartiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autori_Edituri_IdEditura",
                table: "Autori",
                column: "IdEditura",
                principalTable: "Edituri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
