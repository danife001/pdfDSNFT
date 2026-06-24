using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pdfDSNFT.Migrations
{
    /// <inheritdoc />
    public partial class AgregarVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Documentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Documentos");
        }
    }
}
