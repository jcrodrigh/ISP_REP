using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class new9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nombre_inafecto",
                table: "tipo_documento");

            migrationBuilder.DropColumn(
                name: "anticipo",
                table: "documento");

            migrationBuilder.AddColumn<bool>(
                name: "igv_calculado",
                table: "tipo_documento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "01",
                column: "igv_calculado",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "02",
                column: "igv_calculado",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "03",
                column: "igv_calculado",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "05",
                column: "igv_calculado",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "07",
                column: "igv_calculado",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "08",
                column: "igv_calculado",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "10",
                column: "igv_calculado",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "12",
                column: "igv_calculado",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "13",
                column: "igv_calculado",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "14",
                column: "igv_calculado",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "91",
                column: "igv_calculado",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "97",
                column: "igv_calculado",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "ER",
                columns: new[] { "igv_calculado", "nombre_afecto" },
                values: new object[] { true, "Anticipo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "igv_calculado",
                table: "tipo_documento");

            migrationBuilder.AddColumn<string>(
                name: "nombre_inafecto",
                table: "tipo_documento",
                type: "varchar(400)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "anticipo",
                table: "documento",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "01",
                column: "nombre_inafecto",
                value: "Monto Inafecto");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "02",
                column: "nombre_inafecto",
                value: "Total Honorarios");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "03",
                column: "nombre_inafecto",
                value: "Valor Venta");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "05",
                column: "nombre_inafecto",
                value: "Monto Inafecto");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "07",
                column: "nombre_inafecto",
                value: "Monto Inafecto");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "08",
                column: "nombre_inafecto",
                value: "Monto Inafecto");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "10",
                column: "nombre_inafecto",
                value: "Valor Venta");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "12",
                column: "nombre_inafecto",
                value: "Monto Inafecto");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "13",
                column: "nombre_inafecto",
                value: "Monto Inafecto");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "14",
                column: "nombre_inafecto",
                value: "Monto Inafecto");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "50",
                column: "nombre_inafecto",
                value: "Monto Inafecto");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "91",
                column: "nombre_inafecto",
                value: "Monto Inafecto");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "97",
                column: "nombre_inafecto",
                value: "Monto Inafecto");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "ER",
                columns: new[] { "nombre_afecto", "nombre_inafecto" },
                values: new object[] { "Valor Venta", "Monto Inafecto" });
        }
    }
}
