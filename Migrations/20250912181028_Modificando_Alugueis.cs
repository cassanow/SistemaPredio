using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPredio.Migrations
{
    /// <inheritdoc />
    public partial class Modificando_Alugueis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pago",
                table: "Aluguel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pago",
                table: "Aluguel");
        }
    }
}
