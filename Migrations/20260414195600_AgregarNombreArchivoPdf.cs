using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pdfDSNFT.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNombreArchivoPdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreArchivoPdf",
                table: "Documentos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreArchivoPdf",
                table: "Documentos");
        }
    }
}
