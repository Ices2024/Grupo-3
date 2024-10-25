using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class MigracionDos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Canchas_Deportes_Deporte_ID",
                table: "Canchas");

            migrationBuilder.DropIndex(
                name: "IX_Canchas_Codigo_Deporte",
                table: "Canchas");

            migrationBuilder.DropColumn(
                name: "Codigo_Deporte",
                table: "Canchas");

            migrationBuilder.AlterColumn<int>(
                name: "Deporte_ID",
                table: "Canchas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Deporte_ID1",
                table: "Canchas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Canchas_Deporte_ID1",
                table: "Canchas",
                column: "Deporte_ID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Canchas_Deportes_Deporte_ID1",
                table: "Canchas",
                column: "Deporte_ID1",
                principalTable: "Deportes",
                principalColumn: "Deporte_ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Canchas_Deportes_Deporte_ID1",
                table: "Canchas");

            migrationBuilder.DropIndex(
                name: "IX_Canchas_Deporte_ID1",
                table: "Canchas");

            migrationBuilder.DropColumn(
                name: "Deporte_ID1",
                table: "Canchas");

            migrationBuilder.AlterColumn<int>(
                name: "Deporte_ID",
                table: "Canchas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Codigo_Deporte",
                table: "Canchas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Canchas_Codigo_Deporte",
                table: "Canchas",
                column: "Codigo_Deporte");

            migrationBuilder.AddForeignKey(
                name: "FK_Canchas_Deportes_Deporte_ID",
                table: "Canchas",
                column: "Deporte_ID",
                principalTable: "Deportes",
                principalColumn: "Deporte_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
