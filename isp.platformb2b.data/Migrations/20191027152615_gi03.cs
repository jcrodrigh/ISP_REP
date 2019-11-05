using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class gi03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ti_usuario_roles",
                keyColumns: new[] { "username", "id_tipo_roles" },
                keyValues: new object[] { "rsanchez", (short)11 });

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "10095903768" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1956));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "10467765219" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1884));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20000000009" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20100070970" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1959));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20100654025" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1958));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20111111119" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1899));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20222222229" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20333333339" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1905));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20444444449" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20546183107" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1958));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20555555559" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20600044495" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20666666669" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20777777779" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1951));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20999999999" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1953));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "10467765219" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(137));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20111111119" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20222222229" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1904));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20333333339" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1905));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20444444449" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1947));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20600044495" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20666666669" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20888888889" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20999999999" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 10, 26, 14, 656, DateTimeKind.Local).AddTicks(1955));

            migrationBuilder.InsertData(
                table: "ti_usuario_roles",
                columns: new[] { "username", "id_tipo_roles" },
                values: new object[] { "rsanchez", (short)21 });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "01",
                column: "formato_ruc_proveedor",
                value: "^(1|2)0[0-9]{9}$");

            migrationBuilder.InsertData(
                table: "tipo_menu",
                columns: new[] { "id_tipo_menu", "icon", "id_tipo_menu_padre", "name", "url" },
                values: new object[] { (short)6, "fa fa-angle-double-right", null, "Salir", "/user" });

            migrationBuilder.InsertData(
                table: "ti_roles_menu",
                columns: new[] { "id_tipo_menu", "id_tipo_roles" },
                values: new object[,]
                {
                    { (short)6, (short)11 },
                    { (short)6, (short)21 },
                    { (short)6, (short)31 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)6, (short)11 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)6, (short)21 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)6, (short)31 });

            migrationBuilder.DeleteData(
                table: "ti_usuario_roles",
                keyColumns: new[] { "username", "id_tipo_roles" },
                keyValues: new object[] { "rsanchez", (short)21 });

            migrationBuilder.DeleteData(
                table: "tipo_menu",
                keyColumn: "id_tipo_menu",
                keyValue: (short)6);

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "10095903768" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5215));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "10467765219" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5166));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20000000009" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20100070970" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5218));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20100654025" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5217));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20111111119" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5182));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20222222229" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5187));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20333333339" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5188));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20444444449" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5191));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20546183107" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5217));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20555555559" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5194));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20600044495" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5214));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20666666669" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5209));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20777777779" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20999999999" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5212));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "10467765219" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(3650));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20111111119" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5183));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20222222229" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5188));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20333333339" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5189));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20444444449" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5193));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20600044495" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20666666669" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5209));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20888888889" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5211));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20999999999" },
                column: "fecha",
                value: new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5213));

            migrationBuilder.InsertData(
                table: "ti_usuario_roles",
                columns: new[] { "username", "id_tipo_roles" },
                values: new object[] { "rsanchez", (short)11 });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "01",
                column: "formato_ruc_proveedor",
                value: "^20[0-9]{9}$");
        }
    }
}
