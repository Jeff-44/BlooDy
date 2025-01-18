using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlooDyWeb.Migrations
{
    /// <inheritdoc />
    public partial class AjoutTransfusionModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beneficiaires",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonneId = table.Column<long>(type: "bigint", nullable: false),
                    GroupeSanguin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HistoriqueMedical = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonneContactId = table.Column<long>(type: "bigint", nullable: false),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficiaires_Personnes_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medecins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonneId = table.Column<long>(type: "bigint", nullable: false),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medecins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medecins_Personnes_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfusions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupeSanguin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeneficiaireId = table.Column<long>(type: "bigint", nullable: false),
                    ComposanteId = table.Column<long>(type: "bigint", nullable: false),
                    MedecinId = table.Column<long>(type: "bigint", nullable: false),
                    InstitutionSanteId = table.Column<long>(type: "bigint", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    DateTransfusion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Statut = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfusions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfusions_Beneficiaires_BeneficiaireId",
                        column: x => x.BeneficiaireId,
                        principalTable: "Beneficiaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transfusions_Composantes_ComposanteId",
                        column: x => x.ComposanteId,
                        principalTable: "Composantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transfusions_Medecins_MedecinId",
                        column: x => x.MedecinId,
                        principalTable: "Medecins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaires_PersonneId",
                table: "Beneficiaires",
                column: "PersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_Medecins_PersonneId",
                table: "Medecins",
                column: "PersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfusions_BeneficiaireId",
                table: "Transfusions",
                column: "BeneficiaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfusions_ComposanteId",
                table: "Transfusions",
                column: "ComposanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfusions_MedecinId",
                table: "Transfusions",
                column: "MedecinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transfusions");

            migrationBuilder.DropTable(
                name: "Beneficiaires");

            migrationBuilder.DropTable(
                name: "Medecins");
        }
    }
}
