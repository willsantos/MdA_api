using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mda.Repository.Migrations
{
    public partial class MudancaAtributoObjetivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Objetivos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Objetivos");
        }
    }
}
