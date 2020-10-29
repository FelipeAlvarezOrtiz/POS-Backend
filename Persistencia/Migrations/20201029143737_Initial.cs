using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    IdBanco = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreBanco = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.IdBanco);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(maxLength: 80, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Comunas",
                columns: table => new
                {
                    IdComuna = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreComuna = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunas", x => x.IdComuna);
                });

            migrationBuilder.CreateTable(
                name: "Medidas",
                columns: table => new
                {
                    IdMedida = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMedida = table.Column<string>(maxLength: 60, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medidas", x => x.IdMedida);
                });

            migrationBuilder.CreateTable(
                name: "Regiones",
                columns: table => new
                {
                    IdRegion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRegion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.IdRegion);
                });

            migrationBuilder.CreateTable(
                name: "Sectores",
                columns: table => new
                {
                    IdSector = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSector = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectores", x => x.IdSector);
                });

            migrationBuilder.CreateTable(
                name: "TipoCuentas",
                columns: table => new
                {
                    IdTipoCuenta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoCuenta = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCuentas", x => x.IdTipoCuenta);
                });

            migrationBuilder.CreateTable(
                name: "TipoPagos",
                columns: table => new
                {
                    IdTipoPago = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoPago = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPagos", x => x.IdTipoPago);
                });

            migrationBuilder.CreateTable(
                name: "TipoProveedores",
                columns: table => new
                {
                    IdTipoProveedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoProveedor = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProveedores", x => x.IdTipoProveedor);
                });

            migrationBuilder.CreateTable(
                name: "TipoTiendas",
                columns: table => new
                {
                    IdTipoTienda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTienda = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTiendas", x => x.IdTipoTienda);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RutCliente = table.Column<int>(nullable: false),
                    NombreCliente = table.Column<string>(maxLength: 100, nullable: false),
                    DireccionCliente = table.Column<string>(maxLength: 150, nullable: true),
                    IdRegion = table.Column<int>(nullable: false),
                    RegionIdRegion = table.Column<int>(nullable: true),
                    IdComuna = table.Column<int>(nullable: false),
                    ComunaIdComuna = table.Column<int>(nullable: true),
                    IdSector = table.Column<int>(nullable: false),
                    SectorIdSector = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Comunas_ComunaIdComuna",
                        column: x => x.ComunaIdComuna,
                        principalTable: "Comunas",
                        principalColumn: "IdComuna",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_Regiones_RegionIdRegion",
                        column: x => x.RegionIdRegion,
                        principalTable: "Regiones",
                        principalColumn: "IdRegion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_Sectores_SectorIdSector",
                        column: x => x.SectorIdSector,
                        principalTable: "Sectores",
                        principalColumn: "IdSector",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProveedor = table.Column<string>(maxLength: 100, nullable: false),
                    RutProveedor = table.Column<string>(maxLength: 9, nullable: false),
                    Ubicacion = table.Column<string>(maxLength: 150, nullable: true),
                    DiaFacturacion = table.Column<int>(nullable: false),
                    NumeroCuenta = table.Column<string>(nullable: false),
                    TipoProveedorIdTipoProveedor = table.Column<int>(nullable: false),
                    BancoIdBanco = table.Column<int>(nullable: false),
                    TipoPagoIdTipoPago = table.Column<int>(nullable: false),
                    TipoCuentaIdTipoCuenta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.IdProveedor);
                    table.ForeignKey(
                        name: "FK_Proveedores_Bancos_BancoIdBanco",
                        column: x => x.BancoIdBanco,
                        principalTable: "Bancos",
                        principalColumn: "IdBanco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proveedores_TipoCuentas_TipoCuentaIdTipoCuenta",
                        column: x => x.TipoCuentaIdTipoCuenta,
                        principalTable: "TipoCuentas",
                        principalColumn: "IdTipoCuenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proveedores_TipoPagos_TipoPagoIdTipoPago",
                        column: x => x.TipoPagoIdTipoPago,
                        principalTable: "TipoPagos",
                        principalColumn: "IdTipoPago",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proveedores_TipoProveedores_TipoProveedorIdTipoProveedor",
                        column: x => x.TipoProveedorIdTipoProveedor,
                        principalTable: "TipoProveedores",
                        principalColumn: "IdTipoProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tiendas",
                columns: table => new
                {
                    IdTienda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTienda = table.Column<string>(maxLength: 100, nullable: false),
                    IdTipoTienda = table.Column<int>(nullable: false),
                    TipoTiendaIdTipoTienda = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiendas", x => x.IdTienda);
                    table.ForeignKey(
                        name: "FK_Tiendas_TipoTiendas_TipoTiendaIdTipoTienda",
                        column: x => x.TipoTiendaIdTipoTienda,
                        principalTable: "TipoTiendas",
                        principalColumn: "IdTipoTienda",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactoProveedores",
                columns: table => new
                {
                    IdContacto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RutProveedor = table.Column<int>(nullable: false),
                    ProveedorIdProveedor = table.Column<int>(nullable: true),
                    CorreoProveedor = table.Column<string>(maxLength: 80, nullable: true),
                    TelefonoProveedor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactoProveedores", x => x.IdContacto);
                    table.ForeignKey(
                        name: "FK_ContactoProveedores_Proveedores_ProveedorIdProveedor",
                        column: x => x.ProveedorIdProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(maxLength: 100, nullable: false),
                    DescripcionProducto = table.Column<string>(maxLength: 350, nullable: true),
                    PrecioMayorista = table.Column<int>(nullable: false),
                    PrecioTotal = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    NombreBusqueda = table.Column<string>(nullable: true),
                    CategoriaIdCategoria = table.Column<int>(nullable: false),
                    MedidaIdMedida = table.Column<int>(nullable: false),
                    ProveedorIdProveedor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaIdCategoria",
                        column: x => x.CategoriaIdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Medidas_MedidaIdMedida",
                        column: x => x.MedidaIdMedida,
                        principalTable: "Medidas",
                        principalColumn: "IdMedida",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Proveedores_ProveedorIdProveedor",
                        column: x => x.ProveedorIdProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ComunaIdComuna",
                table: "Clientes",
                column: "ComunaIdComuna");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_RegionIdRegion",
                table: "Clientes",
                column: "RegionIdRegion");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_SectorIdSector",
                table: "Clientes",
                column: "SectorIdSector");

            migrationBuilder.CreateIndex(
                name: "IX_ContactoProveedores_ProveedorIdProveedor",
                table: "ContactoProveedores",
                column: "ProveedorIdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaIdCategoria",
                table: "Productos",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MedidaIdMedida",
                table: "Productos",
                column: "MedidaIdMedida");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ProveedorIdProveedor",
                table: "Productos",
                column: "ProveedorIdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_BancoIdBanco",
                table: "Proveedores",
                column: "BancoIdBanco");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_TipoCuentaIdTipoCuenta",
                table: "Proveedores",
                column: "TipoCuentaIdTipoCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_TipoPagoIdTipoPago",
                table: "Proveedores",
                column: "TipoPagoIdTipoPago");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_TipoProveedorIdTipoProveedor",
                table: "Proveedores",
                column: "TipoProveedorIdTipoProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Tiendas_TipoTiendaIdTipoTienda",
                table: "Tiendas",
                column: "TipoTiendaIdTipoTienda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "ContactoProveedores");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Tiendas");

            migrationBuilder.DropTable(
                name: "Comunas");

            migrationBuilder.DropTable(
                name: "Regiones");

            migrationBuilder.DropTable(
                name: "Sectores");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Medidas");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "TipoTiendas");

            migrationBuilder.DropTable(
                name: "Bancos");

            migrationBuilder.DropTable(
                name: "TipoCuentas");

            migrationBuilder.DropTable(
                name: "TipoPagos");

            migrationBuilder.DropTable(
                name: "TipoProveedores");
        }
    }
}
