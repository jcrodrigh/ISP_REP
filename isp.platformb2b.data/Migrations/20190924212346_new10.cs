using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace isp.platformb2b.data.Migrations
{
    public partial class new10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "documento_errores",
                columns: table => new
                {
                    id_documento_errores = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    documento = table.Column<string>(type: "varchar(1000)", nullable: true),
                    errores = table.Column<string>(type: "varchar(10000)", nullable: true),
                    ultima_modificacion = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    usuario_modificacion = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documento_errores", x => x.id_documento_errores);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "documento_errores");
        }
    }
}
