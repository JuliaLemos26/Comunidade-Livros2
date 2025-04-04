using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComunidadeLivros2.Migrations
{
    /// <inheritdoc />
    public partial class Favoritos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserLivro",
                columns: table => new
                {
                    LivrosFavoritosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosFavoritosId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserLivro", x => new { x.LivrosFavoritosId, x.UsuariosFavoritosId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserLivro_AspNetUsers_UsuariosFavoritosId",
                        column: x => x.UsuariosFavoritosId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserLivro_Livros_LivrosFavoritosId",
                        column: x => x.LivrosFavoritosId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserLivro_UsuariosFavoritosId",
                table: "ApplicationUserLivro",
                column: "UsuariosFavoritosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserLivro");
        }
    }
}
