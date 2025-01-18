using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlooDyWeb.Migrations
{
    /// <inheritdoc />
    public partial class updateChauffeurModelForCentreId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chauffeurs_Centres_CentreId",
                table: "Chauffeurs");

            migrationBuilder.DropColumn(
                name: "IdCentre",
                table: "Chauffeurs");

            migrationBuilder.AlterColumn<long>(
                name: "CentreId",
                table: "Chauffeurs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chauffeurs_Centres_CentreId",
                table: "Chauffeurs",
                column: "CentreId",
                principalTable: "Centres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chauffeurs_Centres_CentreId",
                table: "Chauffeurs");

            migrationBuilder.AlterColumn<long>(
                name: "CentreId",
                table: "Chauffeurs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "IdCentre",
                table: "Chauffeurs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Chauffeurs_Centres_CentreId",
                table: "Chauffeurs",
                column: "CentreId",
                principalTable: "Centres",
                principalColumn: "Id");
        }
    }
}
