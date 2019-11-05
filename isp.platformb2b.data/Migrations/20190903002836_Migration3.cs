using Microsoft.EntityFrameworkCore.Migrations;

namespace isp.platformb2b.data.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "conformidad",
                table: "documento");

            migrationBuilder.RenameColumn(
                name: "CECO",
                table: "documento",
                newName: "ceco");

            migrationBuilder.AddColumn<decimal>(
                name: "anticipo",
                table: "documento",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "factura_origen",
                table: "documento",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nombre_documento_excel",
                table: "documento",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "orden",
                table: "documento",
                type: "varchar (80)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "anticipo",
                table: "documento");

            migrationBuilder.DropColumn(
                name: "factura_origen",
                table: "documento");

            migrationBuilder.DropColumn(
                name: "nombre_documento_excel",
                table: "documento");

            migrationBuilder.DropColumn(
                name: "orden",
                table: "documento");

            migrationBuilder.RenameColumn(
                name: "ceco",
                table: "documento",
                newName: "CECO");

            migrationBuilder.AddColumn<bool>(
                name: "conformidad",
                table: "documento",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
