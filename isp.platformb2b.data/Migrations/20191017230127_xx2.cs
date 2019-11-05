using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class xx2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "correos",
                table: "documento_errores",
                type: "varchar(1000)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "empresas",
                columns: new[] { "ruc_empresa", "acreedor", "activo", "con_pedido", "condicion_pago", "correo", "domicilio_fiscal", "fecha_registro_proveedor", "habido", "id_tipo_empresa_erp", "logo", "razon_social", "sin_pedido", "telefono", "tipo_tolerancia", "tolerancia" },
                values: new object[] { "20100070970", null, true, true, (short)0, new[] { "algun_correo1@gmail.com", "algun_correo2@gmail.com", "algun_correo3@gmail.com", "algun_correo4@gmail.com" }, "DIRECCIÓN DEL CLIENTE: CAL.MORELLI 181 INT. P-2 LIMA- LIMA- SAN BORJA", null, true, (short)1, null, "SUPERMERCADOS PERUANOS S.A. 'O' S.P.S.A.", true, new[] { "96875999", "87548965" }, (short)1, 0m });

            migrationBuilder.InsertData(
                table: "ti_roles_empresas",
                columns: new[] { "ruc_empresa", "id_tipo_roles", "fecha" },
                values: new object[] { "20600044495", (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "username", "correo", "id_persona", "password", "per_emp", "ruc_empresa", "telefono" },
                values: new object[] { "rsanchez", new[] { "administracion@ispconsulting.pe" }, 0, "123456", true, "20600044495", new[] { "6969696", "96969696969" } });

            migrationBuilder.InsertData(
                table: "ordenes_compra",
                columns: new[] { "ruc_empresa_cliente", "id_orden_compra", "activa", "competado", "id_tipo_moneda", "monto_acumulado", "monto_cliente", "monto_orden_compra", "ruc_empresa_proveedor" },
                values: new object[,]
                {
                    { "20100070970", "4502879117", true, false, "PEN", 0m, 0m, 2592.15m, "20600044495" },
                    { "20100070970", "4502921197", true, false, "PEN", 0m, 0m, 59683.78m, "20600044495" },
                    { "20100070970", "8100563745", true, false, "PEN", 0m, 0m, 63982.6m, "20600044495" },
                    { "20100070970", "8100564029", true, false, "PEN", 0m, 0m, 7552m, "20600044495" }
                });

            migrationBuilder.InsertData(
                table: "ti_empresa_empresa",
                columns: new[] { "ruc_empresa_cliente", "ruc_empresa_proveedor", "activo" },
                values: new object[] { "20100070970", "20600044495", true });

            migrationBuilder.InsertData(
                table: "ti_roles_empresas",
                columns: new[] { "ruc_empresa", "id_tipo_roles", "fecha" },
                values: new object[] { "20100070970", (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ti_usuario_roles",
                columns: new[] { "username", "id_tipo_roles" },
                values: new object[,]
                {
                    { "rsanchez", (short)1 },
                    { "rsanchez", (short)2 }
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "username", "correo", "id_persona", "password", "per_emp", "ruc_empresa", "telefono" },
                values: new object[] { "supermercados", new[] { "superman@supermercados.com" }, 0, "123456", true, "20100070970", new[] { "6969696", "96969696969" } });

            migrationBuilder.InsertData(
                table: "ti_usuario_roles",
                columns: new[] { "username", "id_tipo_roles" },
                values: new object[,]
                {
                    { "supermercados", (short)1 },
                    { "supermercados", (short)2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20100070970", "4502879117" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20100070970", "4502921197" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20100070970", "8100563745" });

            migrationBuilder.DeleteData(
                table: "ordenes_compra",
                keyColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                keyValues: new object[] { "20100070970", "8100564029" });

            migrationBuilder.DeleteData(
                table: "ti_empresa_empresa",
                keyColumns: new[] { "ruc_empresa_cliente", "ruc_empresa_proveedor" },
                keyValues: new object[] { "20100070970", "20600044495" });

            migrationBuilder.DeleteData(
                table: "ti_roles_empresas",
                keyColumns: new[] { "ruc_empresa", "id_tipo_roles" },
                keyValues: new object[] { "20100070970", (short)1 });

            migrationBuilder.DeleteData(
                table: "ti_roles_empresas",
                keyColumns: new[] { "ruc_empresa", "id_tipo_roles" },
                keyValues: new object[] { "20600044495", (short)2 });

            migrationBuilder.DeleteData(
                table: "ti_usuario_roles",
                keyColumns: new[] { "username", "id_tipo_roles" },
                keyValues: new object[] { "rsanchez", (short)1 });

            migrationBuilder.DeleteData(
                table: "ti_usuario_roles",
                keyColumns: new[] { "username", "id_tipo_roles" },
                keyValues: new object[] { "rsanchez", (short)2 });

            migrationBuilder.DeleteData(
                table: "ti_usuario_roles",
                keyColumns: new[] { "username", "id_tipo_roles" },
                keyValues: new object[] { "supermercados", (short)1 });

            migrationBuilder.DeleteData(
                table: "ti_usuario_roles",
                keyColumns: new[] { "username", "id_tipo_roles" },
                keyValues: new object[] { "supermercados", (short)2 });

            migrationBuilder.DeleteData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "rsanchez");

            migrationBuilder.DeleteData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "supermercados");

            migrationBuilder.DeleteData(
                table: "empresas",
                keyColumn: "ruc_empresa",
                keyValue: "20100070970");

            migrationBuilder.DropColumn(
                name: "correos",
                table: "documento_errores");
        }
    }
}
