using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "00");

            migrationBuilder.DeleteData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "AS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tipo_documento",
                columns: new[] { "id_tipo_documento", "formato_correlativo", "formato_ruc_proveedor", "formato_serie_electronica", "formato_serie_fisica", "iva", "nombre_afecto", "nombre_documento", "nombre_inafecto", "nombre_iva" },
                values: new object[,]
                {
                    { "00", "^([1-9][0-9]{0,19})$", "^20[0-9]{9}$", "^([A-Z0-9]{0,20}|)$", "^([A-Z0-9]{0,20}|)$", 0m, "Monto Afecto", "Otros.", "Monto Inafecto", "Monto IGV" },
                    { "AS", "^([1-9][0-9]{0,19})$", "^20[0-9]{9}$", "^([A-Z0-9]{0,20}|)$", "^([A-Z0-9]{0,20}|)$", 0m, "Monto Afecto", "Apunte contable cuenta mayor.", "Monto Inafecto", "Monto IGV" }
                });
        }
    }
}
