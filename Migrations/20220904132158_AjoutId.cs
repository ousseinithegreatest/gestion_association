using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_assoc.Migrations
{
    public partial class AjoutId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Activites",
                table: "Activites");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Activites");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Activites",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activites",
                table: "Activites",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Activites",
                table: "Activites");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Activites");

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Activites",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activites",
                table: "Activites",
                column: "ActivityId");
        }
    }
}
