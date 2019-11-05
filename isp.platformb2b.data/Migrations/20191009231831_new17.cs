using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class new17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_contabilizacion",
                table: "documento",
                type: "timestamptz",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_transferencia",
                table: "documento",
                type: "timestamptz",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_verificacion",
                table: "documento",
                type: "timestamptz",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "nro_conformidad_oc",
                table: "documento",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nro_registro_contable",
                table: "documento",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usuario_verificacion",
                table: "documento",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "50",
                column: "mascara_serie_fisica",
                value: (short)3);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "97",
                column: "valor_venta_requerido",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha_contabilizacion",
                table: "documento");

            migrationBuilder.DropColumn(
                name: "fecha_transferencia",
                table: "documento");

            migrationBuilder.DropColumn(
                name: "fecha_verificacion",
                table: "documento");

            migrationBuilder.DropColumn(
                name: "nro_conformidad_oc",
                table: "documento");

            migrationBuilder.DropColumn(
                name: "nro_registro_contable",
                table: "documento");

            migrationBuilder.DropColumn(
                name: "usuario_verificacion",
                table: "documento");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "50",
                column: "mascara_serie_fisica",
                value: (short)0);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "97",
                column: "valor_venta_requerido",
                value: false);
        }
    }
}
