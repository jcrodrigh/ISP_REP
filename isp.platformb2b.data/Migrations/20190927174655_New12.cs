using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class New12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "05",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica", "mascara_correlativo" },
                values: new object[] { "(?!00000000000)^[0-9]{11}$", "^[1-4]$", "^[1-4]$", (short)11 });

            migrationBuilder.UpdateData(
                table: "tipo_documento_estado",
                keyColumn: "id_tipo_documento_estado",
                keyValue: (short)1,
                column: "estado",
                value: "Verificado");

            migrationBuilder.UpdateData(
                table: "tipo_documento_estado",
                keyColumn: "id_tipo_documento_estado",
                keyValue: (short)2,
                column: "estado",
                value: "Transferido");

            migrationBuilder.UpdateData(
                table: "tipo_documento_estado",
                keyColumn: "id_tipo_documento_estado",
                keyValue: (short)3,
                column: "estado",
                value: "Contabilizado");

            migrationBuilder.UpdateData(
                table: "tipo_documento_estado",
                keyColumn: "id_tipo_documento_estado",
                keyValue: (short)4,
                column: "estado",
                value: "Rechazado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "05",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica", "mascara_correlativo" },
                values: new object[] { "(?!0000000000)^[0-9]{10}$", "^[1-5]$", "^[1-5]$", (short)10 });

            migrationBuilder.UpdateData(
                table: "tipo_documento_estado",
                keyColumn: "id_tipo_documento_estado",
                keyValue: (short)1,
                column: "estado",
                value: "Por Comprobar");

            migrationBuilder.UpdateData(
                table: "tipo_documento_estado",
                keyColumn: "id_tipo_documento_estado",
                keyValue: (short)2,
                column: "estado",
                value: "Aprobado");

            migrationBuilder.UpdateData(
                table: "tipo_documento_estado",
                keyColumn: "id_tipo_documento_estado",
                keyValue: (short)3,
                column: "estado",
                value: "Observado");

            migrationBuilder.UpdateData(
                table: "tipo_documento_estado",
                keyColumn: "id_tipo_documento_estado",
                keyValue: (short)4,
                column: "estado",
                value: "Anulado");
        }
    }
}
