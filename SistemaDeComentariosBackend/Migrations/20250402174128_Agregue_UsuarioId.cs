using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeComentariosBackend.Migrations
{
    /// <inheritdoc />
    public partial class Agregue_UsuarioId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");
        }
    }
}
