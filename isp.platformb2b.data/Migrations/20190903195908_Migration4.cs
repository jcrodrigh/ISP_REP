using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tipo_detracciones",
                columns: new[] { "id_tipo_detracciones", "descripcion_detracciones", "valor_detracciones" },
                values: new object[] { "NO", "No Aplica", 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tipo_detracciones",
                keyColumn: "id_tipo_detracciones",
                keyValue: "NO");
        }
    }
}
