using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class MigracionTres : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_Canchas_Deporte_ID",
                table: "Canchas");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Elementos");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Elementos");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Deportes");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Deportes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Consumiciones");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Consumiciones");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Codigo_Deporte",
                table: "Canchas");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Canchas");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Canchas");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Administradores");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Turnos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Turnos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Proveedores",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Proveedores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Productos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Productos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Elementos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Elementos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Deportes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Deportes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Consumiciones",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Consumiciones",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Clientes",
                type: "datetime2",
                nullable: true);

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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Canchas",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Canchas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Administradores",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Administradores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Canchas_Codigo_Deporte",
                table: "Canchas",
                column: "Codigo_Deporte");

            migrationBuilder.CreateIndex(
                name: "IX_Canchas_Deporte_ID",
                table: "Canchas",
                column: "Deporte_ID");

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
