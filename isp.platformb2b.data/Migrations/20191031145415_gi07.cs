using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class gi07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "usuarios",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "10095903768" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9055));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "10467765219" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20000000009" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9028));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20100070970" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9059));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20100654025" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20111111119" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9030));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20222222229" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9036));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20333333339" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9039));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20444444449" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20546183107" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20555555559" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9045));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20600044495" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9054));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20666666669" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9046));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20777777779" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9048));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20999999999" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "10467765219" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(6727));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20111111119" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9031));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20222222229" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9037));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20333333339" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9040));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20444444449" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9044));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20600044495" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20666666669" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9047));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20888888889" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9050));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20999999999" },
                column: "fecha",
                value: new DateTime(2019, 10, 31, 9, 54, 14, 512, DateTimeKind.Local).AddTicks(9053));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "cesar",
                column: "activo",
                value: true);

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "cromani",
                column: "activo",
                value: true);

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "jc_temporal",
                column: "activo",
                value: true);

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "rcaceres",
                column: "activo",
                value: true);

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "rsanchez",
                column: "activo",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "activo",
                table: "usuarios");

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
        }
    }
}
