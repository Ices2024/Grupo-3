using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTime.Migrations
{
    /// <inheritdoc />
    public partial class Migracion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Elementos",
                table: "Canchas");

            migrationBuilder.AddColumn<int>(
                name: "Proveedor_ID",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProveedoresProveedor_ID",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Elementos",
                columns: table => new
                {
                    Elemento_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Cancha_ID = table.Column<int>(type: "int", nullable: false),
                    CanchasCancha_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elementos", x => x.Elemento_ID);
                    table.ForeignKey(
                        name: "FK_Elementos_Canchas_CanchasCancha_ID",
                        column: x => x.CanchasCancha_ID,
                        principalTable: "Canchas",
                        principalColumn: "Cancha_ID");
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Proveedor_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Proveedor_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ProveedoresProveedor_ID",
                table: "Productos",
                column: "ProveedoresProveedor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Elementos_CanchasCancha_ID",
                table: "Elementos",
                column: "CanchasCancha_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Proveedores_ProveedoresProveedor_ID",
                table: "Productos",
                column: "ProveedoresProveedor_ID",
                principalTable: "Proveedores",
                principalColumn: "Proveedor_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Proveedores_ProveedoresProveedor_ID",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Elementos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropIndex(
                name: "IX_Productos_ProveedoresProveedor_ID",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Proveedor_ID",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ProveedoresProveedor_ID",
                table: "Productos");

            migrationBuilder.AddColumn<string>(
                name: "Elementos",
                table: "Canchas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
