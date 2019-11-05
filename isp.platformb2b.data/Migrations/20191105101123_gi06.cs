using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class gi06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_persona",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "per_emp",
                table: "usuarios");

            migrationBuilder.RenameColumn(
                name: "nombrex",
                table: "persona",
                newName: "nombres");

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
                table: "tipo_empresa_erp",
                keyColumn: "id_tipo_empresa_erp",
                keyValue: (short)2,
                column: "nombre_tipo_empresa_erp",
                value: "Oracle");

            migrationBuilder.UpdateData(
                table: "tipo_empresa_erp",
                keyColumn: "id_tipo_empresa_erp",
                keyValue: (short)3,
                column: "nombre_tipo_empresa_erp",
                value: "JDA");

            migrationBuilder.InsertData(
                table: "tipo_empresa_erp",
                columns: new[] { "id_tipo_empresa_erp", "nombre_tipo_empresa_erp" },
                values: new object[] { (short)4, "Inhouse" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tipo_empresa_erp",
                keyColumn: "id_tipo_empresa_erp",
                keyValue: (short)4);

            migrationBuilder.RenameColumn(
                name: "nombres",
                table: "persona",
                newName: "nombrex");

            migrationBuilder.AddColumn<int>(
                name: "id_persona",
                table: "usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "per_emp",
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
                table: "tipo_empresa_erp",
                keyColumn: "id_tipo_empresa_erp",
                keyValue: (short)2,
                column: "nombre_tipo_empresa_erp",
                value: "MICROSOFT DYNAMICS");

            migrationBuilder.UpdateData(
                table: "tipo_empresa_erp",
                keyColumn: "id_tipo_empresa_erp",
                keyValue: (short)3,
                column: "nombre_tipo_empresa_erp",
                value: "SALESFORCE");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "cesar",
                column: "per_emp",
                value: true);

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "cromani",
                column: "per_emp",
                value: true);

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "jc_temporal",
                column: "per_emp",
                value: true);

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "rcaceres",
                column: "per_emp",
                value: true);

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "rsanchez",
                column: "per_emp",
                value: true);
        }
    }
}
