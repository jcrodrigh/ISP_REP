using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class new6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "formato_factura_origen_serie",
                table: "tipo_documento",
                type: "varchar(800)",
                nullable: true);

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
                columns: new[] { "formato_correlativo", "formato_serie_fisica" },
                values: new object[] { "(?!0000000)[0-9]{7}", "^([0-9]{4})$" });

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
                column: "formato_correlativo",
                value: "(?!0000000000)[0-9]{10}");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "07",
                columns: new[] { "formato_correlativo", "formato_factura_origen_serie", "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "(?!00000000)[0-9]{8}", "^(E001|F[A-Z0-9]{3}|[0-9]{4})$", "^(E001|EB01|B[A-Z0-9]{3}|F[A-Z0-9]{3})$", "^([0-9]{4})$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "08",
                columns: new[] { "formato_correlativo", "formato_factura_origen_serie", "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "(?!00000000)[0-9]{8}", "^(E001|F[A-Z0-9]{3}|[0-9]{4})$", "^(E001|EB01|B[A-Z0-9]{3}|F[A-Z0-9]{3})$", "^([0-9]{4})$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "50",
                columns: new[] { "formato_correlativo", "formato_serie_electronica" },
                values: new object[] { "(?!00000000)[0-9]{8}", "^([A-Z0-9]{0,20}|)$" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "formato_factura_origen_serie",
                table: "tipo_documento");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "01",
                columns: new[] { "formato_correlativo", "formato_serie_fisica" },
                values: new object[] { "^([0-9]{7}[1-9])$", "^([0-9]{3}[1-9])$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "02",
                columns: new[] { "formato_correlativo", "formato_serie_fisica" },
                values: new object[] { "^([0-9]{6}[1-9])$", "^([0-9]{3}[1-9])$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "03",
                columns: new[] { "formato_correlativo", "formato_serie_fisica" },
                values: new object[] { "^([0-9]{7}[1-9])$", "^([0-9]{3}[1-9])$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "05",
                column: "formato_correlativo",
                value: "^([1-9][0-9]{0,10})$");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "07",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "^([0-9]{7}[1-9])$", "^(EB01|EB01|B[A-Z0-9]{3}|F[A-Z0-9]{3})$", "^([0-9]{3}[1-9])$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "08",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "^([0-9]{7}[1-9])$", "^(EB01|EB01|B[A-Z0-9]{3}|F[A-Z0-9]{3})$", "^([0-9]{3}[1-9])$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "50",
                columns: new[] { "formato_correlativo", "formato_serie_electronica" },
                values: new object[] { "^([0-9]{7}[1-9])$", "^(EB01|EB01|B[A-Z0-9]{3}|F[A-Z0-9]{3})$" });
        }
    }
}
