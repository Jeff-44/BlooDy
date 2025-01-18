using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlooDyWeb.Migrations
{
    /// <inheritdoc />
    public partial class AjoutDeStock_Composante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreeLe",
                table: "Departements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreePar",
                table: "Departements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifieLe",
                table: "Departements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiePar",
                table: "Departements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreeLe",
                table: "Arrondissements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreePar",
                table: "Arrondissements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifieLe",
                table: "Arrondissements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiePar",
                table: "Arrondissements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeComposantes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DureeVie = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<int>(type: "int", nullable: false),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeComposantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Composantes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeComposanteId = table.Column<long>(type: "bigint", nullable: false),
                    DonId = table.Column<long>(type: "bigint", nullable: false),
                    Volume = table.Column<int>(type: "int", nullable: false),
                    Statut = table.Column<bool>(type: "bit", nullable: false),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Composantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Composantes_Dons_DonId",
                        column: x => x.DonId,
                        principalTable: "Dons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Composantes_TypeComposantes_TypeComposanteId",
                        column: x => x.TypeComposanteId,
                        principalTable: "TypeComposantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Composantes_DonId",
                table: "Composantes",
                column: "DonId");

            migrationBuilder.CreateIndex(
                name: "IX_Composantes_TypeComposanteId",
                table: "Composantes",
                column: "TypeComposanteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Composantes");

            migrationBuilder.DropTable(
                name: "TypeComposantes");

            migrationBuilder.DropColumn(
                name: "CreeLe",
                table: "Departements");

            migrationBuilder.DropColumn(
                name: "CreePar",
                table: "Departements");

            migrationBuilder.DropColumn(
                name: "ModifieLe",
                table: "Departements");

            migrationBuilder.DropColumn(
                name: "ModifiePar",
                table: "Departements");

            migrationBuilder.DropColumn(
                name: "CreeLe",
                table: "Arrondissements");

            migrationBuilder.DropColumn(
                name: "CreePar",
                table: "Arrondissements");

            migrationBuilder.DropColumn(
                name: "ModifieLe",
                table: "Arrondissements");

            migrationBuilder.DropColumn(
                name: "ModifiePar",
                table: "Arrondissements");
        }
    }
}
