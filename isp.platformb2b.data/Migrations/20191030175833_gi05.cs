using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class gi05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "empresas",
                keyColumn: "ruc_empresa",
                keyValue: "20546183107",
                column: "con_pedido",
                value: true);

            migrationBuilder.InsertData(
                table: "persona",
                columns: new[] { "dni_persona", "ap_materno", "ap_paterno", "nombrex" },
                values: new object[] { "10735744", "Hernandez", "Rodriguez", new[] { "José", "Carlos" } });

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "10095903768" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "10467765219" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1743));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20000000009" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1757));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20100070970" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20100654025" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20111111119" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1758));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20222222229" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1764));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20333333339" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1766));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20444444449" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1769));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20546183107" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1781));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20555555559" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20600044495" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1779));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20666666669" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1773));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20777777779" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1775));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20999999999" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1777));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "10467765219" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 112, DateTimeKind.Local).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20111111119" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1760));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20222222229" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1765));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20333333339" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1767));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20444444449" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20600044495" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1784));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20666666669" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20888888889" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1776));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20999999999" },
                column: "fecha",
                value: new DateTime(2019, 10, 30, 12, 58, 32, 113, DateTimeKind.Local).AddTicks(1778));

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "username", "correo", "dni_persona", "id_persona", "password", "per_emp", "ruc_empresa", "telefono" },
                values: new object[] { "jc_temporal", new[] { "" }, "10735744", 0, "123456", true, "20500123797", new[] { "6969696", "96969696969" } });

            migrationBuilder.InsertData(
                table: "ti_usuario_roles",
                columns: new[] { "username", "id_tipo_roles" },
                values: new object[] { "jc_temporal", (short)21 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ti_usuario_roles",
                keyColumns: new[] { "username", "id_tipo_roles" },
                keyValues: new object[] { "jc_temporal", (short)21 });

            migrationBuilder.DeleteData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "jc_temporal");

            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "dni_persona",
                keyValue: "10735744");

            migrationBuilder.UpdateData(
                table: "empresas",
                keyColumn: "ruc_empresa",
                keyValue: "20546183107",
                column: "con_pedido",
                value: false);

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "10095903768" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9403));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "10467765219" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9339));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20000000009" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20100070970" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20100654025" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20111111119" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9356));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20222222229" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9361));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20333333339" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9363));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20444444449" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20546183107" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9405));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20555555559" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9392));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20600044495" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9402));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20666666669" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9394));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20777777779" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9395));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20999999999" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9398));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "10467765219" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(7422));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20111111119" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9357));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20222222229" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9362));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20333333339" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9364));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20444444449" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9391));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20600044495" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9408));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20666666669" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9394));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20888888889" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9396));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20999999999" },
                column: "fecha",
                value: new DateTime(2019, 10, 28, 12, 16, 26, 314, DateTimeKind.Local).AddTicks(9401));
        }
    }
}
