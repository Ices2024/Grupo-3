using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTime.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Admin_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Admin_ID);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Cliente_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Cliente_ID);
                });

            migrationBuilder.CreateTable(
                name: "Deportes",
                columns: table => new
                {
                    Deporte_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deportes", x => x.Deporte_ID);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Producto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Producto_ID);
                });

            migrationBuilder.CreateTable(
                name: "Canchas",
                columns: table => new
                {
                    Cancha_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Elementos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo_Deporte = table.Column<int>(type: "int", nullable: false),
                    Deporte_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canchas", x => x.Cancha_ID);
                    table.ForeignKey(
                        name: "FK_Canchas_Deportes_Deporte_ID",
                        column: x => x.Deporte_ID,
                        principalTable: "Deportes",
                        principalColumn: "Deporte_ID");
                });

            migrationBuilder.CreateTable(
                name: "Consumiciones",
                columns: table => new
                {
                    Consumicion_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<bool>(type: "bit", nullable: false),
                    Cod_Producto = table.Column<int>(type: "int", nullable: false),
                    Producto_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumiciones", x => x.Consumicion_ID);
                    table.ForeignKey(
                        name: "FK_Consumiciones_Productos_Producto_ID",
                        column: x => x.Producto_ID,
                        principalTable: "Productos",
                        principalColumn: "Producto_ID");
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Turno_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admin_ID = table.Column<int>(type: "int", nullable: false),
                    Cancha_ID = table.Column<int>(type: "int", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Consumicion_ID = table.Column<int>(type: "int", nullable: false),
                    AdministradorAdmin_ID = table.Column<int>(type: "int", nullable: true),
                    CanchasCancha_ID = table.Column<int>(type: "int", nullable: true),
                    Consumicion_ID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Turno_ID);
                    table.ForeignKey(
                        name: "FK_Turnos_Administradores_AdministradorAdmin_ID",
                        column: x => x.AdministradorAdmin_ID,
                        principalTable: "Administradores",
                        principalColumn: "Admin_ID");
                    table.ForeignKey(
                        name: "FK_Turnos_Canchas_CanchasCancha_ID",
                        column: x => x.CanchasCancha_ID,
                        principalTable: "Canchas",
                        principalColumn: "Cancha_ID");
                    table.ForeignKey(
                        name: "FK_Turnos_Consumiciones_Consumicion_ID1",
                        column: x => x.Consumicion_ID1,
                        principalTable: "Consumiciones",
                        principalColumn: "Consumicion_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canchas_Deporte_ID",
                table: "Canchas",
                column: "Deporte_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Consumiciones_Producto_ID",
                table: "Consumiciones",
                column: "Producto_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_AdministradorAdmin_ID",
                table: "Turnos",
                column: "AdministradorAdmin_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_CanchasCancha_ID",
                table: "Turnos",
                column: "CanchasCancha_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_Consumicion_ID1",
                table: "Turnos",
                column: "Consumicion_ID1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Canchas");

            migrationBuilder.DropTable(
                name: "Consumiciones");

            migrationBuilder.DropTable(
                name: "Deportes");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
