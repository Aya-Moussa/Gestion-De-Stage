using Microsoft.EntityFrameworkCore.Migrations;

namespace DATA.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "valider",
                table: "Journaux",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AttestationAffected",
                table: "Evaluations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LienDriveCV",
                table: "Candidatures",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "valider",
                table: "Journaux");

            migrationBuilder.DropColumn(
                name: "AttestationAffected",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "LienDriveCV",
                table: "Candidatures");
        }
    }
}
