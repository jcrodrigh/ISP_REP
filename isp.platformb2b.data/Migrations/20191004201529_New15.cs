using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class New15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ordenes_compra",
                columns: new[] { "ruc_empresa_cliente", "id_orden_compra", "activa", "competado", "id_tipo_moneda", "monto_acumulado", "monto_cliente", "monto_orden_compra", "ruc_empresa_proveedor" },
                values: new object[,]
                {
                    { "20777777779", "NEW-00042", true, false, "USD", 0m, 0m, 503m, "20111111119" },
                    { "20777777779", "NEW-00043", true, false, "PEN", 0m, 0m, 984m, "20111111119" },
                    { "20777777779", "NEW-00044", true, false, "EUR", 0m, 0m, 447m, "20111111119" },
                    { "20777777779", "NEW-00045", true, false, "PEN", 0m, 0m, 779m, "20111111119" },
                    { "20777777779", "NEW-00046", true, false, "EUR", 0m, 0m, 309m, "20111111119" },
                    { "20777777779", "NEW-00047", true, false, "PEN", 0m, 0m, 79m, "20111111119" },
                    { "20777777779", "NEW-00048", true, false, "USD", 0m, 0m, 880m, "20111111119" },
                    { "20777777779", "NEW-00049", true, false, "PEN", 0m, 0m, 579m, "20111111119" },
                    { "20000000009", "NEW-00108", true, false, "PEN", 0m, 0m, 44m, "20111111119" },
                    { "20000000009", "NEW-00109", true, false, "EUR", 0m, 0m, 814m, "20111111119" },
                    { "20000000009", "NEW-00110", true, false, "PEN", 0m, 0m, 470m, "20111111119" },
                    { "20000000009", "NEW-00111", true, false, "USD", 0m, 0m, 546m, "20111111119" },
                    { "20000000009", "NEW-00112", true, false, "PEN", 0m, 0m, 377m, "20111111119" },
                    { "20000000009", "NEW-00113", true, false, "USD", 0m, 0m, 147m, "20111111119" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20000000009", "NEW-00108" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20000000009", "NEW-00109" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20000000009", "NEW-00110" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20000000009", "NEW-00111" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20000000009", "NEW-00112" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20000000009", "NEW-00113" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20777777779", "NEW-00042" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20777777779", "NEW-00043" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20777777779", "NEW-00044" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20777777779", "NEW-00045" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20777777779", "NEW-00046" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20777777779", "NEW-00047" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20777777779", "NEW-00048" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20777777779", "NEW-00049" });
        }
    }
}
