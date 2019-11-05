using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class Migrationx1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tipo_detracciones",
                keyColumn: "id_tipo_detracciones",
                keyValue: "NO",
                column: "descripcion_detracciones",
                value: "NO APLICA");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "03",
                column: "iva",
                value: 0.18m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "05",
                column: "iva",
                value: 0.18m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "10",
                column: "iva",
                value: 0.18m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "12",
                column: "iva",
                value: 0.18m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "13",
                column: "iva",
                value: 0.18m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "14",
                column: "iva",
                value: 0.18m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "50",
                column: "iva",
                value: 0.18m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "91",
                column: "iva",
                value: 0.18m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "97",
                column: "iva",
                value: 0.18m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "ER",
                column: "iva",
                value: 0.18m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tipo_detracciones",
                keyColumn: "id_tipo_detracciones",
                keyValue: "NO",
                column: "descripcion_detracciones",
                value: "No Aplica");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "03",
                column: "iva",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "05",
                column: "iva",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "10",
                column: "iva",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "12",
                column: "iva",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "13",
                column: "iva",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "14",
                column: "iva",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "50",
                column: "iva",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "91",
                column: "iva",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "97",
                column: "iva",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "ER",
                column: "iva",
                value: 0m);
        }
    }
}
