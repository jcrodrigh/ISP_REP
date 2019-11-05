using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class jj5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_persona_dni_persona",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_dni_persona",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "dni_persona",
                table: "usuarios");

            migrationBuilder.AddColumn<string>(
                name: "nombre_completo",
                table: "usuarios",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "10095903768" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "10467765219" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2764));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20000000009" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2806));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20100070970" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20100654025" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2857));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20111111119" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2812));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20222222229" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2828));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20333333339" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2831));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20444444449" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2837));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20546183107" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2855));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20555555559" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2839));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20600044495" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20666666669" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2841));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20777777779" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2844));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20999999999" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2847));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "10467765219" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 293, DateTimeKind.Local).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20111111119" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2813));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20222222229" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2830));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20333333339" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2833));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20444444449" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2838));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20600044495" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2861));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20666666669" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2843));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20888888889" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2845));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20999999999" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 17, 43, 29, 294, DateTimeKind.Local).AddTicks(2849));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "cesar",
                column: "nombre_completo",
                value: "--");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "cromani",
                column: "nombre_completo",
                value: "--");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "jc_temporal",
                column: "nombre_completo",
                value: "--");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "rcaceres",
                column: "nombre_completo",
                value: "--");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "rsanchez",
                column: "nombre_completo",
                value: "--");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nombre_completo",
                table: "usuarios");

            migrationBuilder.AddColumn<string>(
                name: "dni_persona",
                table: "usuarios",
                type: "char(8)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "10095903768" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4792));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "10467765219" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4738));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20000000009" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4765));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20100070970" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4796));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20100654025" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20111111119" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4767));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20222222229" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20333333339" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4776));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20444444449" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20546183107" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4793));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20555555559" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4782));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20600044495" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4791));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20666666669" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4783));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20777777779" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4786));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20999999999" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "10467765219" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(2416));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20111111119" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4768));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20222222229" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4775));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20333333339" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4777));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20444444449" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4781));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20600044495" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4797));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20666666669" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4784));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20888888889" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4786));

            migrationBuilder.UpdateData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20999999999" },
                column: "fecha",
                value: new DateTime(2019, 11, 5, 5, 11, 22, 20, DateTimeKind.Local).AddTicks(4789));

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "cesar",
                column: "dni_persona",
                value: "46776521");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "cromani",
                column: "dni_persona",
                value: "09580232");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "jc_temporal",
                column: "dni_persona",
                value: "10735744");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "rcaceres",
                column: "dni_persona",
                value: "09302752");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "rsanchez",
                column: "dni_persona",
                value: "41912505");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_dni_persona",
                table: "usuarios",
                column: "dni_persona");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_persona_dni_persona",
                table: "usuarios",
                column: "dni_persona",
                principalTable: "persona",
                principalColumn: "dni_persona",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
