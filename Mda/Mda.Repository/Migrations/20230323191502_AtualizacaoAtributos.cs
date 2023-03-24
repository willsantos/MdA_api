using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mda.Repository.Migrations
{
    public partial class AtualizacaoAtributos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Rodas",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Rodas_UsuarioId",
                table: "Rodas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rodas_Usuarios_UsuarioId",
                table: "Rodas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rodas_Usuarios_UsuarioId",
                table: "Rodas");

            migrationBuilder.DropIndex(
                name: "IX_Rodas_UsuarioId",
                table: "Rodas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Rodas");
        }
    }
}
