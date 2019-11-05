using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class New11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_emision",
                table: "documento_errores",
                type: "timestamptz",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "id_tipo_documento",
                table: "documento_errores",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "num_correlativo",
                table: "documento_errores",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "num_serie",
                table: "documento_errores",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "razon_social_cliente",
                table: "documento_errores",
                type: "varchar(400)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "razon_social_proveedor",
                table: "documento_errores",
                type: "varchar(400)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ruc_empresa_cliente",
                table: "documento_errores",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ruc_empresa_proveedor",
                table: "documento_errores",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha_emision",
                table: "documento_errores");

            migrationBuilder.DropColumn(
                name: "id_tipo_documento",
                table: "documento_errores");

            migrationBuilder.DropColumn(
                name: "num_correlativo",
                table: "documento_errores");

            migrationBuilder.DropColumn(
                name: "num_serie",
                table: "documento_errores");

            migrationBuilder.DropColumn(
                name: "razon_social_cliente",
                table: "documento_errores");

            migrationBuilder.DropColumn(
                name: "razon_social_proveedor",
                table: "documento_errores");

            migrationBuilder.DropColumn(
                name: "ruc_empresa_cliente",
                table: "documento_errores");

            migrationBuilder.DropColumn(
                name: "ruc_empresa_proveedor",
                table: "documento_errores");
        }
    }
}
