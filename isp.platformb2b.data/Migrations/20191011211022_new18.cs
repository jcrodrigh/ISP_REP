using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class new18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nombre_carpeta",
                table: "tipo_documento",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "acreedor",
                table: "empresas",
                type: "varchar(130)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "condicion_pago",
                table: "empresas",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_registro_proveedor",
                table: "empresas",
                type: "timestamptz",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "01",
                column: "nombre_carpeta",
                value: "factura");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "02",
                column: "nombre_carpeta",
                value: "");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "03",
                column: "nombre_carpeta",
                value: "");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "05",
                column: "nombre_carpeta",
                value: "");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "07",
                column: "nombre_carpeta",
                value: "");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "08",
                column: "nombre_carpeta",
                value: "");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "10",
                column: "nombre_carpeta",
                value: "");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "12",
                column: "nombre_carpeta",
                value: "");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "13",
                column: "nombre_carpeta",
                value: "");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "14",
                column: "nombre_carpeta",
                value: "");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "50",
                column: "nombre_carpeta",
                value: "");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "91",
                column: "nombre_carpeta",
                value: "");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "97",
                column: "nombre_carpeta",
                value: "");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "ER",
                column: "nombre_carpeta",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nombre_carpeta",
                table: "tipo_documento");

            migrationBuilder.DropColumn(
                name: "acreedor",
                table: "empresas");

            migrationBuilder.DropColumn(
                name: "condicion_pago",
                table: "empresas");

            migrationBuilder.DropColumn(
                name: "fecha_registro_proveedor",
                table: "empresas");
        }
    }
}
