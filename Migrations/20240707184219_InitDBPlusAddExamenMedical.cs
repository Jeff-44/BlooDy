using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlooDyWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitDBPlusAddExamenMedical : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dossiers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonateurId = table.Column<long>(type: "bigint", nullable: false),
                    Poids = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    Pouls = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    TensionArterielleSystolique = table.Column<int>(type: "int", nullable: false),
                    TensionArterielleDiastolique = table.Column<int>(type: "int", nullable: false),
                    Hemoglobine = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    EtatDeSante = table.Column<bool>(type: "bit", nullable: false),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dossiers_Donateurs_DonateurId",
                        column: x => x.DonateurId,
                        principalTable: "Donateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_DonateurId",
                table: "Dossiers",
                column: "DonateurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropTable(
                name: "Dossiers");

        }
    }
}
