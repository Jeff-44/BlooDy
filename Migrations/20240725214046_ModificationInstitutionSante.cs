using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlooDyWeb.Migrations
{
    /// <inheritdoc />
    public partial class ModificationInstitutionSante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "InstitutionsSante",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "InstitutionsSante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "InstitutionsSante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "InstitutionsSante");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "InstitutionsSante");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "InstitutionsSante");
        }
    }
}
