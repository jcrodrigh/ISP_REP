using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class New16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ordenes_compra",
                columns: new[] { "ruc_empresa_cliente", "id_orden_compra", "activa", "competado", "id_tipo_moneda", "monto_acumulado", "monto_cliente", "monto_orden_compra", "ruc_empresa_proveedor" },
                values: new object[,]
                {
                    { "20777777779", "NEW-00141", true, false, "PEN", 0m, 0m, 93m, "20111111119" },
                    { "20000000009", "NEW-00156", true, false, "EUR", 0m, 0m, 324m, "20111111119" },
                    { "20000000009", "NEW-00155", true, false, "PEN", 0m, 0m, 32m, "20111111119" },
                    { "20000000009", "NEW-00154", true, false, "PEN", 0m, 0m, 270m, "20111111119" },
                    { "20000000009", "NEW-00153", true, false, "USD", 0m, 0m, 150m, "20111111119" },
                    { "20000000009", "NEW-00152", true, false, "PEN", 0m, 0m, 127m, "20111111119" },
                    { "20000000009", "NEW-00151", true, false, "PEN", 0m, 0m, 115m, "20111111119" },
                    { "20000000009", "NEW-00150", true, false, "PEN", 0m, 0m, 695m, "20111111119" },
                    { "20777777779", "NEW-00149", true, false, "EUR", 0m, 0m, 175m, "20111111119" },
                    { "20777777779", "NEW-00148", true, false, "PEN", 0m, 0m, 179m, "20111111119" },
                    { "20777777779", "NEW-00147", true, false, "PEN", 0m, 0m, 611m, "20111111119" },
                    { "20777777779", "NEW-00146", true, false, "USD", 0m, 0m, 689m, "20111111119" },
                    { "20777777779", "NEW-00145", true, false, "PEN", 0m, 0m, 1000m, "20111111119" },
                    { "20777777779", "NEW-00144", true, false, "PEN", 0m, 0m, 977m, "20111111119" },
                    { "20777777779", "NEW-00143", true, false, "USD", 0m, 0m, 44m, "20111111119" },
                    { "20777777779", "NEW-00142", true, false, "PEN", 0m, 0m, 780m, "20111111119" },
                    { "20000000009", "NEW-00157", true, false, "PEN", 0m, 0m, 902m, "20111111119" },
                    { "20000000009", "NEW-00158", true, false, "USD", 0m, 0m, 701m, "20111111119" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20000000009", "NEW-00150" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20000000009", "NEW-00151" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20000000009", "NEW-00152" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20000000009", "NEW-00153" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20000000009", "NEW-00154" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20000000009", "NEW-00155" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20000000009", "NEW-00156" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20000000009", "NEW-00157" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20000000009", "NEW-00158" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20777777779", "NEW-00141" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20777777779", "NEW-00142" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20777777779", "NEW-00143" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20777777779", "NEW-00144" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20777777779", "NEW-00145" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20777777779", "NEW-00146" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20777777779", "NEW-00147" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20777777779", "NEW-00148" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20777777779", "NEW-00149" });
        }
    }
}
