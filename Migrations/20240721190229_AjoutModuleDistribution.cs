using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlooDyWeb.Migrations
{
    /// <inheritdoc />
    public partial class AjoutModuleDistribution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chauffeurs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPersonne = table.Column<long>(type: "bigint", nullable: false),
                    PersonneId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCentre = table.Column<long>(type: "bigint", nullable: false),
                    CentreId = table.Column<long>(type: "bigint", nullable: true),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chauffeurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chauffeurs_Centres_CentreId",
                        column: x => x.CentreId,
                        principalTable: "Centres",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chauffeurs_Personnes_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Distributions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDemande = table.Column<long>(type: "bigint", nullable: false),
                    DateDistribution = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    Statut = table.Column<int>(type: "int", nullable: false),
                    IdContactDestinataire = table.Column<long>(type: "bigint", nullable: false),
                    ContactDestinataireId = table.Column<long>(type: "bigint", nullable: true),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Distributions_Personnes_ContactDestinataireId",
                        column: x => x.ContactDestinataireId,
                        principalTable: "Personnes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InstitutionsSante",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categorie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdVille = table.Column<long>(type: "bigint", nullable: false),
                    Statut = table.Column<bool>(type: "bit", nullable: false),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionsSante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogDistribution",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDistribution = table.Column<long>(type: "bigint", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogDistribution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDistribution = table.Column<long>(type: "bigint", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdDestinataire = table.Column<long>(type: "bigint", nullable: false),
                    DestinataireId = table.Column<long>(type: "bigint", nullable: true),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Personnes_DestinataireId",
                        column: x => x.DestinataireId,
                        principalTable: "Personnes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDistribution = table.Column<long>(type: "bigint", nullable: false),
                    DistributionId = table.Column<long>(type: "bigint", nullable: true),
                    TypeDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheminFichier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Distributions_DistributionId",
                        column: x => x.DistributionId,
                        principalTable: "Distributions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDistribution = table.Column<long>(type: "bigint", nullable: false),
                    DistributionId = table.Column<long>(type: "bigint", nullable: true),
                    ModeTransport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroVehicule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdChauffeur = table.Column<long>(type: "bigint", nullable: false),
                    ChauffeurId = table.Column<long>(type: "bigint", nullable: true),
                    HeureDepart = table.Column<TimeOnly>(type: "time", nullable: false),
                    HeureArrivee = table.Column<TimeOnly>(type: "time", nullable: true),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemperatureTransport = table.Column<int>(type: "int", nullable: false),
                    HeureCheckTemperature = table.Column<TimeOnly>(type: "time", nullable: false),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transports_Chauffeurs_ChauffeurId",
                        column: x => x.ChauffeurId,
                        principalTable: "Chauffeurs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transports_Distributions_DistributionId",
                        column: x => x.DistributionId,
                        principalTable: "Distributions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Demandes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdInstitutionSante = table.Column<long>(type: "bigint", nullable: false),
                    InstitutionSanteId = table.Column<long>(type: "bigint", nullable: true),
                    GroupeSanguin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTypeComposante = table.Column<long>(type: "bigint", nullable: false),
                    TypeComposanteId = table.Column<long>(type: "bigint", nullable: true),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiePar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demandes_InstitutionsSante_InstitutionSanteId",
                        column: x => x.InstitutionSanteId,
                        principalTable: "InstitutionsSante",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Demandes_TypeComposantes_TypeComposanteId",
                        column: x => x.TypeComposanteId,
                        principalTable: "TypeComposantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chauffeurs_CentreId",
                table: "Chauffeurs",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Chauffeurs_PersonneId",
                table: "Chauffeurs",
                column: "PersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_Demandes_InstitutionSanteId",
                table: "Demandes",
                column: "InstitutionSanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Demandes_TypeComposanteId",
                table: "Demandes",
                column: "TypeComposanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Distributions_ContactDestinataireId",
                table: "Distributions",
                column: "ContactDestinataireId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DistributionId",
                table: "Documents",
                column: "DistributionId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_DestinataireId",
                table: "Notifications",
                column: "DestinataireId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_ChauffeurId",
                table: "Transports",
                column: "ChauffeurId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_DistributionId",
                table: "Transports",
                column: "DistributionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demandes");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "LogDistribution");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropTable(
                name: "InstitutionsSante");

            migrationBuilder.DropTable(
                name: "Chauffeurs");

            migrationBuilder.DropTable(
                name: "Distributions");
        }
    }
}
