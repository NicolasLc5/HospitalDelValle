using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_del_Valle.Migrations
{
    /// <inheritdoc />
    public partial class ChangesModelsForInternation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PacientesHospitalizados_Usuarios_PacienteID",
                table: "PacientesHospitalizados");

            migrationBuilder.AddColumn<int>(
                name: "HospitalizacionID",
                table: "PruebasLaboratorio",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnfermeroID",
                table: "PacientesHospitalizados",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HabitacionID",
                table: "PacientesHospitalizados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedicoID",
                table: "PacientesHospitalizados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HospitalizacionID",
                table: "HistorialClinico",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    HabitacionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CostoDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.HabitacionID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PruebasLaboratorio_HospitalizacionID",
                table: "PruebasLaboratorio",
                column: "HospitalizacionID");

            migrationBuilder.CreateIndex(
                name: "IX_PacientesHospitalizados_EnfermeroID",
                table: "PacientesHospitalizados",
                column: "EnfermeroID");

            migrationBuilder.CreateIndex(
                name: "IX_PacientesHospitalizados_HabitacionID",
                table: "PacientesHospitalizados",
                column: "HabitacionID");

            migrationBuilder.CreateIndex(
                name: "IX_PacientesHospitalizados_MedicoID",
                table: "PacientesHospitalizados",
                column: "MedicoID");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialClinico_HospitalizacionID",
                table: "HistorialClinico",
                column: "HospitalizacionID");

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialClinico_PacientesHospitalizados_HospitalizacionID",
                table: "HistorialClinico",
                column: "HospitalizacionID",
                principalTable: "PacientesHospitalizados",
                principalColumn: "HospitalizacionID");

            migrationBuilder.AddForeignKey(
                name: "FK_PacientesHospitalizados_Habitaciones_HabitacionID",
                table: "PacientesHospitalizados",
                column: "HabitacionID",
                principalTable: "Habitaciones",
                principalColumn: "HabitacionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PacientesHospitalizados_Usuarios_EnfermeroID",
                table: "PacientesHospitalizados",
                column: "EnfermeroID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PacientesHospitalizados_Usuarios_MedicoID",
                table: "PacientesHospitalizados",
                column: "MedicoID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PacientesHospitalizados_Usuarios_PacienteID",
                table: "PacientesHospitalizados",
                column: "PacienteID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PruebasLaboratorio_PacientesHospitalizados_HospitalizacionID",
                table: "PruebasLaboratorio",
                column: "HospitalizacionID",
                principalTable: "PacientesHospitalizados",
                principalColumn: "HospitalizacionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorialClinico_PacientesHospitalizados_HospitalizacionID",
                table: "HistorialClinico");

            migrationBuilder.DropForeignKey(
                name: "FK_PacientesHospitalizados_Habitaciones_HabitacionID",
                table: "PacientesHospitalizados");

            migrationBuilder.DropForeignKey(
                name: "FK_PacientesHospitalizados_Usuarios_EnfermeroID",
                table: "PacientesHospitalizados");

            migrationBuilder.DropForeignKey(
                name: "FK_PacientesHospitalizados_Usuarios_MedicoID",
                table: "PacientesHospitalizados");

            migrationBuilder.DropForeignKey(
                name: "FK_PacientesHospitalizados_Usuarios_PacienteID",
                table: "PacientesHospitalizados");

            migrationBuilder.DropForeignKey(
                name: "FK_PruebasLaboratorio_PacientesHospitalizados_HospitalizacionID",
                table: "PruebasLaboratorio");

            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropIndex(
                name: "IX_PruebasLaboratorio_HospitalizacionID",
                table: "PruebasLaboratorio");

            migrationBuilder.DropIndex(
                name: "IX_PacientesHospitalizados_EnfermeroID",
                table: "PacientesHospitalizados");

            migrationBuilder.DropIndex(
                name: "IX_PacientesHospitalizados_HabitacionID",
                table: "PacientesHospitalizados");

            migrationBuilder.DropIndex(
                name: "IX_PacientesHospitalizados_MedicoID",
                table: "PacientesHospitalizados");

            migrationBuilder.DropIndex(
                name: "IX_HistorialClinico_HospitalizacionID",
                table: "HistorialClinico");

            migrationBuilder.DropColumn(
                name: "HospitalizacionID",
                table: "PruebasLaboratorio");

            migrationBuilder.DropColumn(
                name: "EnfermeroID",
                table: "PacientesHospitalizados");

            migrationBuilder.DropColumn(
                name: "HabitacionID",
                table: "PacientesHospitalizados");

            migrationBuilder.DropColumn(
                name: "MedicoID",
                table: "PacientesHospitalizados");

            migrationBuilder.DropColumn(
                name: "HospitalizacionID",
                table: "HistorialClinico");

            migrationBuilder.AddForeignKey(
                name: "FK_PacientesHospitalizados_Usuarios_PacienteID",
                table: "PacientesHospitalizados",
                column: "PacienteID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
