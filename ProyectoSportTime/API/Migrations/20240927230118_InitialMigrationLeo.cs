using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationLeo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cliente_ID",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cliente_ID1",
                table: "Turnos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contraseña",
                table: "Administradores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_Cliente_ID1",
                table: "Turnos",
                column: "Cliente_ID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Clientes_Cliente_ID1",
                table: "Turnos",
                column: "Cliente_ID1",
                principalTable: "Clientes",
                principalColumn: "Cliente_ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Clientes_Cliente_ID1",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_Cliente_ID1",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "Cliente_ID",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "Cliente_ID1",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "Contraseña",
                table: "Administradores");
        }
    }
}
