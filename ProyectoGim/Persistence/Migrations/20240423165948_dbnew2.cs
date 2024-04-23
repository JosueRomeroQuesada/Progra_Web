using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class dbnew2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Clients_ClientId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_ClientId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Instructors");

            migrationBuilder.CreateTable(
                name: "ClientInstructor",
                columns: table => new
                {
                    ClientsId = table.Column<int>(type: "int", nullable: false),
                    InstructorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientInstructor", x => new { x.ClientsId, x.InstructorsId });
                    table.ForeignKey(
                        name: "FK_ClientInstructor_Clients_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientInstructor_Instructors_InstructorsId",
                        column: x => x.InstructorsId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientInstructor_InstructorsId",
                table: "ClientInstructor",
                column: "InstructorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientInstructor");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Instructors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_ClientId",
                table: "Instructors",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Clients_ClientId",
                table: "Instructors",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
