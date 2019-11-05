using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                column: "formato_correlativo",
                value: "^([0-9]{0,6}[1-9])$");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "01",
                columns: new[] { "formato_correlativo", "formato_serie_fisica" },
                values: new object[] { "^([1-9][0-9]{0,7})$", "^([0-9]{4})$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "02",
                column: "formato_correlativo",
                value: "^([1-9][0-9]{0,6})$");
        }
    }
}
