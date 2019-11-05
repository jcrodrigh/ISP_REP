using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class NewMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "documento",
                newName: "id_interno");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "02",
                columns: new[] { "iva", "nombre_inafecto" },
                values: new object[] { 0.08m, "Total Honorarios" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_interno",
                table: "documento",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "02",
                columns: new[] { "iva", "nombre_inafecto" },
                values: new object[] { 0.8m, "Monto sin retención" });
        }
    }
}
