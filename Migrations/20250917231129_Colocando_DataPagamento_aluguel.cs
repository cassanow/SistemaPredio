using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPredio.Migrations
{
    /// <inheritdoc />
    public partial class Colocando_DataPagamento_aluguel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataPagamento",
                table: "Aluguel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPagamento",
                table: "Aluguel");
        }
    }
}
