using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mda.Repository.Migrations
{
    public partial class MigrationCorrecaoTarefa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Tarefas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Tarefas");
        }
    }
}
