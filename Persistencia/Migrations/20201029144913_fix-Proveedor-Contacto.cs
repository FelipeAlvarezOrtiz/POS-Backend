using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class fixProveedorContacto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RutProveedor",
                table: "ContactoProveedores");

            migrationBuilder.AlterColumn<string>(
                name: "TelefonoProveedor",
                table: "ContactoProveedores",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TelefonoProveedor",
                table: "ContactoProveedores",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RutProveedor",
                table: "ContactoProveedores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
