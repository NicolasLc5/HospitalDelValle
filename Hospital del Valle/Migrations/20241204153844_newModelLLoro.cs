using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_del_Valle.Migrations
{
    /// <inheritdoc />
    public partial class newModelLLoro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resultado",
                table: "Citas");

            migrationBuilder.CreateTable(
                name: "CitasReservas",
                columns: table => new
                {
                    ReservaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteID = table.Column<int>(type: "int", nullable: false),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitasReservas", x => x.ReservaID);
                    table.ForeignKey(
                        name: "FK_CitasReservas_Usuarios_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitasReservas_PacienteID",
                table: "CitasReservas",
                column: "PacienteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitasReservas");

            migrationBuilder.AddColumn<string>(
                name: "Resultado",
                table: "Citas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
