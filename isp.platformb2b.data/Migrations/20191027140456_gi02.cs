using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class gi02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ti_roles_menu",
                columns: new[] { "id_tipo_menu", "id_tipo_roles" },
                values: new object[,]
                {
                    { (short)1, (short)11 },
                    { (short)53, (short)31 },
                    { (short)52, (short)31 },
                    { (short)5, (short)31 },
                    { (short)41, (short)31 },
                    { (short)4, (short)31 },
                    { (short)32, (short)31 },
                    { (short)31, (short)31 },
                    { (short)3, (short)31 },
                    { (short)23, (short)31 },
                    { (short)22, (short)31 },
                    { (short)21, (short)31 },
                    { (short)2, (short)31 },
                    { (short)1, (short)31 },
                    { (short)51, (short)31 },
                    { (short)22, (short)21 },
                    { (short)23, (short)21 },
                    { (short)2, (short)11 },
                    { (short)22, (short)11 },
                    { (short)23, (short)11 },
                    { (short)3, (short)11 },
                    { (short)31, (short)11 },
                    { (short)21, (short)11 },
                    { (short)4, (short)11 },
                    { (short)41, (short)11 },
                    { (short)1, (short)21 },
                    { (short)2, (short)21 },
                    { (short)32, (short)11 },
                    { (short)21, (short)21 }
                });

            migrationBuilder.InsertData(
                table: "ti_tipo_empresa",
                columns: new[] { "id_tipo_empresa", "ruc_empresa", "fecha" },
                values: new object[,]
                {
                    { (short)2, "20666666669", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5209) },
                    { (short)1, "20777777779", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5210) },
                    { (short)2, "20888888889", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5211) },
                    { (short)1, "20999999999", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5212) },
                    { (short)1, "20600044495", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5214) },
                    { (short)1, "10095903768", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5215) },
                    { (short)1, "20546183107", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5217) },
                    { (short)1, "20666666669", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5209) },
                    { (short)1, "20100654025", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5217) },
                    { (short)2, "20999999999", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5213) },
                    { (short)1, "20555555559", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5194) },
                    { (short)2, "20111111119", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5183) },
                    { (short)1, "20444444449", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5191) },
                    { (short)2, "20333333339", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5189) },
                    { (short)1, "20333333339", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5188) },
                    { (short)2, "20222222229", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5188) },
                    { (short)1, "20222222229", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5187) },
                    { (short)1, "20111111119", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5182) },
                    { (short)1, "20000000009", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5180) },
                    { (short)1, "10467765219", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5166) },
                    { (short)2, "10467765219", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(3650) },
                    { (short)1, "20100070970", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5218) },
                    { (short)2, "20444444449", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5193) },
                    { (short)2, "20600044495", new DateTime(2019, 10, 27, 9, 4, 55, 158, DateTimeKind.Local).AddTicks(5219) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)1, (short)11 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)1, (short)21 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)1, (short)31 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)2, (short)11 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)2, (short)21 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)2, (short)31 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)3, (short)11 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)3, (short)31 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)4, (short)11 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)4, (short)31 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)5, (short)31 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)21, (short)11 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)21, (short)21 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)21, (short)31 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)22, (short)11 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)22, (short)21 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)22, (short)31 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)23, (short)11 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)23, (short)21 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)23, (short)31 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)31, (short)11 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)31, (short)31 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)32, (short)11 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)32, (short)31 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)41, (short)11 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)41, (short)31 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)51, (short)31 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)52, (short)31 });

            migrationBuilder.DeleteData(
                table: "ti_roles_menu",
                keyColumns: new[] { "id_tipo_menu", "id_tipo_roles" },
                keyValues: new object[] { (short)53, (short)31 });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "10095903768" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "10467765219" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20000000009" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20100070970" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20100654025" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20111111119" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20222222229" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20333333339" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20444444449" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20546183107" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20555555559" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20600044495" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20666666669" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20777777779" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)1, "20999999999" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "10467765219" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20111111119" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20222222229" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20333333339" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20444444449" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20600044495" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20666666669" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20888888889" });

            migrationBuilder.DeleteData(
                table: "ti_tipo_empresa",
                keyColumns: new[] { "id_tipo_empresa", "ruc_empresa" },
                keyValues: new object[] { (short)2, "20999999999" });
        }
    }
}
