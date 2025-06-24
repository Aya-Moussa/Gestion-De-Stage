using Microsoft.EntityFrameworkCore.Migrations;

namespace DATA.Migrations
{
    public partial class new5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                     name: "Discriminator",
                     table: "Utilisateurs",
                     nullable: true,
                     defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
            name: "Discriminator",
            table: "Utilisateurs");
         
        }
    }
}
