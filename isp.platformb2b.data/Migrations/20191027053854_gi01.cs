using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace isp.platformb2b.data.Migrations
{
    public partial class gi01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ti_usuario_roles_tipo_rol_id_tipo_roles",
                table: "ti_usuario_roles");

            migrationBuilder.DropTable(
                name: "ti_roles_empresas");

            migrationBuilder.DropTable(
                name: "tipo_impuesto");

            migrationBuilder.DropTable(
                name: "tipo_rol");

            migrationBuilder.DeleteData(
                table: "ti_usuario_roles",
                keyColumns: new[] { "username", "id_tipo_roles" },
                keyValues: new object[] { "cesar", (short)1 });

            migrationBuilder.DeleteData(
                table: "ti_usuario_roles",
                keyColumns: new[] { "username", "id_tipo_roles" },
                keyValues: new object[] { "cesar", (short)2 });

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
                keyValue: "20111111119");

            migrationBuilder.DeleteData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "20333333339");

            migrationBuilder.DeleteData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "20444444449");

            migrationBuilder.DeleteData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "supermercados");

            migrationBuilder.AddColumn<string>(
                name: "dni_persona",
                table: "usuarios",
                type: "char(8)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    dni_persona = table.Column<string>(type: "char(8)", nullable: false),
                    ap_paterno = table.Column<string>(type: "varchar(50)", nullable: false),
                    ap_materno = table.Column<string>(type: "varchar(50)", nullable: false),
                    nombres = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.dni_persona);
                });

            migrationBuilder.CreateTable(
                name: "tipo_empresa",
                columns: table => new
                {
                    id_tipo_empresa = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nombre_tipo_empresa = table.Column<string>(type: "varchar(80)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_empresa", x => x.id_tipo_empresa);
                });

            migrationBuilder.CreateTable(
                name: "tipo_menu",
                columns: table => new
                {
                    id_tipo_menu = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "varchar(80)", nullable: true),
                    url = table.Column<string>(type: "varchar(500)", nullable: true),
                    icon = table.Column<string>(type: "varchar(80)", nullable: true),
                    id_tipo_menu_padre = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_menu", x => x.id_tipo_menu);
                    table.ForeignKey(
                        name: "FK_tipo_menu_tipo_menu_id_tipo_menu_padre",
                        column: x => x.id_tipo_menu_padre,
                        principalTable: "tipo_menu",
                        principalColumn: "id_tipo_menu",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ti_empresa_persona",
                columns: table => new
                {
                    dni_persona = table.Column<string>(nullable: false),
                    ruc_empresa = table.Column<string>(nullable: false),
                    fecha_inscripcion = table.Column<DateTime>(type: "timestamp", nullable: false),
                    fecha_cese = table.Column<DateTime>(type: "timestamp", nullable: true),
                    activo = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ti_empresa_persona", x => new { x.ruc_empresa, x.dni_persona });
                    table.ForeignKey(
                        name: "FK_ti_empresa_persona_persona_dni_persona",
                        column: x => x.dni_persona,
                        principalTable: "persona",
                        principalColumn: "dni_persona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ti_empresa_persona_empresas_ruc_empresa",
                        column: x => x.ruc_empresa,
                        principalTable: "empresas",
                        principalColumn: "ruc_empresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ti_tipo_empresa",
                columns: table => new
                {
                    ruc_empresa = table.Column<string>(nullable: false),
                    id_tipo_empresa = table.Column<short>(nullable: false),
                    fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ti_tipo_empresa", x => new { x.id_tipo_empresa, x.ruc_empresa });
                    table.ForeignKey(
                        name: "FK_ti_tipo_empresa_tipo_empresa_id_tipo_empresa",
                        column: x => x.id_tipo_empresa,
                        principalTable: "tipo_empresa",
                        principalColumn: "id_tipo_empresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ti_tipo_empresa_empresas_ruc_empresa",
                        column: x => x.ruc_empresa,
                        principalTable: "empresas",
                        principalColumn: "ruc_empresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tipo_roles",
                columns: table => new
                {
                    id_tipo_roles = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_tipo_empresa = table.Column<short>(type: "smallint", nullable: false),
                    nombre_rol = table.Column<string>(type: "varchar(100)", nullable: false),
                    id_tipo_roles_superior = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_roles", x => x.id_tipo_roles);
                    table.ForeignKey(
                        name: "FK_tipo_roles_tipo_empresa_id_tipo_empresa",
                        column: x => x.id_tipo_empresa,
                        principalTable: "tipo_empresa",
                        principalColumn: "id_tipo_empresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tipo_roles_tipo_roles_id_tipo_roles_superior",
                        column: x => x.id_tipo_roles_superior,
                        principalTable: "tipo_roles",
                        principalColumn: "id_tipo_roles",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ti_roles_menu",
                columns: table => new
                {
                    id_tipo_roles = table.Column<short>(nullable: false),
                    id_tipo_menu = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ti_roles_menu", x => new { x.id_tipo_menu, x.id_tipo_roles });
                    table.ForeignKey(
                        name: "FK_ti_roles_menu_tipo_menu_id_tipo_menu",
                        column: x => x.id_tipo_menu,
                        principalTable: "tipo_menu",
                        principalColumn: "id_tipo_menu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ti_roles_menu_tipo_roles_id_tipo_roles",
                        column: x => x.id_tipo_roles,
                        principalTable: "tipo_roles",
                        principalColumn: "id_tipo_roles",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "persona",
                columns: new[] { "dni_persona", "ap_materno", "ap_paterno", "nombres" },
                values: new object[,]
                {
                    { "41912505", "--", "Sanchez", "Rosalym" },
                    { "46776521", "Rivero", "Nicolini", "Cesar Gianfranco" }
                });

            migrationBuilder.InsertData(
                table: "tipo_empresa",
                columns: new[] { "id_tipo_empresa", "nombre_tipo_empresa" },
                values: new object[,]
                {
                    { (short)1, "Cliente" },
                    { (short)2, "Proveedor" },
                    { (short)3, "IVM" },
                    { (short)4, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "tipo_menu",
                columns: new[] { "id_tipo_menu", "icon", "id_tipo_menu_padre", "name", "url" },
                values: new object[,]
                {
                    { (short)1, null, null, "BlackBoard", "/dashboard" },
                    { (short)2, "fa fa-angle-double-right", null, "Capture", "/DocumentosPago" },
                    { (short)3, "fa fa-angle-double-right", null, "Verify", "/AdminIVM" },
                    { (short)4, "fa fa-angle-double-right", null, "Transfer", "/Transfer" },
                    { (short)5, "fa fa-angle-double-right", null, "Reportes", "/reporting" }
                });

            migrationBuilder.InsertData(
                table: "tipo_menu",
                columns: new[] { "id_tipo_menu", "icon", "id_tipo_menu_padre", "name", "url" },
                values: new object[,]
                {
                    { (short)21, "fa fa-keyboard-o", (short)2, "Ingreso Individual", "/DocumentosPago/formulario" },
                    { (short)22, "fa fa-file-excel-o", (short)2, "Ingreso Masivo (Excel)", "/DocumentosPago/excel" },
                    { (short)23, "fa fa-table", (short)2, "Resumen de Documentos", "/DocumentosPago/tabla" },
                    { (short)31, "fa fa-check", (short)3, "Documentos por Validar", "/AdminIVM/resumen" },
                    { (short)32, "fa fa-close", (short)3, "Documentos Rechazados", "/AdminIVM/TablaErrores" },
                    { (short)41, "fa fa-check", (short)4, "Documentos transferidos", "/transfer/tabla" },
                    { (short)51, "fa fa-check", (short)5, "Ranking de Doc. / Costo", "/reporting/ranking" },
                    { (short)52, "fa fa-check", (short)5, "Ciclo Documentario", "/reporting/DocumentaryCycle" },
                    { (short)53, "fa fa-check", (short)5, "Gestión de Documentos", "/reporting/DocumentManagement" }
                });

            migrationBuilder.InsertData(
                table: "tipo_roles",
                columns: new[] { "id_tipo_roles", "id_tipo_empresa", "id_tipo_roles_superior", "nombre_rol" },
                values: new object[,]
                {
                    { (short)11, (short)1, null, "cli-adm" },
                    { (short)21, (short)2, null, "prov-adm" },
                    { (short)31, (short)3, null, "ivm-adm" },
                    { (short)41, (short)4, null, "userivm" }
                });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "cesar",
                columns: new[] { "correo", "dni_persona" },
                values: new object[] { new[] { "cesar.nicolini@pucp.pe" }, "46776521" });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "rsanchez",
                column: "dni_persona",
                value: "41912505");

            migrationBuilder.InsertData(
                table: "ti_usuario_roles",
                columns: new[] { "username", "id_tipo_roles" },
                values: new object[,]
                {
                    { "cesar", (short)11 },
                    { "rsanchez", (short)11 },
                    { "cesar", (short)21 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_dni_persona",
                table: "usuarios",
                column: "dni_persona");

            migrationBuilder.CreateIndex(
                name: "IX_ti_empresa_persona_dni_persona",
                table: "ti_empresa_persona",
                column: "dni_persona");

            migrationBuilder.CreateIndex(
                name: "IX_ti_roles_menu_id_tipo_roles",
                table: "ti_roles_menu",
                column: "id_tipo_roles");

            migrationBuilder.CreateIndex(
                name: "IX_ti_tipo_empresa_ruc_empresa",
                table: "ti_tipo_empresa",
                column: "ruc_empresa");

            migrationBuilder.CreateIndex(
                name: "IX_tipo_menu_id_tipo_menu_padre",
                table: "tipo_menu",
                column: "id_tipo_menu_padre");

            migrationBuilder.CreateIndex(
                name: "IX_tipo_roles_id_tipo_empresa",
                table: "tipo_roles",
                column: "id_tipo_empresa");

            migrationBuilder.CreateIndex(
                name: "IX_tipo_roles_id_tipo_roles_superior",
                table: "tipo_roles",
                column: "id_tipo_roles_superior");

            migrationBuilder.AddForeignKey(
                name: "FK_ti_usuario_roles_tipo_roles_id_tipo_roles",
                table: "ti_usuario_roles",
                column: "id_tipo_roles",
                principalTable: "tipo_roles",
                principalColumn: "id_tipo_roles",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_persona_dni_persona",
                table: "usuarios",
                column: "dni_persona",
                principalTable: "persona",
                principalColumn: "dni_persona",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ti_usuario_roles_tipo_roles_id_tipo_roles",
                table: "ti_usuario_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_persona_dni_persona",
                table: "usuarios");

            migrationBuilder.DropTable(
                name: "ti_empresa_persona");

            migrationBuilder.DropTable(
                name: "ti_roles_menu");

            migrationBuilder.DropTable(
                name: "ti_tipo_empresa");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "tipo_menu");

            migrationBuilder.DropTable(
                name: "tipo_roles");

            migrationBuilder.DropTable(
                name: "tipo_empresa");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_dni_persona",
                table: "usuarios");

            migrationBuilder.DeleteData(
                table: "ti_usuario_roles",
                keyColumns: new[] { "username", "id_tipo_roles" },
                keyValues: new object[] { "cesar", (short)11 });

            migrationBuilder.DeleteData(
                table: "ti_usuario_roles",
                keyColumns: new[] { "username", "id_tipo_roles" },
                keyValues: new object[] { "cesar", (short)21 });

            migrationBuilder.DeleteData(
                table: "ti_usuario_roles",
                keyColumns: new[] { "username", "id_tipo_roles" },
                keyValues: new object[] { "rsanchez", (short)11 });

            migrationBuilder.DropColumn(
                name: "dni_persona",
                table: "usuarios");

            migrationBuilder.CreateTable(
                name: "tipo_impuesto",
                columns: table => new
                {
                    id_tipo_impuesto = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nombre = table.Column<string>(type: "varchar(20)", nullable: false),
                    valor = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_impuesto", x => x.id_tipo_impuesto);
                });

            migrationBuilder.CreateTable(
                name: "tipo_rol",
                columns: table => new
                {
                    id_tipo_roles = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nombre_rol = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_rol", x => x.id_tipo_roles);
                });

            migrationBuilder.CreateTable(
                name: "ti_roles_empresas",
                columns: table => new
                {
                    ruc_empresa = table.Column<string>(nullable: false),
                    id_tipo_roles = table.Column<short>(nullable: false),
                    fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ti_roles_empresas", x => new { x.ruc_empresa, x.id_tipo_roles });
                    table.ForeignKey(
                        name: "FK_ti_roles_empresas_tipo_rol_id_tipo_roles",
                        column: x => x.id_tipo_roles,
                        principalTable: "tipo_rol",
                        principalColumn: "id_tipo_roles",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ti_roles_empresas_empresas_ruc_empresa",
                        column: x => x.ruc_empresa,
                        principalTable: "empresas",
                        principalColumn: "ruc_empresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tipo_impuesto",
                columns: new[] { "id_tipo_impuesto", "nombre", "valor" },
                values: new object[] { (short)1, "IGV", 0.18m });

            migrationBuilder.InsertData(
                table: "tipo_rol",
                columns: new[] { "id_tipo_roles", "nombre_rol" },
                values: new object[,]
                {
                    { (short)1, "cliente" },
                    { (short)2, "proveedor" },
                    { (short)3, "admin" },
                    { (short)4, "userivm" }
                });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "username",
                keyValue: "cesar",
                column: "correo",
                value: new[] { "Element 1" });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "username", "correo", "id_persona", "password", "per_emp", "ruc_empresa", "telefono" },
                values: new object[,]
                {
                    { "20111111119", new[] { "adminitrativo@las_bellezas.com" }, 0, "123456", true, "20111111119", new[] { "4774267", "959863830" } },
                    { "20333333339", new[] { "adminitrativo@los_negocios.com" }, 0, "123456", true, "20333333339", new[] { "4774267", "959863830" } },
                    { "20444444449", new[] { "adminitrativo@fuerza_agraria.com" }, 0, "123456", true, "20444444449", new[] { "4774267", "959863830" } },
                    { "supermercados", new[] { "superman@supermercados.com" }, 0, "123456", true, "20100070970", new[] { "6969696", "96969696969" } }
                });

            migrationBuilder.InsertData(
                table: "ti_roles_empresas",
                columns: new[] { "ruc_empresa", "id_tipo_roles", "fecha" },
                values: new object[,]
                {
                    { "10467765219", (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20600044495", (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20999999999", (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20888888889", (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20666666669", (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20444444449", (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20333333339", (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20222222229", (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20111111119", (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "10467765219", (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20100654025", (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20546183107", (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20100070970", (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20600044495", (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20000000009", (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20111111119", (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20222222229", (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20333333339", (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "10095903768", (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20555555559", (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20444444449", (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20777777779", (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20999999999", (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "20666666669", (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ti_usuario_roles",
                columns: new[] { "username", "id_tipo_roles" },
                values: new object[,]
                {
                    { "rsanchez", (short)1 },
                    { "cesar", (short)1 },
                    { "supermercados", (short)1 },
                    { "cesar", (short)2 },
                    { "rsanchez", (short)2 },
                    { "supermercados", (short)2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ti_roles_empresas_id_tipo_roles",
                table: "ti_roles_empresas",
                column: "id_tipo_roles");

            migrationBuilder.AddForeignKey(
                name: "FK_ti_usuario_roles_tipo_rol_id_tipo_roles",
                table: "ti_usuario_roles",
                column: "id_tipo_roles",
                principalTable: "tipo_rol",
                principalColumn: "id_tipo_roles",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
