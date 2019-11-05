using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class xx4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empresas_tipo_empresa_erp_id_tipo_empresa_erp",
                table: "empresas");

            migrationBuilder.AlterColumn<string[]>(
                name: "telefono",
                table: "empresas",
                type: "varchar(12)[]",
                nullable: true,
                oldClrType: typeof(string[]),
                oldType: "varchar(12)[]");

            migrationBuilder.AlterColumn<short>(
                name: "id_tipo_empresa_erp",
                table: "empresas",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string[]>(
                name: "correo",
                table: "empresas",
                type: "varchar(100)[]",
                nullable: true,
                oldClrType: typeof(string[]),
                oldType: "varchar(100)[]");

            migrationBuilder.AlterColumn<DateTime>(
                name: "fecha_verificacion",
                table: "documento",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz");

            migrationBuilder.AlterColumn<DateTime>(
                name: "fecha_transferencia",
                table: "documento",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "fecha_emision",
                table: "documento",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz");

            migrationBuilder.AlterColumn<DateTime>(
                name: "fecha_contabilizacion",
                table: "documento",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "empresas",
                columns: new[] { "ruc_empresa", "acreedor", "activo", "con_pedido", "condicion_pago", "correo", "domicilio_fiscal", "fecha_registro_proveedor", "habido", "id_tipo_empresa_erp", "logo", "razon_social", "sin_pedido", "telefono", "tipo_tolerancia", "tolerancia" },
                values: new object[] { "20xxxxxxx9", null, true, true, (short)0, new[] { "algun_correo1@gmail.com", "algun_correo2@gmail.com", "algun_correo3@gmail.com", "algun_correo4@gmail.com" }, "Sentado en su tejado ron ron", null, true, null, null, "El gato ron ron", false, new[] { "96875999", "87548965" }, (short)1, 0m });

            migrationBuilder.AddForeignKey(
                name: "FK_empresas_tipo_empresa_erp_id_tipo_empresa_erp",
                table: "empresas",
                column: "id_tipo_empresa_erp",
                principalTable: "tipo_empresa_erp",
                principalColumn: "id_tipo_empresa_erp",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empresas_tipo_empresa_erp_id_tipo_empresa_erp",
                table: "empresas");

            migrationBuilder.DeleteData(
                table: "empresas",
                keyColumn: "ruc_empresa",
                keyValue: "20xxxxxxx9");

            migrationBuilder.AlterColumn<string[]>(
                name: "telefono",
                table: "empresas",
                type: "varchar(12)[]",
                nullable: false,
                oldClrType: typeof(string[]),
                oldType: "varchar(12)[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "id_tipo_empresa_erp",
                table: "empresas",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string[]>(
                name: "correo",
                table: "empresas",
                type: "varchar(100)[]",
                nullable: false,
                oldClrType: typeof(string[]),
                oldType: "varchar(100)[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "fecha_verificacion",
                table: "documento",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "fecha_transferencia",
                table: "documento",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "fecha_emision",
                table: "documento",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "fecha_contabilizacion",
                table: "documento",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_empresas_tipo_empresa_erp_id_tipo_empresa_erp",
                table: "empresas",
                column: "id_tipo_empresa_erp",
                principalTable: "tipo_empresa_erp",
                principalColumn: "id_tipo_empresa_erp",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
