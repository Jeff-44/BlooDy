using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlooDyWeb.Migrations
{
    /// <inheritdoc />
    public partial class updateChauffeurModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPersonne",
                table: "Chauffeurs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdPersonne",
                table: "Chauffeurs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
