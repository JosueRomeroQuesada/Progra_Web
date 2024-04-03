using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class gymdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EjercicioIdEjercicio",
                table: "Machines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rutinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRutina = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Series = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Repeticiones = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Peso = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ejercicio",
                columns: table => new
                {
                    IdEjercicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Zona = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RutinaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejercicio", x => x.IdEjercicio);
                    table.ForeignKey(
                        name: "FK_Ejercicio_Rutinas_RutinaId",
                        column: x => x.RutinaId,
                        principalTable: "Rutinas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Weekday",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDiaSemana = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Dia = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    RutinaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weekday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weekday_Rutinas_RutinaId",
                        column: x => x.RutinaId,
                        principalTable: "Rutinas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Machines_EjercicioIdEjercicio",
                table: "Machines",
                column: "EjercicioIdEjercicio");

            migrationBuilder.CreateIndex(
                name: "IX_Ejercicio_RutinaId",
                table: "Ejercicio",
                column: "RutinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Weekday_RutinaId",
                table: "Weekday",
                column: "RutinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Ejercicio_EjercicioIdEjercicio",
                table: "Machines",
                column: "EjercicioIdEjercicio",
                principalTable: "Ejercicio",
                principalColumn: "IdEjercicio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Ejercicio_EjercicioIdEjercicio",
                table: "Machines");

            migrationBuilder.DropTable(
                name: "Ejercicio");

            migrationBuilder.DropTable(
                name: "Weekday");

            migrationBuilder.DropTable(
                name: "Rutinas");

            migrationBuilder.DropIndex(
                name: "IX_Machines_EjercicioIdEjercicio",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "EjercicioIdEjercicio",
                table: "Machines");
        }
    }
}
