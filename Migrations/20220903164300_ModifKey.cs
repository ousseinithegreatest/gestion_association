using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_assoc.Migrations
{
    public partial class ModifKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activites",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date_prev = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_exec = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Besoins = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompteRendu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lieu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activites", x => x.ActivityId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activites");
        }
    }
}
