using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class gi04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "empresas",
                keyColumn: "ruc_empresa",
                keyValue: "20xxxxxxx9");

            migrationBuilder.DropColumn(
                name: "nombres",
                table: "persona");

            migrationBuilder.DropColumn(
                name: "correos",
                table: "documento_errores");

            migrationBuilder.AddColumn<string[]>(
                name: "nombrex",
                table: "persona",
                type: "varchar(50)[]",
                nullable: false,
                defaultValue: new string[] { "" });

            migrationBuilder.InsertData(
                table: "empresas",
                columns: new[] { "ruc_empresa", "acreedor", "activo", "con_pedido", "condicion_pago", "correo", "domicilio_fiscal", "fecha_registro_proveedor", "habido", "id_tipo_empresa_erp", "logo", "razon_social", "sin_pedido", "telefono", "tipo_tolerancia", "tolerancia" },
                values: new object[] { "20605411003", null, true, true, (short)0, new[] { "algun_correo1@gmail.com", "algun_correo2@gmail.com", "algun_correo3@gmail.com", "algun_correo4@gmail.com" }, "--", null, true, (short)3, null, "Romani & Caceres Business Solutions SAC", false, new[] { "96875999", "87548965" }, (short)1, 0m });

            migrationBuilder.UpdateData(
                table: "persona",
                keyColumn: "dni_persona",
                keyValue: "41912505",
                columns: new[] { "ap_materno", "nombrex" },
                values: new object[] { "Egusquiza", new[] { "Rosalyn" } });

            migrationBuilder.UpdateData(
                table: "persona",
                keyColumn: "dni_persona",
                keyValue: "46776521",
                column: "nombrex",
                value: new[] { "Cesar", "Gianfranco" });

            migrationBuilder.InsertData(
                table: "persona",
                columns: new[] { "dni_persona", "ap_materno", "ap_paterno", "nombrex" },
                values: new object[,]
                {
                    { "09302752", "Cardenas", "Caceres", new[] { "Roxana", "Cecilia" } },
                    { "09580232", "Huyhua", "Romaní", new[] { "Carmela" } }
                });

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

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "username", "correo", "dni_persona", "id_persona", "password", "per_emp", "ruc_empresa", "telefono" },
                values: new object[,]
                {
                    { "rcaceres", new[] { "" }, "09302752", 0, "123456", true, "20605411003", new[] { "6969696", "96969696969" } },
                    { "cromani", new[] { "" }, "09580232", 0, "123456", true, "20605411003", new[] { "6969696", "96969696969" } }
                });

            migrationBuilder.InsertData(
                table: "ti_usuario_roles",
                columns: new[] { "username", "id_tipo_roles" },
                values: new object[,]
                {
                    { "rcaceres", (short)31 },
                    { "cromani", (short)31 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ti_usuario_roles",
                keyColumns: new[] { "username", "id_tipo_roles" },
                keyValues: new object[] { "cromani", (short)31 });

            migrationBuilder.DeleteData(
                table: "ti_usuario_roles",
                keyColumns: new[] { "username", "id_tipo_roles" },
                keyValues: new object[] { "rcaceres", (short)31 });

            migrationBuilder.DeleteData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "cromani");

            migrationBuilder.DeleteData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "rcaceres");

            migrationBuilder.DeleteData(
                table: "empresas",
                keyColumn: "ruc_empresa",
                keyValue: "20605411003");

            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "dni_persona",
                keyValue: "09302752");

            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "dni_persona",
                keyValue: "09580232");

            migrationBuilder.DropColumn(
                name: "nombrex",
                table: "persona");

            migrationBuilder.AddColumn<string>(
                name: "nombres",
                table: "persona",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "correos",
                table: "documento_errores",
                type: "varchar(1000)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "empresas",
                columns: new[] { "ruc_empresa", "acreedor", "activo", "con_pedido", "condicion_pago", "correo", "domicilio_fiscal", "fecha_registro_proveedor", "habido", "id_tipo_empresa_erp", "logo", "razon_social", "sin_pedido", "telefono", "tipo_tolerancia", "tolerancia" },
                values: new object[] { "20xxxxxxx9", null, true, true, (short)0, new[] { "algun_correo1@gmail.com", "algun_correo2@gmail.com", "algun_correo3@gmail.com", "algun_correo4@gmail.com" }, "Sentado en su tejado ron ron", null, true, null, null, "El gato ron ron", false, new[] { "96875999", "87548965" }, (short)1, 0m });

            migrationBuilder.UpdateData(
                table: "persona",
                keyColumn: "dni_persona",
                keyValue: "41912505",
                columns: new[] { "ap_materno", "nombres" },
                values: new object[] { "--", "Rosalym" });

            migrationBuilder.UpdateData(
                table: "persona",
                keyColumn: "dni_persona",
                keyValue: "46776521",
                column: "nombres",
                value: "Cesar Gianfranco");

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
        }
    }
}
