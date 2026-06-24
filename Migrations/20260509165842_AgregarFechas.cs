using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pdfDSNFT.Migrations
{
    /// <inheritdoc />
    public partial class AgregarFechas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPostValidacion",
                table: "Documentos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaValidacionInicial",
                table: "Documentos",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaPostValidacion",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "FechaValidacionInicial",
                table: "Documentos");
        }
    }
}
