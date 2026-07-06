using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoFinalISW.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacionamentosAluguel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alugueis_Livros_LivroId",
                table: "Alugueis");

            migrationBuilder.DropForeignKey(
                name: "FK_Alugueis_Usuarios_UsuarioId",
                table: "Alugueis");

            migrationBuilder.AddForeignKey(
                name: "FK_Alugueis_Livros_LivroId",
                table: "Alugueis",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alugueis_Usuarios_UsuarioId",
                table: "Alugueis",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alugueis_Livros_LivroId",
                table: "Alugueis");

            migrationBuilder.DropForeignKey(
                name: "FK_Alugueis_Usuarios_UsuarioId",
                table: "Alugueis");

            migrationBuilder.AddForeignKey(
                name: "FK_Alugueis_Livros_LivroId",
                table: "Alugueis",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alugueis_Usuarios_UsuarioId",
                table: "Alugueis",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
