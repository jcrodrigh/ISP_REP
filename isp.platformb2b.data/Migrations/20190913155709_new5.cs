using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class new5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "empresas",
                columns: new[] { "ruc_empresa", "activo", "con_pedido", "correo", "domicilio_fiscal", "habido", "id_tipo_empresa_erp", "logo", "razon_social", "sin_pedido", "telefono", "tipo_tolerancia", "tolerancia" },
                values: new object[] { "20546183107", true, false, new[] { "algun_correo1@gmail.com", "algun_correo2@gmail.com", "algun_correo3@gmail.com", "algun_correo4@gmail.com" }, "C L. MAR ISC AL AGUSTIN GAMAR R A NR O . 326 LIMA - LIMA - SAN LUIS", true, (short)1, null, "CONSORCIO ALTA MODA S.R.L", true, new[] { "96875999", "87548965" }, (short)1, 0m });

            migrationBuilder.InsertData(
                table: "ti_roles_empresas",
                columns: new[] { "ruc_empresa", "id_tipo_roles" },
                values: new object[,]
                {
                    { "20600044495", (short)1 },
                    { "10095903768", (short)1 },
                    { "20100654025", (short)1 }
                });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "02",
                columns: new[] { "mascara_correlativo", "mascara_serie_fisica" },
                values: new object[] { (short)7, (short)4 });

            migrationBuilder.InsertData(
                table: "ti_roles_empresas",
                columns: new[] { "ruc_empresa", "id_tipo_roles" },
                values: new object[] { "20546183107", (short)1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ti_roles_empresas",
                keyColumns: new[] { "ruc_empresa", "id_tipo_roles" },
                keyValues: new object[] { "10095903768", (short)1 });

            migrationBuilder.DeleteData(
                table: "ti_roles_empresas",
                keyColumns: new[] { "ruc_empresa", "id_tipo_roles" },
                keyValues: new object[] { "20100654025", (short)1 });

            migrationBuilder.DeleteData(
                table: "ti_roles_empresas",
                keyColumns: new[] { "ruc_empresa", "id_tipo_roles" },
                keyValues: new object[] { "20546183107", (short)1 });

            migrationBuilder.DeleteData(
                table: "ti_roles_empresas",
                keyColumns: new[] { "ruc_empresa", "id_tipo_roles" },
                keyValues: new object[] { "20600044495", (short)1 });

            migrationBuilder.DeleteData(
                table: "empresas",
                keyColumn: "ruc_empresa",
                keyValue: "20546183107");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "02",
                columns: new[] { "mascara_correlativo", "mascara_serie_fisica" },
                values: new object[] { (short)4, (short)7 });
        }
    }
}
