using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class new8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "detraccion",
                table: "tipo_documento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "factura_negociable",
                table: "tipo_documento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "factura_origen",
                table: "tipo_documento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "factura_origen_requerido",
                table: "tipo_documento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "monto_isc",
                table: "tipo_documento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "valor_venta_requerido",
                table: "tipo_documento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "01",
                columns: new[] { "detraccion", "factura_negociable", "formato_correlativo", "formato_serie_fisica", "monto_isc" },
                values: new object[] { true, true, "(?!00000000)^[0-9]{8}$", "^[0-9]{4}$", true });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "02",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica", "valor_venta_requerido" },
                values: new object[] { "(?!0000000)^[0-9]{7}$", "^E001$", "^[0-9]{4}$", true });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "03",
                columns: new[] { "formato_correlativo", "formato_serie_fisica", "valor_venta_requerido" },
                values: new object[] { "(?!00000000)^[0-9]{8}$", "^[0-9]{4}$", true });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "05",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica", "mascara_correlativo" },
                values: new object[] { "(?!0000000000)^[0-9]{10}$", "^[1-5]$", "^[1-5]$", (short)10 });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "07",
                columns: new[] { "factura_origen", "factura_origen_requerido", "formato_correlativo", "formato_serie_fisica", "monto_isc" },
                values: new object[] { true, true, "(?!00000000)^[0-9]{8}$", "^[0-9]{4}$", true });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "08",
                columns: new[] { "factura_origen", "formato_correlativo", "formato_serie_fisica", "monto_isc" },
                values: new object[] { true, "(?!00000000)^[0-9]{8}$", "^[0-9]{4}$", true });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "10",
                column: "valor_venta_requerido",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "12",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "^[A-Za-z0-9]{0,20}$", "^[A-Za-z0-9]{0,4}$", "^[A-Za-z0-9]{0,4}$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "13",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "^[A-Za-z0-9]{0,20}$", "^[A-Za-z0-9]{0,4}$", "^[A-Za-z0-9]{0,4}$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "14",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "^[A-Za-z0-9]{0,20}$", "^[A-Za-z0-9]{0,4}$", "^[A-Za-z0-9]{0,4}$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "50",
                columns: new[] { "formato_correlativo", "monto_isc" },
                values: new object[] { "(?!000000)^[0-9]{6}$", true });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "91",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica", "valor_venta_requerido" },
                values: new object[] { "^[A-Za-z0-9]{0,20}$", "^[A-Za-z0-9]{0,4}$", "^[A-Za-z0-9]{0,4}$", true });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "97",
                columns: new[] { "factura_origen", "factura_origen_requerido", "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { true, true, "^[A-Za-z0-9]{0,20}$", "^[A-Za-z0-9]{0,4}$", "^[A-Za-z0-9]{0,4}$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "ER",
                column: "valor_venta_requerido",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "detraccion",
                table: "tipo_documento");

            migrationBuilder.DropColumn(
                name: "factura_negociable",
                table: "tipo_documento");

            migrationBuilder.DropColumn(
                name: "factura_origen",
                table: "tipo_documento");

            migrationBuilder.DropColumn(
                name: "factura_origen_requerido",
                table: "tipo_documento");

            migrationBuilder.DropColumn(
                name: "monto_isc",
                table: "tipo_documento");

            migrationBuilder.DropColumn(
                name: "valor_venta_requerido",
                table: "tipo_documento");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "01",
                columns: new[] { "formato_correlativo", "formato_serie_fisica" },
                values: new object[] { "(?!00000000)[0-9]{8}", "^([0-9]{4})$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "02",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "(?!0000000)[0-9]{7}", "^(E001)$", "^([0-9]{4})$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "03",
                columns: new[] { "formato_correlativo", "formato_serie_fisica" },
                values: new object[] { "(?!00000000)[0-9]{8}", "^([0-9]{4})$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "05",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica", "mascara_correlativo" },
                values: new object[] { "(?!0000000000)[0-9]{10}", "^([1-5])$", "^([1-5])$", (short)0 });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "07",
                columns: new[] { "formato_correlativo", "formato_serie_fisica" },
                values: new object[] { "(?!00000000)[0-9]{8}", "^([0-9]{4})$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "08",
                columns: new[] { "formato_correlativo", "formato_serie_fisica" },
                values: new object[] { "(?!00000000)[0-9]{8}", "^([0-9]{4})$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "12",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "^([A-Za-z0-9]{0,20})$", "^([A-Za-z0-9]{0,4})$", "^([A-Za-z0-9]{0,4})$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "13",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "[A-Za-z0-9]{0,20}", "[A-Za-z0-9]{0,4}", "[A-Za-z0-9]{0,4}" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "14",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "[A-Za-z0-9]{0,20}", "[A-Za-z0-9]{0,4}", "[A-Za-z0-9]{0,4}" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "50",
                column: "formato_correlativo",
                value: "(?!000000)[0-9]{6}");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "91",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "^([A-Za-z0-9]{0,20})$", "^([A-Za-z0-9]{0,4})$", "^([A-Za-z0-9]{0,4})$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "97",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "^([A-Za-z0-9]{0,20})$", "^([A-Za-z0-9]{0,4})$", "^([A-Za-z0-9]{0,4})$" });
        }
    }
}
