using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class new3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "02",
                columns: new[] { "formato_correlativo", "formato_serie_fisica", "mascara_correlativo", "mascara_serie_fisica" },
                values: new object[] { "^([0-9]{6}[1-9])$", "^([0-9]{3}[1-9])$", (short)4, (short)7 });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "03",
                columns: new[] { "formato_correlativo", "formato_serie_fisica", "mascara_correlativo", "mascara_serie_fisica" },
                values: new object[] { "^([0-9]{7}[1-9])$", "^([0-9]{3}[1-9])$", (short)8, (short)4 });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "07",
                columns: new[] { "formato_correlativo", "formato_serie_fisica", "mascara_correlativo", "mascara_serie_fisica" },
                values: new object[] { "^([0-9]{7}[1-9])$", "^([0-9]{3}[1-9])$", (short)8, (short)4 });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "08",
                columns: new[] { "formato_correlativo", "formato_serie_fisica", "mascara_correlativo", "mascara_serie_fisica" },
                values: new object[] { "^([0-9]{7}[1-9])$", "^([0-9]{3}[1-9])$", (short)8, (short)4 });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "50",
                columns: new[] { "formato_correlativo", "formato_serie_fisica", "mascara_correlativo", "mascara_serie_fisica" },
                values: new object[] { "^([0-9]{7}[1-9])$", "^([0-9]{4})$", (short)8, (short)4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "02",
                columns: new[] { "formato_correlativo", "formato_serie_fisica", "mascara_correlativo", "mascara_serie_fisica" },
                values: new object[] { "^([0-9]{0,6}[1-9])$", "^([1-9][0-9]{0,3})$", (short)0, (short)0 });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "03",
                columns: new[] { "formato_correlativo", "formato_serie_fisica", "mascara_correlativo", "mascara_serie_fisica" },
                values: new object[] { "^([1-9][0-9]{0,7})$", "^([1-9][0-9]{0,3})$", (short)0, (short)0 });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "07",
                columns: new[] { "formato_correlativo", "formato_serie_fisica", "mascara_correlativo", "mascara_serie_fisica" },
                values: new object[] { "^([1-9][0-9]{0,7})$", "^([1-9][0-9]{0,3})$", (short)0, (short)0 });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "08",
                columns: new[] { "formato_correlativo", "formato_serie_fisica", "mascara_correlativo", "mascara_serie_fisica" },
                values: new object[] { "^([1-9][0-9]{0,7})$", "^([1-9][0-9]{0,3})$", (short)0, (short)0 });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "50",
                columns: new[] { "formato_correlativo", "formato_serie_fisica", "mascara_correlativo", "mascara_serie_fisica" },
                values: new object[] { "^([1-9][0-9]{0,7})$", "^([0-9]{0,4})$", (short)0, (short)0 });
        }
    }
}
