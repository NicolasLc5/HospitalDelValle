using Microsoft.EntityFrameworkCore.Migrations;


#nullable disable

namespace Hospital_del_Valle.Migrations
{
    /// <inheritdoc />
    public partial class ModeloFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreLaboratorio",
                table: "CitasReservas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Resultado",
                table: "CitasReservas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreLaboratorio",
                table: "CitasReservas");

            migrationBuilder.DropColumn(
                name: "Resultado",
                table: "CitasReservas");
        }
    }
}
