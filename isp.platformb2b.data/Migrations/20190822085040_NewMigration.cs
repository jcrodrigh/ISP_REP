using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace isp.platformb2b.data.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "auditorias",
                columns: table => new
                {
                    id_auditorias = table.Column<Guid>(type: "bigserial", nullable: false),
                    nombre_tabla = table.Column<string>(type: "varchar(100)", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    llave_fila = table.Column<string>(type: "varchar(100)", nullable: false),
                    valor_anterior = table.Column<string>(type: "varchar(10000)", nullable: true),
                    valor_nuevo = table.Column<string>(type: "varchar(10000)", nullable: true),
                    usuario = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auditorias", x => x.id_auditorias);
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TableName = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    KeyValues = table.Column<string>(nullable: true),
                    OldValues = table.Column<string>(nullable: true),
                    NewValues = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "facturas",
                columns: table => new
                {
                    FacturaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TipoDocumento = table.Column<int>(type: "integer", nullable: false),
                    TipoMoneda = table.Column<string>(type: "char(3)", nullable: false),
                    fechaFactura = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    NumeroFactura = table.Column<string>(type: "varchar(13)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facturas", x => x.FacturaId);
                });

            migrationBuilder.CreateTable(
                name: "tipo_detracciones",
                columns: table => new
                {
                    id_tipo_detracciones = table.Column<string>(type: "char(2)", nullable: false),
                    descripcion_detracciones = table.Column<string>(type: "varchar(80)", nullable: false),
                    valor_detracciones = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_detracciones", x => x.id_tipo_detracciones);
                });

            migrationBuilder.CreateTable(
                name: "tipo_documento",
                columns: table => new
                {
                    id_tipo_documento = table.Column<string>(type: "char(2)", nullable: false),
                    nombre_documento = table.Column<string>(type: "varchar(300)", nullable: false),
                    iva = table.Column<decimal>(type: "numeric(4,3)", nullable: false),
                    nombre_iva = table.Column<string>(type: "varchar(400)", nullable: true),
                    formato_serie_fisica = table.Column<string>(type: "varchar(200)", nullable: false),
                    formato_serie_electronica = table.Column<string>(type: "varchar(200)", nullable: false),
                    formato_correlativo = table.Column<string>(type: "varchar(200)", nullable: false),
                    formato_ruc_proveedor = table.Column<string>(type: "varchar(40)", nullable: false),
                    nombre_afecto = table.Column<string>(type: "varchar(400)", nullable: true),
                    nombre_inafecto = table.Column<string>(type: "varchar(400)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_documento", x => x.id_tipo_documento);
                });

            migrationBuilder.CreateTable(
                name: "tipo_documento_devolucion",
                columns: table => new
                {
                    id_tipo_documento_devolucion = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    motivo = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_documento_devolucion", x => x.id_tipo_documento_devolucion);
                });

            migrationBuilder.CreateTable(
                name: "tipo_documento_estado",
                columns: table => new
                {
                    id_tipo_documento_estado = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    estado = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_documento_estado", x => x.id_tipo_documento_estado);
                });

            migrationBuilder.CreateTable(
                name: "tipo_empresa_erp",
                columns: table => new
                {
                    id_tipo_empresa_erp = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nombre_tipo_empresa_erp = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_empresa_erp", x => x.id_tipo_empresa_erp);
                });

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
                name: "tipo_moneda",
                columns: table => new
                {
                    id_tipo_moneda = table.Column<string>(type: "char(3)", nullable: false),
                    divisa = table.Column<string>(type: "varchar(100)", nullable: false),
                    usual = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_moneda", x => x.id_tipo_moneda);
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
                name: "empresas",
                columns: table => new
                {
                    ruc_empresa = table.Column<string>(type: "char(11)", nullable: false),
                    razon_social = table.Column<string>(type: "varchar(130)", nullable: false),
                    domicilio_fiscal = table.Column<string>(type: "varchar(200)", nullable: false),
                    id_tipo_empresa_erp = table.Column<short>(type: "smallint", nullable: false),
                    con_pedido = table.Column<bool>(type: "boolean", nullable: false),
                    sin_pedido = table.Column<bool>(type: "boolean", nullable: false),
                    tolerancia = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    tipo_tolerancia = table.Column<short>(type: "smallint", nullable: false),
                    logo = table.Column<string>(type: "varchar(100)", nullable: true),
                    activo = table.Column<bool>(type: "boolean", nullable: false),
                    habido = table.Column<bool>(type: "boolean", nullable: false),
                    correo = table.Column<string[]>(type: "varchar(100)[]", nullable: false),
                    telefono = table.Column<string[]>(type: "varchar(12)[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresas", x => x.ruc_empresa);
                    table.ForeignKey(
                        name: "FK_empresas_tipo_empresa_erp_id_tipo_empresa_erp",
                        column: x => x.id_tipo_empresa_erp,
                        principalTable: "tipo_empresa_erp",
                        principalColumn: "id_tipo_empresa_erp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ordenes_compra",
                columns: table => new
                {
                    ruc_empresa_cliente = table.Column<string>(type: "char(11)", nullable: false),
                    id_orden_compra = table.Column<string>(type: "varchar(100)", nullable: false),
                    ruc_empresa_proveedor = table.Column<string>(type: "char(11)", nullable: true),
                    id_tipo_moneda = table.Column<string>(type: "char(3)", nullable: false),
                    monto_orden_compra = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    competado = table.Column<bool>(type: "boolean", nullable: false),
                    activa = table.Column<bool>(type: "boolean", nullable: false),
                    monto_acumulado = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenes_compra", x => new { x.ruc_empresa_cliente, x.id_orden_compra });
                    table.UniqueConstraint("AK_ordenes_compra_id_orden_compra_ruc_empresa_cliente", x => new { x.id_orden_compra, x.ruc_empresa_cliente });
                    table.ForeignKey(
                        name: "FK_ordenes_compra_tipo_moneda_id_tipo_moneda",
                        column: x => x.id_tipo_moneda,
                        principalTable: "tipo_moneda",
                        principalColumn: "id_tipo_moneda",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordenes_compra_empresas_ruc_empresa_cliente",
                        column: x => x.ruc_empresa_cliente,
                        principalTable: "empresas",
                        principalColumn: "ruc_empresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordenes_compra_empresas_ruc_empresa_proveedor",
                        column: x => x.ruc_empresa_proveedor,
                        principalTable: "empresas",
                        principalColumn: "ruc_empresa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ti_empresa_empresa",
                columns: table => new
                {
                    ruc_empresa_cliente = table.Column<string>(nullable: false),
                    ruc_empresa_proveedor = table.Column<string>(nullable: false),
                    activo = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ti_empresa_empresa", x => new { x.ruc_empresa_cliente, x.ruc_empresa_proveedor });
                    table.ForeignKey(
                        name: "FK_ti_empresa_empresa_empresas_ruc_empresa_cliente",
                        column: x => x.ruc_empresa_cliente,
                        principalTable: "empresas",
                        principalColumn: "ruc_empresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ti_empresa_empresa_empresas_ruc_empresa_proveedor",
                        column: x => x.ruc_empresa_proveedor,
                        principalTable: "empresas",
                        principalColumn: "ruc_empresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ti_roles_empresas",
                columns: table => new
                {
                    ruc_empresa = table.Column<string>(nullable: false),
                    id_tipo_roles = table.Column<short>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    username = table.Column<string>(type: "varchar(30)", nullable: false),
                    password = table.Column<string>(type: "varchar(500)", nullable: false),
                    ruc_empresa = table.Column<string>(type: "char(11)", nullable: false),
                    id_persona = table.Column<int>(type: "integer", nullable: false),
                    per_emp = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    correo = table.Column<string[]>(type: "varchar(100)[]", nullable: false),
                    telefono = table.Column<string[]>(type: "varchar(12)[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.username);
                    table.ForeignKey(
                        name: "FK_usuarios_empresas_ruc_empresa",
                        column: x => x.ruc_empresa,
                        principalTable: "empresas",
                        principalColumn: "ruc_empresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "documento",
                columns: table => new
                {
                    ruc_empresa_proveedor = table.Column<string>(type: "char(11)", nullable: false),
                    id_tipo_documento = table.Column<string>(type: "char(2)", nullable: false),
                    id_documento = table.Column<string>(type: "varchar(60)", nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    num_serie = table.Column<string>(type: "varchar(30)", nullable: false),
                    num_correlativo = table.Column<string>(type: "varchar(30)", nullable: false),
                    fis_elec = table.Column<bool>(type: "boolean", nullable: false),
                    ruc_empresa_cliente = table.Column<string>(type: "char(11)", nullable: false),
                    id_orden_compra = table.Column<string>(type: "varchar(100)", nullable: false),
                    id_tipo_moneda = table.Column<string>(type: "char(3)", nullable: false),
                    monto_subtotal_afecto = table.Column<decimal>(type: "money", nullable: false),
                    monto_subtotal_inafecto = table.Column<decimal>(type: "money", nullable: false),
                    monto_igv = table.Column<decimal>(type: "money", nullable: false),
                    monto_isc = table.Column<decimal>(type: "money", nullable: false),
                    monto_total = table.Column<decimal>(type: "money", nullable: false),
                    id_tipo_documento_estado = table.Column<short>(type: "smallint", nullable: false),
                    fecha_emision = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    id_tipo_detracciones = table.Column<string>(type: "char(2)", nullable: true),
                    factura_negociable = table.Column<bool>(type: "boolean", nullable: false),
                    conformidad = table.Column<bool>(type: "boolean", nullable: false),
                    CECO = table.Column<string>(type: "varchar (80)", nullable: true),
                    ultima_modificacion = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    usuario_modificacion = table.Column<string>(type: "varchar(100)", nullable: false),
                    url_imagen = table.Column<string[]>(type: "varchar(100)[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documento", x => new { x.ruc_empresa_proveedor, x.id_tipo_documento, x.id_documento });
                    table.UniqueConstraint("AK_documento_id_documento_id_tipo_documento_ruc_empresa_provee~", x => new { x.id_documento, x.id_tipo_documento, x.ruc_empresa_proveedor });
                    table.ForeignKey(
                        name: "FK_documento_tipo_detracciones_id_tipo_detracciones",
                        column: x => x.id_tipo_detracciones,
                        principalTable: "tipo_detracciones",
                        principalColumn: "id_tipo_detracciones",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_documento_tipo_documento_id_tipo_documento",
                        column: x => x.id_tipo_documento,
                        principalTable: "tipo_documento",
                        principalColumn: "id_tipo_documento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_documento_tipo_documento_estado_id_tipo_documento_estado",
                        column: x => x.id_tipo_documento_estado,
                        principalTable: "tipo_documento_estado",
                        principalColumn: "id_tipo_documento_estado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_documento_tipo_moneda_id_tipo_moneda",
                        column: x => x.id_tipo_moneda,
                        principalTable: "tipo_moneda",
                        principalColumn: "id_tipo_moneda",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_documento_empresas_ruc_empresa_proveedor",
                        column: x => x.ruc_empresa_proveedor,
                        principalTable: "empresas",
                        principalColumn: "ruc_empresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_documento_ordenes_compra_ruc_empresa_cliente_id_orden_compra",
                        columns: x => new { x.ruc_empresa_cliente, x.id_orden_compra },
                        principalTable: "ordenes_compra",
                        principalColumns: new[] { "ruc_empresa_cliente", "id_orden_compra" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ti_usuario_roles",
                columns: table => new
                {
                    username = table.Column<string>(nullable: false),
                    id_tipo_roles = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ti_usuario_roles", x => new { x.username, x.id_tipo_roles });
                    table.ForeignKey(
                        name: "FK_ti_usuario_roles_tipo_rol_id_tipo_roles",
                        column: x => x.id_tipo_roles,
                        principalTable: "tipo_rol",
                        principalColumn: "id_tipo_roles",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ti_usuario_roles_usuarios_username",
                        column: x => x.username,
                        principalTable: "usuarios",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tipo_detracciones",
                columns: new[] { "id_tipo_detracciones", "descripcion_detracciones", "valor_detracciones" },
                values: new object[,]
                {
                    { "12", "Intermediación laboral y tercerización", 12m },
                    { "40", "Primera venta de inmuebles que realicen los constructores.", 4m },
                    { "39", "Minerales no metálicos", 10m },
                    { "37", "Demás servicios gravados con el IGV", 12m },
                    { "36", "Oro y demás minerales metálicos exonerados del IGV", 1.5m },
                    { "34", "Minerales metálicos no auríferos", 10m },
                    { "31", "Oro gravado con el IGV", 10m },
                    { "30", "Contratos de construcción", 4m },
                    { "27", "Servicio de transporte de bienes", 4m },
                    { "26", "Servicio de Transporte de personas", 10m },
                    { "25", "Fabricación de bienes por encargo", 10m },
                    { "24", "Comisión mercantil", 10m },
                    { "23", "Leche", 4m },
                    { "22", "Otros servicios empresariales", 12m },
                    { "21", "Movimiento de carga", 10m },
                    { "35", "Bienes exonerados de IGV", 1.5m },
                    { "19", "Arrendamiento de bienes", 10m },
                    { "20", "Mantenimiento y reparación de bienes muebles", 12m },
                    { "01", "Azúcar y melaza de caña", 10m },
                    { "03", "Alcohol etílico", 10m },
                    { "04", "Recursos hidrobiológicos", 4m },
                    { "07", "Caña de azúcar", 10m },
                    { "08", "Madera", 4m },
                    { "05", "Maíz amarillo duro", 4m },
                    { "10", "Residuos subproductos, desechos, recortes, desperdicios", 15m },
                    { "11", "Bienes gravados con el IGV, por renuncia a la exoneración", 10m },
                    { "14", "Carne y despojos comestibles", 4m },
                    { "16", "Aceite de Pescado", 10m },
                    { "17", "Harina, polvo y 'pellets' de pescado, crustáceos, moluscos y demás.", 4m },
                    { "09", "Arena y piedra", 10m }
                });

            migrationBuilder.InsertData(
                table: "tipo_documento",
                columns: new[] { "id_tipo_documento", "formato_correlativo", "formato_ruc_proveedor", "formato_serie_electronica", "formato_serie_fisica", "iva", "nombre_afecto", "nombre_documento", "nombre_inafecto", "nombre_iva" },
                values: new object[,]
                {
                    { "ER", "^([1-9][0-9]{0,19})$", "^20[0-9]{9}$", "^([A-Z0-9]{0,20}|)$", "^([A-Z0-9]{0,20}|)$", 0m, "Monto Afecto", "Entregas a rendir.", "Monto Inafecto", "Monto IGV" },
                    { "14", "^([1-9][0-9]{0,19})$", "^20[0-9]{9}$", "^([A-Z0-9]{0,20}|)$", "^([A-Z0-9]{0,20}|)$", 0m, "Monto Afecto", "Recibo por servicios públicos de suministro de energía eléctrica, agua, teléfono, télex y telegráficos y otros servicios complementarios que se incluyan en el recibo de servicio público", "Monto Inafecto", "Monto IGV" },
                    { "AS", "^([1-9][0-9]{0,19})$", "^20[0-9]{9}$", "^([A-Z0-9]{0,20}|)$", "^([A-Z0-9]{0,20}|)$", 0m, "Monto Afecto", "Apunte contable cuenta mayor.", "Monto Inafecto", "Monto IGV" },
                    { "00", "^([1-9][0-9]{0,19})$", "^20[0-9]{9}$", "^([A-Z0-9]{0,20}|)$", "^([A-Z0-9]{0,20}|)$", 0m, "Monto Afecto", "Otros.", "Monto Inafecto", "Monto IGV" },
                    { "97", "^([1-9][0-9]{0,19})$", "^20[0-9]{9}$", "^([A-Z0-9]{0,20}|)$", "^([A-Z0-9]{0,20}|)$", 0m, "Monto Afecto", "Nota de Crédito - No Domiciliado", "Monto Inafecto", "Monto IGV" },
                    { "91", "^([1-9][0-9]{0,19})$", "^20[0-9]{9}$", "^([A-Z0-9]{0,20}|)$", "^([A-Z0-9]{0,20}|)$", 0m, "Monto Afecto", "Comprobante de No Domiciliado.", "Monto Inafecto", "Monto IGV" },
                    { "50", "^([1-9][0-9]{0,7})$", "^20[0-9]{9}$", "^(EB01|EB01|B[A-Z0-9]{3}|F[A-Z0-9]{3})$", "^([0-9]{0,4})$", 0m, "Monto Afecto", "Declaración Única de Aduanas - DUA/ Declaración Aduanera de Mercancías - DAM.", "Monto Inafecto", "Monto IGV" },
                    { "13", "^([1-9][0-9]{0,19})$", "^20[0-9]{9}$", "^([A-Z0-9]{0,20}|)$", "^([A-Z0-9]{0,20}|)$", 0m, "Monto Afecto", "Documentos emitidos por las empresas del sistema financiero y de seguros, y por las cooperativas de ahorro y crédito no autorizadas a captar recursos del público, que se encuentren bajo el control de la Superintendencia de Banca, Seguros y AFP.", "Monto Inafecto", "Monto IGV" },
                    { "05", "^([1-9][0-9]{0,10})$", "^20[0-9]{9}$", "^([1-5])$", "^([1-5])$", 0m, "Monto Afecto", "Boletos de Transporte Aéreo.", "Monto Inafecto", "Monto IGV" },
                    { "10", "^([1-9][0-9]{0,19})$", "^20[0-9]{9}$", "^([A-Z0-9]{0,20}|)$", "^([A-Z0-9]{0,20}|)$", 0m, "Monto Afecto", "Recibo por Arrendamiento.", "Monto Inafecto", "Monto IGV" },
                    { "08", "^([1-9][0-9]{0,7})$", "^20[0-9]{9}$", "^(EB01|EB01|B[A-Z0-9]{3}|F[A-Z0-9]{3})$", "^([1-9][0-9]{0,3})$", 0.18m, "Monto Afecto", "Nota de débito.", "Monto Inafecto", "Monto IGV" },
                    { "07", "^([1-9][0-9]{0,7})$", "^20[0-9]{9}$", "^(EB01|EB01|B[A-Z0-9]{3}|F[A-Z0-9]{3})$", "^([1-9][0-9]{0,3})$", 0.18m, "Monto Afecto", "Nota de crédito.", "Monto Inafecto", "Monto IGV" },
                    { "03", "^([1-9][0-9]{0,7})$", "^20[0-9]{9}$", "^(EB01|B[A-Z0-9]{3})$", "^([1-9][0-9]{0,3})$", 0m, "Monto Afecto", "Boleta de Venta.", "valor venta", "Monto IGV" },
                    { "02", "^([1-9][0-9]{0,6})$", "^10[0-9]{9}$", "^(E001)$", "^([1-9][0-9]{0,3})$", 0.8m, "Monto con retención", "Recibo por Honorarios.", "Monto sin retención", "Retención" },
                    { "01", "^([1-9][0-9]{0,7})$", "^20[0-9]{9}$", "^(E001|F[A-Z0-9]{3})$", "^([0-9]{4})$", 0.18m, "Monto Afecto", "Factura.", "Monto Inafecto", "Monto IGV" },
                    { "12", "^([1-9][0-9]{0,19})$", "^20[0-9]{9}$", "^([A-Z0-9]{0,20}|)$", "^([A-Z0-9]{0,20}|)$", 0m, "Monto Afecto", "Ticket o cinta emitido por máquina registradora.", "Monto Inafecto", "Monto IGV" }
                });

            migrationBuilder.InsertData(
                table: "tipo_documento_devolucion",
                columns: new[] { "id_tipo_documento_devolucion", "motivo" },
                values: new object[,]
                {
                    { (short)7, "Montos no coinciden con los montos de la conformidad." },
                    { (short)11, "Fechas superiores al establecido fiscalmente." },
                    { (short)10, "Error en la descripción de los montos en relación a los numéricos." },
                    { (short)9, "Error en la tasa del IGV." },
                    { (short)6, "Por duplicidad." },
                    { (short)8, "Emitidos a otra razón social." },
                    { (short)4, "No contiene los datos de detracciones." },
                    { (short)5, "Documento referido a un documento equivocado." },
                    { (short)3, "No contiene el dato de N° de pedido y Conformidad." },
                    { (short)2, "Error en el cálculo del impuesto." },
                    { (short)1, "Error en datos de la compañía." }
                });

            migrationBuilder.InsertData(
                table: "tipo_documento_estado",
                columns: new[] { "id_tipo_documento_estado", "estado" },
                values: new object[,]
                {
                    { (short)1, "Por Comprobar" },
                    { (short)2, "Aprobado" },
                    { (short)3, "Observado" },
                    { (short)4, "Anulado" }
                });

            migrationBuilder.InsertData(
                table: "tipo_empresa_erp",
                columns: new[] { "id_tipo_empresa_erp", "nombre_tipo_empresa_erp" },
                values: new object[,]
                {
                    { (short)3, "SALESFORCE" },
                    { (short)2, "MICROSOFT DYNAMICS" },
                    { (short)1, "SAP" }
                });

            migrationBuilder.InsertData(
                table: "tipo_impuesto",
                columns: new[] { "id_tipo_impuesto", "nombre", "valor" },
                values: new object[] { (short)1, "IGV", 0.18m });

            migrationBuilder.InsertData(
                table: "tipo_moneda",
                columns: new[] { "id_tipo_moneda", "divisa", "usual" },
                values: new object[,]
                {
                    { "PYG", "Guaraní", false },
                    { "QAR", "Riyal qatarí", false },
                    { "PLN", "Złoty", false },
                    { "RON", "Leu rumano", false },
                    { "RSD", "Dinar serbio", false },
                    { "RUB", "Rublo ruso", false },
                    { "RWF", "Franco ruandés", false },
                    { "SAR", "Riyal saudí", false },
                    { "SHP", "Libra de Santa Elena", false },
                    { "SCR", "Rupia seychelense", false },
                    { "SDG", "Dinar sudanés", false },
                    { "SEK", "Corona sueca", false },
                    { "SGD", "Dólar de Singapur", false },
                    { "PKR", "Rupia pakistaní", false },
                    { "SLL", "Leone", false },
                    { "SOS", "Chelín somalí", false },
                    { "SRD", "Dólar surinamés", false },
                    { "SSP", "Libra sursudanesa", false },
                    { "SBD", "Dólar de las Islas Salomón", false },
                    { "PHP", "Peso filipino", false },
                    { "NOK", "Corona noruega", false },
                    { "PEN", "Sol", true },
                    { "STN", "Dobra", false },
                    { "MMK", "Kyat", false },
                    { "MNT", "Tugrik", false },
                    { "MOP", "Pataca", false },
                    { "MRU", "Uguiya", false },
                    { "MUR", "Rupia de Mauricio", false },
                    { "MVR", "Rufiyaa", false },
                    { "MWK", "Kwacha", false },
                    { "MXN", "Peso mexicano", false },
                    { "MXV", "Unidad de Inversión (UDI) mexicana", false },
                    { "MYR", "Ringgit malayo", false },
                    { "MZN", "Metical mozambiqueño", false },
                    { "NAD", "Dólar namibio", false },
                    { "NGN", "Naira", false },
                    { "NIO", "Córdoba", false },
                    { "NPR", "Rupia nepalí", false },
                    { "NZD", "Dólar neozelandés", false },
                    { "OMR", "Rial omaní", false },
                    { "PAB", "Balboa", false },
                    { "PGK", "Kina", false },
                    { "SVC", "Colon Salvadoreño", false },
                    { "XOF", "Franco CFA de África Occidental", false },
                    { "SZL", "Lilangeni", false },
                    { "XAU", "Oro (una onza troy)", false },
                    { "XBA", "Unidad compuesta europea (EURCO) (Unidad del mercados de bonos)", false },
                    { "XBB", "Unidad Monetaria europea (E.M.U.-6) (Unidad del mercado de bonos)", false },
                    { "XBC", "Unidad europea de cuenta 9 (E.U.A.-9) (Unidad del mercado de bonos)", false },
                    { "XBD", "Unidad europea de cuenta 17 (E.U.A.-17) (Unidad del mercado de bonos)", false },
                    { "XCD", "Dólar del Caribe Oriental", false },
                    { "XDR", "Derechos especiales de giro", false },
                    { "MKD", "Denar", false },
                    { "XPD", "Paladio (una onza troy)", false },
                    { "XPF", "Franco CFP", false },
                    { "XPT", "Platino (una onza troy)", false },
                    { "XSU", "SUCRE", false },
                    { "XTS", "Reservado para pruebas", false },
                    { "XUA", "Unidad de cuenta BAD", false },
                    { "XXX", "Sin divisa", false },
                    { "YER", "Rial yemení", false },
                    { "ZAR", "Rand", false },
                    { "ZMW", "Kwacha zambiano", false },
                    { "ZWL", "Dólar zimbabuense", false },
                    { "XAG", "Plata (una onza troy)", false },
                    { "SYP", "Libra siria", false },
                    { "XAF", "Franco CFA de África Central", false },
                    { "VUV", "Vatu", false },
                    { "THB", "Baht", false },
                    { "TJS", "Somoni tayiko", false },
                    { "TMT", "Manat turcomano", false },
                    { "TND", "Dinar tunecino", false },
                    { "TOP", "Paʻanga", false },
                    { "TRY", "Lira turca", false },
                    { "TTD", "Dólar de Trinidad y Tobago", false },
                    { "TWD", "Nuevo dólar taiwanés", false },
                    { "TZS", "Chelín tanzano", false },
                    { "UAH", "Grivna", false },
                    { "UGX", "Chelín ugandés", false },
                    { "USD", "Dólar estadounidense", true },
                    { "USN", "Dólar estadounidense (Siguiente día)", false },
                    { "UYI", "Peso en Unidades Indexadas (Uruguay)", false },
                    { "UYU", "Peso uruguayo", false },
                    { "UYW", "Unidad Previsional", false },
                    { "UZS", "Som uzbeko", false },
                    { "VES", "Bolívar soberano", false },
                    { "VND", "Dong vietnamita", false },
                    { "WST", "Tala", false },
                    { "MGA", "Ariary malgache", false },
                    { "GYD", "Dólar guyanés", false },
                    { "MAD", "Dírham marroquí", false },
                    { "BWP", "Pula", false },
                    { "BYN", "Rublo bielorruso", false },
                    { "BZD", "Dólar beliceño", false },
                    { "CAD", "Dólar canadiense", false },
                    { "CDF", "Franco congoleño", false },
                    { "CHE", "Euro WIR", false },
                    { "CHF", "Franco suizo", false },
                    { "CHW", "Franco WIR", false },
                    { "CLF", "Unidad de fomento", false },
                    { "CLP", "Peso chileno", false },
                    { "CNY", "Yuan chino", false },
                    { "COP", "Peso colombiano", false },
                    { "COU", "Unidad de valor real", false },
                    { "CRC", "Colón costarricense", false },
                    { "CUC", "Peso convertible", false },
                    { "CUP", "Peso cubano", false },
                    { "CVE", "Escudo caboverdiano", false },
                    { "CZK", "Corona checa", false },
                    { "DJF", "Franco yibutiano", false },
                    { "BTN", "Ngultrum", false },
                    { "MDL", "Leu moldavo", false },
                    { "BSD", "Dólar bahameño", false },
                    { "BOV", "MVDOL", false },
                    { "AED", "Dírham de los Emiratos Árabes Unidos", false },
                    { "AFN", "Afgani", false },
                    { "ALL", "Lek", false },
                    { "AMD", "Dram armenio", false },
                    { "ANG", "Florín antillano neerlandés", false },
                    { "AOA", "Kwanza", false },
                    { "ARS", "Peso argentino", false },
                    { "AUD", "Dólar australiano", false },
                    { "AWG", "Florín arubeño", false },
                    { "AZN", "Manat azerbaiyano", false },
                    { "BAM", "Marco convertible", false },
                    { "BBD", "Dólar de Barbados", false },
                    { "BDT", "Taka", false },
                    { "BGN", "Lev búlgaro", false },
                    { "BHD", "Dinar bareiní", false },
                    { "BIF", "Franco de Burundi", false },
                    { "BMD", "Dólar bermudeño", false },
                    { "BND", "Dólar de Brunéi", false },
                    { "BOB", "Boliviano", false },
                    { "BRL", "Real brasileño", false },
                    { "DOP", "Peso dominicano", false },
                    { "DKK", "Corona danesa", false },
                    { "EGP", "Libra egipcia", false },
                    { "ISK", "Corona islandesa", false },
                    { "JMD", "Dólar jamaiquino", false },
                    { "JOD", "Dinar jordano", false },
                    { "JPY", "Yen", false },
                    { "KES", "Chelín keniano", false },
                    { "KGS", "Som", false },
                    { "KHR", "Riel", false },
                    { "KMF", "Franco comorense", false },
                    { "KPW", "Won norcoreano", false },
                    { "KRW", "Won", false },
                    { "KWD", "Dinar kuwaití", false },
                    { "KYD", "Dólar de las Islas Caimán", false },
                    { "KZT", "Tenge", false },
                    { "LAK", "Kip", false },
                    { "LBP", "Libra libanesa", false },
                    { "LKR", "Rupia de Sri Lanka", false },
                    { "LRD", "Dólar liberiano", false },
                    { "LSL", "Loti", false },
                    { "LYD", "Dinar libio", false },
                    { "DZD", "Dinar argelino", false },
                    { "IQD", "Dinar iraquí", false },
                    { "IRR", "Rial iraní", false },
                    { "ILS", "Nuevo shéquel israelí", false },
                    { "ERN", "Nakfa", false },
                    { "ETB", "Birr etíope", false },
                    { "EUR", "Euro", true },
                    { "FJD", "Dólar fiyiano", false },
                    { "FKP", "Libra malvinense", false },
                    { "GBP", "Libra esterlina", false },
                    { "GEL", "Lari", false },
                    { "GHS", "Cedi ghanés", false },
                    { "INR", "Rupia india", false },
                    { "GIP", "Libra de Gibraltar", false },
                    { "GNF", "Franco guineano", false },
                    { "GTQ", "Quetzal", false },
                    { "HKD", "Dólar de Hong Kong", false },
                    { "HNL", "Lempira", false },
                    { "HRK", "Kuna", false },
                    { "HTG", "Gourde", false },
                    { "HUF", "Forinto", false },
                    { "IDR", "Rupia indonesia", false },
                    { "GMD", "Dalasi", false }
                });

            migrationBuilder.InsertData(
                table: "tipo_rol",
                columns: new[] { "id_tipo_roles", "nombre_rol" },
                values: new object[,]
                {
                    { (short)3, "admin" },
                    { (short)1, "cliente" },
                    { (short)2, "proveedor" },
                    { (short)4, "userivm" }
                });

            migrationBuilder.InsertData(
                table: "empresas",
                columns: new[] { "ruc_empresa", "activo", "con_pedido", "correo", "domicilio_fiscal", "habido", "id_tipo_empresa_erp", "logo", "razon_social", "sin_pedido", "telefono", "tipo_tolerancia", "tolerancia" },
                values: new object[,]
                {
                    { "10467765219", true, true, new[] { "algun_correo1@gmail.com", "algun_correo2@gmail.com", "algun_correo3@gmail.com", "algun_correo4@gmail.com" }, "calle hipolito bernandette 129 barranco", true, (short)1, null, "cesar Nicolini Rivero", false, new[] { "96875999", "87548965" }, (short)1, 0m },
                    { "20444444449", true, false, new[] { "algun_correo1@gmail.com", "algun_correo2@gmail.com", "algun_correo3@gmail.com", "algun_correo4@gmail.com" }, "los pintores 456 - Villa Creatividad", true, (short)1, "20444444449.jpg", "Los creativos SAC", true, new[] { "96875999", "87548965" }, (short)1, 0m },
                    { "20555555559", true, true, new[] { "algun_correo1@gmail.com", "algun_correo2@gmail.com", "algun_correo3@gmail.com", "algun_correo4@gmail.com" }, "Los negocios del Sur 147 - San Isidro", true, (short)1, "20555555559.jpg", "Los negociantes del Perú", false, new[] { "96875999", "87548965" }, (short)2, 0m },
                    { "20777777779", true, true, new[] { "algun_correo1@gmail.com", "algun_correo2@gmail.com", "algun_correo3@gmail.com", "algun_correo4@gmail.com" }, "La Agraria 234 - La Molina", true, (short)1, "20777777779.png", "La Fuerza Agraria", true, new[] { "96875999", "87548965" }, (short)1, 0.05m },
                    { "20999999999", true, false, new[] { "algun_correo1@gmail.com", "algun_correo2@gmail.com", "algun_correo3@gmail.com", "algun_correo4@gmail.com" }, "Calle Villa de Jesús 345 - Jesús Maria", true, (short)1, "20999999999.png", "Las Monjitas caritativas", true, new[] { "96875999", "87548965" }, (short)1, 0m },
                    { "20000000009", true, true, new[] { "algun_correo1@gmail.com", "algun_correo2@gmail.com", "algun_correo3@gmail.com", "algun_correo4@gmail.com" }, "Steve Jobs 763 - Barranco", true, (short)1, "20000000009.jpg", "Los Seguidores de Jobs", false, new[] { "96875999", "87548965" }, (short)1, 0m },
                    { "20111111119", true, false, new[] { "algun_correo1@gmail.com", "algun_correo2@gmail.com", "algun_correo3@gmail.com", "algun_correo4@gmail.com" }, "Calle Olenka Kocchiu 369 - Surco", true, (short)2, "20111111119.png", "Las Bellezas", false, new[] { "96875999", "87548965" }, (short)2, 0m },
                    { "20333333339", true, false, new[] { "algun_correo1@gmail.com", "algun_correo2@gmail.com", "algun_correo3@gmail.com", "algun_correo4@gmail.com" }, "Calle los poderosos 8080 - Callao", true, (short)2, "20333333339.jpg", "Empresa fuerte 3", false, new[] { "96875999", "87548965" }, (short)1, 0m },
                    { "20666666669", true, false, new[] { "algun_correo1@gmail.com", "algun_correo2@gmail.com", "algun_correo3@gmail.com", "algun_correo4@gmail.com" }, "Calle Venta Casual 345 - San Miguel", true, (short)2, "20666666669.jpg", "Los vendedores", true, new[] { "96875999", "87548965" }, (short)1, 0m },
                    { "20888888889", true, true, new[] { "algun_correo1@gmail.com", "algun_correo2@gmail.com", "algun_correo3@gmail.com", "algun_correo4@gmail.com" }, "Los Destructores 147 - SMP", true, (short)2, "20888888889.jpg", "Rompe Casas SRL", true, new[] { "96875999", "87548965" }, (short)1, 0m },
                    { "20222222229", true, true, new[] { "algun_correo1@gmail.com", "algun_correo2@gmail.com", "algun_correo3@gmail.com", "algun_correo4@gmail.com" }, "Dirección bonita 147 - Bellavista", true, (short)3, "20222222229.png", "Empresa feliz 2", false, new[] { "96875999", "87548965" }, (short)1, 0m }
                });

            migrationBuilder.InsertData(
                table: "ordenes_compra",
                columns: new[] { "ruc_empresa_cliente", "id_orden_compra", "activa", "competado", "id_tipo_moneda", "monto_acumulado", "monto_orden_compra", "ruc_empresa_proveedor" },
                values: new object[,]
                {
                    { "20333333339", "OC-00079", true, false, "PEN", 0m, 583m, "20444444449" },
                    { "20000000009", "OC-00095", true, false, "PEN", 0m, 210m, "20666666669" },
                    { "20000000009", "OC-00096", true, false, "PEN", 0m, 226m, "20666666669" },
                    { "20000000009", "OC-00097", true, false, "PEN", 0m, 506m, "20666666669" },
                    { "20000000009", "OC-00098", true, false, "PEN", 0m, 620m, "20666666669" },
                    { "20000000009", "OC-00099", true, false, "PEN", 0m, 607m, "20666666669" },
                    { "20000000009", "OC-00100", true, false, "PEN", 0m, 100m, "20666666669" },
                    { "20333333339", "OC-00101", true, false, "PEN", 0m, 383m, "20666666669" },
                    { "20333333339", "OC-00102", true, false, "PEN", 0m, 347m, "20666666669" },
                    { "20333333339", "OC-00103", true, false, "PEN", 0m, 40m, "20666666669" },
                    { "20000000009", "OC-00094", true, false, "PEN", 0m, 842m, "20666666669" },
                    { "20333333339", "OC-00104", true, false, "PEN", 0m, 890m, "20666666669" },
                    { "20999999999", "OC-00106", true, false, "PEN", 0m, 931m, "20666666669" },
                    { "20999999999", "OC-00107", true, false, "PEN", 0m, 251m, "20666666669" },
                    { "20222222229", "OC-00066", true, false, "PEN", 0m, 200m, "20444444449" },
                    { "20222222229", "OC-00065", true, false, "PEN", 0m, 88m, "20444444449" },
                    { "20000000009", "OC-00108", true, false, "PEN", 0m, 44m, "20888888889" },
                    { "20000000009", "OC-00109", true, false, "PEN", 0m, 814m, "20888888889" },
                    { "20000000009", "OC-00110", true, false, "PEN", 0m, 470m, "20888888889" },
                    { "20000000009", "OC-00111", true, false, "PEN", 0m, 546m, "20888888889" },
                    { "20000000009", "OC-00112", true, false, "PEN", 0m, 377m, "20888888889" },
                    { "20333333339", "OC-00105", true, false, "PEN", 0m, 494m, "20666666669" },
                    { "20666666669", "OC-00062", true, false, "PEN", 0m, 213m, "20333333339" },
                    { "20666666669", "OC-00061", true, false, "PEN", 0m, 343m, "20333333339" },
                    { "20666666669", "OC-00060", true, false, "PEN", 0m, 540m, "20333333339" },
                    { "20333333339", "OC-00073", true, false, "PEN", 0m, 792m, "20444444449" },
                    { "20333333339", "OC-00074", true, false, "PEN", 0m, 806m, "20444444449" },
                    { "20333333339", "OC-00075", true, false, "PEN", 0m, 608m, "20444444449" },
                    { "20333333339", "OC-00076", true, false, "PEN", 0m, 356m, "20444444449" },
                    { "20333333339", "OC-00077", true, false, "PEN", 0m, 586m, "20444444449" },
                    { "20333333339", "OC-00078", true, false, "PEN", 0m, 661m, "20444444449" },
                    { "20777777779", "OC-00031", true, false, "PEN", 0m, 833m, "20222222229" },
                    { "20333333339", "OC-00164", true, false, "PEN", 0m, 76m, "20999999999" },
                    { "20333333339", "OC-00165", true, false, "PEN", 0m, 623m, "20999999999" },
                    { "20333333339", "OC-00166", true, false, "PEN", 0m, 462m, "20999999999" },
                    { "20333333339", "OC-00172", true, false, "PEN", 0m, 0m, "20999999999" },
                    { "20333333339", "OC-00173", true, false, "PEN", 0m, 0m, "20999999999" },
                    { "20333333339", "OC-00174", true, false, "PEN", 0m, 0m, "20999999999" },
                    { "20333333339", "OC-00175", true, false, "PEN", 0m, 0m, "20999999999" },
                    { "20222222229", "OC-00070", true, false, "PEN", 0m, 834m, "20444444449" },
                    { "20222222229", "OC-00069", true, false, "PEN", 0m, 286m, "20444444449" },
                    { "20222222229", "OC-00068", true, false, "PEN", 0m, 460m, "20444444449" },
                    { "20222222229", "OC-00067", true, false, "PEN", 0m, 634m, "20444444449" },
                    { "20666666669", "OC-00057", true, false, "PEN", 0m, 903m, "20333333339" },
                    { "20666666669", "OC-00058", true, false, "PEN", 0m, 988m, "20333333339" },
                    { "20666666669", "OC-00059", true, false, "PEN", 0m, 262m, "20333333339" },
                    { "20000000009", "OC-00113", true, false, "PEN", 0m, 147m, "20888888889" },
                    { "20111111119", "OC-00114", true, false, "PEN", 0m, 220m, "20888888889" },
                    { "20111111119", "OC-00115", true, false, "PEN", 0m, 210m, "20888888889" },
                    { "20111111119", "OC-00116", true, false, "PEN", 0m, 323m, "20888888889" },
                    { "20666666669", "OC-00147", true, false, "PEN", 0m, 688m, "20888888889" },
                    { "20666666669", "OC-00148", true, false, "PEN", 0m, 179m, "20888888889" },
                    { "20666666669", "OC-00149", true, false, "PEN", 0m, 175m, "20888888889" },
                    { "20999999999", "OC-00150", true, false, "PEN", 0m, 695m, "20888888889" },
                    { "20999999999", "OC-00151", true, false, "PEN", 0m, 885m, "20888888889" },
                    { "20999999999", "OC-00152", true, false, "PEN", 0m, 127m, "20888888889" },
                    { "20999999999", "OC-00153", true, false, "PEN", 0m, 150m, "20888888889" },
                    { "20999999999", "OC-00154", true, false, "PEN", 0m, 270m, "20888888889" },
                    { "20999999999", "OC-00155", true, false, "PEN", 0m, 32m, "20888888889" },
                    { "20999999999", "OC-00156", true, false, "PEN", 0m, 324m, "20888888889" },
                    { "20999999999", "OC-00157", true, false, "PEN", 0m, 902m, "20888888889" },
                    { "20777777779", "OC-00033", true, false, "PEN", 0m, 776m, "20222222229" },
                    { "20000000009", "OC-00022", true, false, "PEN", 0m, 500m, "20222222229" },
                    { "20000000009", "OC-00023", true, false, "PEN", 0m, 884m, "20222222229" },
                    { "20000000009", "OC-00024", true, false, "PEN", 0m, 572m, "20222222229" },
                    { "20111111119", "OC-00025", true, false, "PEN", 0m, 819m, "20222222229" },
                    { "20111111119", "OC-00026", true, false, "PEN", 0m, 727m, "20222222229" },
                    { "20111111119", "OC-00027", true, false, "PEN", 0m, 896m, "20222222229" },
                    { "20777777779", "OC-00028", true, false, "PEN", 0m, 774m, "20222222229" },
                    { "20777777779", "OC-00029", true, false, "PEN", 0m, 667m, "20222222229" },
                    { "20777777779", "OC-00030", true, false, "PEN", 0m, 914m, "20222222229" },
                    { "20666666669", "OC-00146", true, false, "PEN", 0m, 689m, "20888888889" },
                    { "20333333339", "OC-00072", true, false, "PEN", 0m, 397m, "20444444449" },
                    { "20666666669", "OC-00145", true, false, "PEN", 0m, 1000m, "20888888889" },
                    { "20666666669", "OC-00143", true, false, "PEN", 0m, 44m, "20888888889" },
                    { "20111111119", "OC-00117", true, false, "PEN", 0m, 424m, "20888888889" },
                    { "20333333339", "OC-00123", true, false, "PEN", 0m, 71m, "20888888889" },
                    { "20333333339", "OC-00124", true, false, "PEN", 0m, 624m, "20888888889" },
                    { "20333333339", "OC-00125", true, false, "PEN", 0m, 502m, "20888888889" },
                    { "20333333339", "OC-00126", true, false, "PEN", 0m, 688m, "20888888889" },
                    { "20333333339", "OC-00127", true, false, "PEN", 0m, 352m, "20888888889" },
                    { "20333333339", "OC-00128", true, false, "PEN", 0m, 633m, "20888888889" },
                    { "20333333339", "OC-00129", true, false, "PEN", 0m, 161m, "20888888889" },
                    { "20333333339", "OC-00130", true, false, "PEN", 0m, 907m, "20888888889" },
                    { "20333333339", "OC-00131", true, false, "PEN", 0m, 370m, "20888888889" },
                    { "20333333339", "OC-00132", true, false, "PEN", 0m, 815m, "20888888889" },
                    { "20444444449", "OC-00133", true, false, "PEN", 0m, 499m, "20888888889" },
                    { "20444444449", "OC-00134", true, false, "PEN", 0m, 34m, "20888888889" },
                    { "20444444449", "OC-00135", true, false, "PEN", 0m, 748m, "20888888889" },
                    { "20444444449", "OC-00136", true, false, "PEN", 0m, 841m, "20888888889" },
                    { "20444444449", "OC-00137", true, false, "PEN", 0m, 295m, "20888888889" },
                    { "20444444449", "OC-00138", true, false, "PEN", 0m, 421m, "20888888889" },
                    { "20444444449", "OC-00139", true, false, "PEN", 0m, 514m, "20888888889" },
                    { "20555555559", "OC-00140", true, false, "PEN", 0m, 666m, "20888888889" },
                    { "20666666669", "OC-00141", true, false, "PEN", 0m, 93m, "20888888889" },
                    { "20666666669", "OC-00142", true, false, "PEN", 0m, 780m, "20888888889" },
                    { "20666666669", "OC-00144", true, false, "PEN", 0m, 966m, "20888888889" },
                    { "20777777779", "OC-00063", true, false, "PEN", 0m, 129m, "20333333339" },
                    { "20777777779", "OC-00032", true, false, "PEN", 0m, 778m, "20222222229" },
                    { "20555555559", "OC-00055", true, false, "PEN", 0m, 228m, "20333333339" },
                    { "20444444449", "OC-00182", true, false, "PEN", 0m, 0m, "20999999999" },
                    { "20222222229", "OC-00163", true, false, "PEN", 0m, 104m, "20999999999" },
                    { "20222222229", "OC-00122", true, false, "PEN", 0m, 769m, "20888888889" },
                    { "20000000009", "OC-00158", true, false, "PEN", 0m, 701m, "20999999999" },
                    { "20000000009", "OC-00159", true, false, "PEN", 0m, 831m, "20999999999" },
                    { "20000000009", "OC-00160", true, false, "PEN", 0m, 87m, "20999999999" },
                    { "20000000009", "OC-00161", true, false, "PEN", 0m, 818m, "20999999999" },
                    { "20000000009", "OC-00162", true, false, "PEN", 0m, 813m, "20999999999" },
                    { "20222222229", "OC-00121", true, false, "PEN", 0m, 573m, "20888888889" },
                    { "20444444449", "OC-00181", true, false, "PEN", 0m, 0m, "20999999999" },
                    { "20000000009", "OC-00001", true, false, "PEN", 0m, 405m, "20111111119" },
                    { "20000000009", "OC-00003", true, false, "PEN", 0m, 574m, "20111111119" },
                    { "20000000009", "OC-00004", true, false, "PEN", 0m, 445m, "20111111119" },
                    { "20000000009", "OC-00005", true, false, "PEN", 0m, 46m, "20111111119" },
                    { "20555555559", "OC-00056", true, false, "PEN", 0m, 275m, "20333333339" },
                    { "20000000009", "OC-00007", true, false, "PEN", 0m, 363m, "20111111119" },
                    { "20444444449", "OC-00011", true, false, "PEN", 0m, 156m, "20111111119" },
                    { "20444444449", "OC-00012", true, false, "PEN", 0m, 971m, "20111111119" },
                    { "20444444449", "OC-00013", true, false, "PEN", 0m, 275m, "20111111119" },
                    { "20444444449", "OC-00014", true, false, "PEN", 0m, 59m, "20111111119" },
                    { "20000000009", "OC-00002", true, false, "PEN", 0m, 756m, "20111111119" },
                    { "20444444449", "OC-00180", true, false, "PEN", 0m, 0m, "20999999999" },
                    { "20444444449", "OC-00179", true, false, "PEN", 0m, 0m, "20999999999" },
                    { "20444444449", "OC-00178", true, false, "PEN", 0m, 0m, "20999999999" },
                    { "20555555559", "OC-00080", true, false, "PEN", 0m, 840m, "20444444449" },
                    { "20555555559", "OC-00081", true, false, "PEN", 0m, 59m, "20444444449" },
                    { "20555555559", "OC-00082", true, false, "PEN", 0m, 151m, "20444444449" },
                    { "20555555559", "OC-00083", true, false, "PEN", 0m, 316m, "20444444449" },
                    { "20555555559", "OC-00084", true, false, "PEN", 0m, 436m, "20444444449" },
                    { "20555555559", "OC-00085", true, false, "PEN", 0m, 423m, "20444444449" },
                    { "20555555559", "OC-00086", true, false, "PEN", 0m, 856m, "20444444449" },
                    { "20777777779", "OC-00087", true, false, "PEN", 0m, 897m, "20444444449" },
                    { "20777777779", "OC-00088", true, false, "PEN", 0m, 240m, "20444444449" },
                    { "20777777779", "OC-00089", true, false, "PEN", 0m, 53m, "20444444449" },
                    { "20777777779", "OC-00090", true, false, "PEN", 0m, 780m, "20444444449" },
                    { "20777777779", "OC-00091", true, false, "PEN", 0m, 37m, "20444444449" },
                    { "20777777779", "OC-00092", true, false, "PEN", 0m, 136m, "20444444449" },
                    { "20777777779", "OC-00093", true, false, "PEN", 0m, 669m, "20444444449" },
                    { "20444444449", "OC-00167", true, false, "PEN", 0m, 193m, "20999999999" },
                    { "20444444449", "OC-00168", true, false, "PEN", 0m, 298m, "20999999999" },
                    { "20444444449", "OC-00169", true, false, "PEN", 0m, 607m, "20999999999" },
                    { "20444444449", "OC-00170", true, false, "PEN", 0m, 247m, "20999999999" },
                    { "20444444449", "OC-00171", true, false, "PEN", 0m, 313m, "20999999999" },
                    { "20444444449", "OC-00176", true, false, "PEN", 0m, 0m, "20999999999" },
                    { "20444444449", "OC-00177", true, false, "PEN", 0m, 0m, "20999999999" },
                    { "20777777779", "OC-00015", true, false, "PEN", 0m, 710m, "20111111119" },
                    { "20999999999", "OC-00016", true, false, "PEN", 0m, 790m, "20111111119" },
                    { "20000000009", "OC-00006", true, false, "PEN", 0m, 39m, "20111111119" },
                    { "20111111119", "OC-00034", true, false, "PEN", 0m, 738m, "20333333339" },
                    { "20333333339", "OC-00010", true, false, "PEN", 0m, 180m, "20111111119" },
                    { "20444444449", "OC-00047", true, false, "PEN", 0m, 79m, "20333333339" },
                    { "20555555559", "OC-00050", true, false, "PEN", 0m, 810m, "20333333339" },
                    { "20111111119", "OC-00035", true, false, "PEN", 0m, 565m, "20333333339" },
                    { "20111111119", "OC-00036", true, false, "PEN", 0m, 165m, "20333333339" },
                    { "20111111119", "OC-00037", true, false, "PEN", 0m, 312m, "20333333339" },
                    { "20111111119", "OC-00038", true, false, "PEN", 0m, 468m, "20333333339" },
                    { "20333333339", "OC-00009", true, false, "PEN", 0m, 631m, "20111111119" },
                    { "20444444449", "OC-00049", true, false, "PEN", 0m, 579m, "20333333339" },
                    { "20111111119", "OC-00040", true, false, "PEN", 0m, 866m, "20333333339" },
                    { "20111111119", "OC-00041", true, false, "PEN", 0m, 384m, "20333333339" },
                    { "20444444449", "OC-00042", true, false, "PEN", 0m, 503m, "20333333339" },
                    { "20444444449", "OC-00043", true, false, "PEN", 0m, 984m, "20333333339" },
                    { "20444444449", "OC-00044", true, false, "PEN", 0m, 447m, "20333333339" },
                    { "20444444449", "OC-00045", true, false, "PEN", 0m, 779m, "20333333339" },
                    { "20444444449", "OC-00046", true, false, "PEN", 0m, 309m, "20333333339" },
                    { "20111111119", "OC-00039", true, false, "PEN", 0m, 894m, "20333333339" },
                    { "20333333339", "OC-00008", true, false, "PEN", 0m, 365m, "20111111119" },
                    { "20444444449", "OC-00048", true, false, "PEN", 0m, 880m, "20333333339" },
                    { "20222222229", "OC-00118", true, false, "PEN", 0m, 118m, "20888888889" },
                    { "20222222229", "OC-00119", true, false, "PEN", 0m, 436m, "20888888889" },
                    { "20555555559", "OC-00051", true, false, "PEN", 0m, 768m, "20333333339" },
                    { "20222222229", "OC-00120", true, false, "PEN", 0m, 825m, "20888888889" },
                    { "20555555559", "OC-00052", true, false, "PEN", 0m, 924m, "20333333339" },
                    { "20555555559", "OC-00053", true, false, "PEN", 0m, 50m, "20333333339" },
                    { "20555555559", "OC-00054", true, false, "PEN", 0m, 825m, "20333333339" },
                    { "20999999999", "OC-00020", true, false, "PEN", 0m, 463m, "20111111119" },
                    { "20999999999", "OC-00021", true, false, "PEN", 0m, 913m, "20111111119" },
                    { "20999999999", "OC-00017", true, false, "PEN", 0m, 870m, "20111111119" },
                    { "20999999999", "OC-00018", true, false, "PEN", 0m, 984m, "20111111119" },
                    { "20111111119", "OC-00064", true, false, "PEN", 0m, 586m, "20444444449" },
                    { "20222222229", "OC-00071", true, false, "PEN", 0m, 307m, "20444444449" },
                    { "20999999999", "OC-00019", true, false, "PEN", 0m, 271m, "20111111119" }
                });

            migrationBuilder.InsertData(
                table: "ti_empresa_empresa",
                columns: new[] { "ruc_empresa_cliente", "ruc_empresa_proveedor", "activo" },
                values: new object[,]
                {
                    { "20222222229", "20888888889", true },
                    { "20222222229", "20999999999", true },
                    { "20000000009", "20888888889", true },
                    { "20555555559", "20888888889", true },
                    { "20333333339", "20888888889", true },
                    { "20444444449", "20888888889", true },
                    { "20666666669", "20888888889", true },
                    { "20999999999", "20888888889", true },
                    { "20222222229", "20444444449", true },
                    { "20777777779", "20222222229", true },
                    { "20111111119", "20888888889", true },
                    { "20999999999", "20666666669", true },
                    { "20111111119", "20333333339", true },
                    { "20111111119", "20222222229", true },
                    { "20000000009", "20666666669", true },
                    { "20666666669", "20333333339", true },
                    { "20000000009", "20111111119", true },
                    { "20444444449", "20111111119", true },
                    { "20777777779", "20111111119", true },
                    { "20999999999", "20111111119", true },
                    { "20111111119", "20444444449", true },
                    { "20000000009", "20999999999", true },
                    { "20444444449", "20999999999", true },
                    { "20333333339", "20999999999", true },
                    { "20333333339", "20444444449", true },
                    { "20777777779", "20333333339", true },
                    { "20444444449", "20333333339", true },
                    { "20333333339", "20666666669", true },
                    { "20333333339", "20111111119", true },
                    { "20000000009", "20222222229", true },
                    { "20777777779", "20444444449", true },
                    { "20555555559", "20444444449", true },
                    { "20555555559", "20333333339", true }
                });

            migrationBuilder.InsertData(
                table: "ti_roles_empresas",
                columns: new[] { "ruc_empresa", "id_tipo_roles" },
                values: new object[,]
                {
                    { "10467765219", (short)2 },
                    { "20666666669", (short)2 },
                    { "10467765219", (short)1 },
                    { "20444444449", (short)1 },
                    { "20444444449", (short)2 },
                    { "20555555559", (short)1 },
                    { "20777777779", (short)1 },
                    { "20999999999", (short)1 },
                    { "20999999999", (short)2 },
                    { "20888888889", (short)2 },
                    { "20000000009", (short)1 },
                    { "20111111119", (short)2 },
                    { "20222222229", (short)1 },
                    { "20333333339", (short)1 },
                    { "20333333339", (short)2 },
                    { "20666666669", (short)1 },
                    { "20111111119", (short)1 },
                    { "20222222229", (short)2 }
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "username", "correo", "id_persona", "password", "per_emp", "ruc_empresa", "telefono" },
                values: new object[,]
                {
                    { "cesar", new[] { "Element 1" }, 0, "123456", true, "20111111119", new[] { "4774267", "959863830" } },
                    { "20111111119", new[] { "adminitrativo@las_bellezas.com" }, 0, "123456", true, "20111111119", new[] { "4774267", "959863830" } },
                    { "20444444449", new[] { "adminitrativo@fuerza_agraria.com" }, 0, "123456", true, "20444444449", new[] { "4774267", "959863830" } },
                    { "20333333339", new[] { "adminitrativo@los_negocios.com" }, 0, "123456", true, "20333333339", new[] { "4774267", "959863830" } }
                });

            migrationBuilder.InsertData(
                table: "ti_usuario_roles",
                columns: new[] { "username", "id_tipo_roles" },
                values: new object[,]
                {
                    { "cesar", (short)1 },
                    { "cesar", (short)2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_documento_id_tipo_detracciones",
                table: "documento",
                column: "id_tipo_detracciones");

            migrationBuilder.CreateIndex(
                name: "IX_documento_id_tipo_documento",
                table: "documento",
                column: "id_tipo_documento");

            migrationBuilder.CreateIndex(
                name: "IX_documento_id_tipo_documento_estado",
                table: "documento",
                column: "id_tipo_documento_estado");

            migrationBuilder.CreateIndex(
                name: "IX_documento_id_tipo_moneda",
                table: "documento",
                column: "id_tipo_moneda");

            migrationBuilder.CreateIndex(
                name: "IX_documento_ruc_empresa_cliente_id_orden_compra",
                table: "documento",
                columns: new[] { "ruc_empresa_cliente", "id_orden_compra" });

            migrationBuilder.CreateIndex(
                name: "IX_empresas_id_tipo_empresa_erp",
                table: "empresas",
                column: "id_tipo_empresa_erp");

            migrationBuilder.CreateIndex(
                name: "IX_ordenes_compra_id_tipo_moneda",
                table: "ordenes_compra",
                column: "id_tipo_moneda");

            migrationBuilder.CreateIndex(
                name: "IX_ordenes_compra_ruc_empresa_proveedor",
                table: "ordenes_compra",
                column: "ruc_empresa_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_ti_empresa_empresa_ruc_empresa_proveedor",
                table: "ti_empresa_empresa",
                column: "ruc_empresa_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_ti_roles_empresas_id_tipo_roles",
                table: "ti_roles_empresas",
                column: "id_tipo_roles");

            migrationBuilder.CreateIndex(
                name: "IX_ti_usuario_roles_id_tipo_roles",
                table: "ti_usuario_roles",
                column: "id_tipo_roles");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_ruc_empresa",
                table: "usuarios",
                column: "ruc_empresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "auditorias");

            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "documento");

            migrationBuilder.DropTable(
                name: "facturas");

            migrationBuilder.DropTable(
                name: "ti_empresa_empresa");

            migrationBuilder.DropTable(
                name: "ti_roles_empresas");

            migrationBuilder.DropTable(
                name: "ti_usuario_roles");

            migrationBuilder.DropTable(
                name: "tipo_documento_devolucion");

            migrationBuilder.DropTable(
                name: "tipo_impuesto");

            migrationBuilder.DropTable(
                name: "tipo_detracciones");

            migrationBuilder.DropTable(
                name: "tipo_documento");

            migrationBuilder.DropTable(
                name: "tipo_documento_estado");

            migrationBuilder.DropTable(
                name: "ordenes_compra");

            migrationBuilder.DropTable(
                name: "tipo_rol");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "tipo_moneda");

            migrationBuilder.DropTable(
                name: "empresas");

            migrationBuilder.DropTable(
                name: "tipo_empresa_erp");
        }
    }
}
