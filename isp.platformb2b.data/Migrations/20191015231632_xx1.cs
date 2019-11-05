using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace isp.platformb2b.data.Migrations
{
    public partial class xx1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id_interno",
                table: "documento",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "05",
                column: "lista_serie",
                value: true);

            migrationBuilder.InsertData(
                table: "tipo_documento_serie",
                columns: new[] { "id_tipo_documento", "id_tipo_documento_serie", "descripcion" },
                values: new object[,]
                {
                    { "05", "1", "Boleto Manual" },
                    { "05", "2", "Boleto Automático" },
                    { "05", "3", "Boleto Electrónico" },
                    { "05", "4", "Otros" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tipo_documento_serie",
                keyColumns: new[] { "id_tipo_documento", "id_tipo_documento_serie" },
                keyValues: new object[] { "05", "1" });

            migrationBuilder.DeleteData(
                table: "tipo_documento_serie",
                keyColumns: new[] { "id_tipo_documento", "id_tipo_documento_serie" },
                keyValues: new object[] { "05", "2" });

            migrationBuilder.DeleteData(
                table: "tipo_documento_serie",
                keyColumns: new[] { "id_tipo_documento", "id_tipo_documento_serie" },
                keyValues: new object[] { "05", "3" });

            migrationBuilder.DeleteData(
                table: "tipo_documento_serie",
                keyColumns: new[] { "id_tipo_documento", "id_tipo_documento_serie" },
                keyValues: new object[] { "05", "4" });

            migrationBuilder.AlterColumn<int>(
                name: "id_interno",
                table: "documento",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "05",
                column: "lista_serie",
                value: false);
        }
    }
}
