//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//namespace DATA.Migrations
//{
//    public partial class mg1 : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "Utilisateurs",
//                columns: table => new
//                {
//                    Id = table.Column<Guid>(nullable: false),
//                    Nom = table.Column<string>(maxLength: 50, nullable: false),
//                    Prenom = table.Column<string>(maxLength: 50, nullable: false),
//                    Email = table.Column<string>(nullable: false),
//                    MotDePasse = table.Column<string>(nullable: false),
//                    Role = table.Column<string>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
//                });
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "Utilisateurs");
//        }
//    }
//}
