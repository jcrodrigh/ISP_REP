using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class new7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "lista_serie",
                table: "tipo_documento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "serie_requerido",
                table: "tipo_documento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "tipo_documento_serie",
                columns: table => new
                {
                    id_tipo_documento = table.Column<string>(type: "char(2)", nullable: false),
                    id_tipo_documento_serie = table.Column<string>(type: "varchar(20)", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_documento_serie", x => new { x.id_tipo_documento, x.id_tipo_documento_serie });
                    table.ForeignKey(
                        name: "FK_tipo_documento_serie_tipo_documento_id_tipo_documento",
                        column: x => x.id_tipo_documento,
                        principalTable: "tipo_documento",
                        principalColumn: "id_tipo_documento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "01",
                column: "serie_requerido",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "02",
                column: "serie_requerido",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "03",
                column: "serie_requerido",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "05",
                column: "serie_requerido",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "07",
                column: "serie_requerido",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "08",
                column: "serie_requerido",
                value: true);

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "10",
                columns: new[] { "formato_serie_electronica", "formato_serie_fisica", "lista_serie", "serie_requerido" },
                values: new object[] { "^([A-Za-z0-9]{0,20})$", "^([A-Za-z0-9]{0,20})$", true, true });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "12",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica", "orden_compra_requerido", "serie_requerido" },
                values: new object[] { "^([A-Za-z0-9]{0,20})$", "^([A-Za-z0-9]{0,4})$", "^([A-Za-z0-9]{0,4})$", true, true });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "13",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica", "orden_compra_requerido" },
                values: new object[] { "[A-Za-z0-9]{0,20}", "[A-Za-z0-9]{0,4}", "[A-Za-z0-9]{0,4}", false });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "14",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "[A-Za-z0-9]{0,20}", "[A-Za-z0-9]{0,4}", "[A-Za-z0-9]{0,4}" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "50",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica", "lista_serie", "mascara_correlativo", "mascara_serie_fisica", "serie_requerido" },
                values: new object[] { "(?!000000)[0-9]{6}", "^([A-Za-z0-9]{0,20})$", "^([A-Za-z0-9]{0,20})$", true, (short)6, (short)0, true });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "91",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica", "serie_requerido" },
                values: new object[] { "^([A-Za-z0-9]{0,20})$", "^([A-Za-z0-9]{0,4})$", "^([A-Za-z0-9]{0,4})$", true });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "97",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica", "serie_requerido" },
                values: new object[] { "^([A-Za-z0-9]{0,20})$", "^([A-Za-z0-9]{0,4})$", "^([A-Za-z0-9]{0,4})$", true });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "ER",
                columns: new[] { "formato_serie_electronica", "formato_serie_fisica", "serie_requerido" },
                values: new object[] { "^([A-Za-z0-9]{0,20})$", "^([A-Za-z0-9]{0,20})$", true });

            migrationBuilder.InsertData(
                table: "tipo_documento_serie",
                columns: new[] { "id_tipo_documento", "id_tipo_documento_serie", "descripcion" },
                values: new object[,]
                {
                    { "50", "956", "CETICOS TACANA" },
                    { "50", "947", "AREOPUERTO TACNA" },
                    { "50", "938", "TERMINAL TERRESTRE TACNA" },
                    { "50", "929", "COMPLEJO FRONTERIZO STA ROSA TACNA" },
                    { "50", "910", "DEPENDENCIA POSTAL AREQUIPA" },
                    { "50", "893", "DEPENDENCIA POSTAL TACNA" },
                    { "50", "884", "DEPENDENCIA FERROVIARIA TACNA" },
                    { "50", "299", "LA TINA" },
                    { "50", "280", "PUERTO MALDONADO" },
                    { "50", "271", "TARAPOTO" },
                    { "50", "262", "DESAGUADERO" },
                    { "50", "244", "POSTAL DE LIMA" },
                    { "50", "235", "AÉREA DEL CALLAO" },
                    { "50", "226", "IQUITOS" },
                    { "50", "145", "MOLLENDO MATARANI" },
                    { "50", "190", "CUZCO" },
                    { "50", "181", "PUNO" },
                    { "50", "172", "TACNA" },
                    { "50", "163", "ILO" },
                    { "50", "154", "AREQUIPA" },
                    { "50", "965", "DEPENDENCIA POSTAL DE SALVERRY" },
                    { "50", "127", "PISCO" },
                    { "50", "118", "MARÍTIMA DEL CALLAO" },
                    { "50", "091", "CHIMBOTE" },
                    { "50", "082", "SALAVERRY" },
                    { "50", "055", "CHICLAYO" },
                    { "50", "046", "PAITA" },
                    { "50", "028", "TALARA" },
                    { "50", "019", "TUMBES" },
                    { "50", "217", "PUCALLPA" },
                    { "10", "1683", "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tipo_documento_serie");

            migrationBuilder.DropColumn(
                name: "lista_serie",
                table: "tipo_documento");

            migrationBuilder.DropColumn(
                name: "serie_requerido",
                table: "tipo_documento");

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "10",
                columns: new[] { "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "^([A-Z0-9]{0,20}|)$", "^([A-Z0-9]{0,20}|)$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "12",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica", "orden_compra_requerido" },
                values: new object[] { "^([1-9][0-9]{0,19})$", "^([A-Z0-9]{0,20}|)$", "^([A-Z0-9]{0,20}|)$", false });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "13",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica", "orden_compra_requerido" },
                values: new object[] { "^([1-9][0-9]{0,19})$", "^([A-Z0-9]{0,20}|)$", "^([A-Z0-9]{0,20}|)$", true });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "14",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "^([1-9][0-9]{0,19})$", "^([A-Z0-9]{0,20}|)$", "^([A-Z0-9]{0,20}|)$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "50",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica", "mascara_correlativo", "mascara_serie_fisica" },
                values: new object[] { "(?!00000000)[0-9]{8}", "^([A-Z0-9]{0,20}|)$", "^([0-9]{4})$", (short)8, (short)4 });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "91",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "^([1-9][0-9]{0,19})$", "^([A-Z0-9]{0,20}|)$", "^([A-Z0-9]{0,20}|)$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "97",
                columns: new[] { "formato_correlativo", "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "^([1-9][0-9]{0,19})$", "^([A-Z0-9]{0,20}|)$", "^([A-Z0-9]{0,20}|)$" });

            migrationBuilder.UpdateData(
                table: "tipo_documento",
                keyColumn: "id_tipo_documento",
                keyValue: "ER",
                columns: new[] { "formato_serie_electronica", "formato_serie_fisica" },
                values: new object[] { "^([A-Z0-9]{0,20}|)$", "^([A-Z0-9]{0,20}|)$" });
        }
    }
}
