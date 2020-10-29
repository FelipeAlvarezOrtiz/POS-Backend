﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

namespace Persistencia.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201029144540_fix-Proveedor")]
    partial class fixProveedor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Clientes.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ComunaIdComuna")
                        .HasColumnType("int");

                    b.Property<string>("DireccionCliente")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("IdComuna")
                        .HasColumnType("int");

                    b.Property<int>("IdRegion")
                        .HasColumnType("int");

                    b.Property<int>("IdSector")
                        .HasColumnType("int");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("RegionIdRegion")
                        .HasColumnType("int");

                    b.Property<int>("RutCliente")
                        .HasColumnType("int");

                    b.Property<int?>("SectorIdSector")
                        .HasColumnType("int");

                    b.HasKey("IdCliente");

                    b.HasIndex("ComunaIdComuna");

                    b.HasIndex("RegionIdRegion");

                    b.HasIndex("SectorIdSector");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Dominio.Clientes.Comuna", b =>
                {
                    b.Property<int>("IdComuna")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreComuna")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdComuna");

                    b.ToTable("Comunas");
                });

            modelBuilder.Entity("Dominio.Clientes.Region", b =>
                {
                    b.Property<int>("IdRegion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreRegion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRegion");

                    b.ToTable("Regiones");
                });

            modelBuilder.Entity("Dominio.Clientes.Sector", b =>
                {
                    b.Property<int>("IdSector")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreSector")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSector");

                    b.ToTable("Sectores");
                });

            modelBuilder.Entity("Dominio.Misc.Banco", b =>
                {
                    b.Property<int>("IdBanco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreBanco")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdBanco");

                    b.ToTable("Bancos");
                });

            modelBuilder.Entity("Dominio.Misc.TipoCuenta", b =>
                {
                    b.Property<int>("IdTipoCuenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreTipoCuenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdTipoCuenta");

                    b.ToTable("TipoCuentas");
                });

            modelBuilder.Entity("Dominio.Misc.TipoPago", b =>
                {
                    b.Property<int>("IdTipoPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreTipoPago")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("IdTipoPago");

                    b.ToTable("TipoPagos");
                });

            modelBuilder.Entity("Dominio.Productos.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("Date");

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Dominio.Productos.Medida", b =>
                {
                    b.Property<int>("IdMedida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("Date");

                    b.Property<string>("NombreMedida")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("IdMedida");

                    b.ToTable("Medidas");
                });

            modelBuilder.Entity("Dominio.Productos.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaIdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("DescripcionProducto")
                        .HasColumnType("nvarchar(350)")
                        .HasMaxLength(350);

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("MedidaIdMedida")
                        .HasColumnType("int");

                    b.Property<string>("NombreBusqueda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("PrecioMayorista")
                        .HasColumnType("int");

                    b.Property<int>("PrecioTotal")
                        .HasColumnType("int");

                    b.Property<int>("ProveedorIdProveedor")
                        .HasColumnType("int");

                    b.HasKey("IdProducto");

                    b.HasIndex("CategoriaIdCategoria");

                    b.HasIndex("MedidaIdMedida");

                    b.HasIndex("ProveedorIdProveedor");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Dominio.Proveedores.ContactoProveedor", b =>
                {
                    b.Property<int>("IdContacto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CorreoProveedor")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<int?>("ProveedorIdProveedor")
                        .HasColumnType("int");

                    b.Property<int>("RutProveedor")
                        .HasColumnType("int");

                    b.Property<int>("TelefonoProveedor")
                        .HasColumnType("int");

                    b.HasKey("IdContacto");

                    b.HasIndex("ProveedorIdProveedor");

                    b.ToTable("ContactoProveedores");
                });

            modelBuilder.Entity("Dominio.Proveedores.Proveedor", b =>
                {
                    b.Property<int>("IdProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BancoIdBanco")
                        .HasColumnType("int");

                    b.Property<int>("DiaFacturacion")
                        .HasColumnType("int");

                    b.Property<string>("NombreProveedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("NumeroCuenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RutProveedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<int>("TipoCuentaIdTipoCuenta")
                        .HasColumnType("int");

                    b.Property<int>("TipoPagoIdTipoPago")
                        .HasColumnType("int");

                    b.Property<int>("TipoProveedorIdTipoProveedor")
                        .HasColumnType("int");

                    b.Property<string>("Ubicacion")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("IdProveedor");

                    b.HasIndex("BancoIdBanco");

                    b.HasIndex("TipoCuentaIdTipoCuenta");

                    b.HasIndex("TipoPagoIdTipoPago");

                    b.HasIndex("TipoProveedorIdTipoProveedor");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("Dominio.Proveedores.TipoProveedor", b =>
                {
                    b.Property<int>("IdTipoProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreTipoProveedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdTipoProveedor");

                    b.ToTable("TipoProveedores");
                });

            modelBuilder.Entity("Dominio.Tiendas.Tiendas", b =>
                {
                    b.Property<int>("IdTienda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdTipoTienda")
                        .HasColumnType("int");

                    b.Property<string>("NombreTienda")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("TipoTiendaIdTipoTienda")
                        .HasColumnType("int");

                    b.HasKey("IdTienda");

                    b.HasIndex("TipoTiendaIdTipoTienda");

                    b.ToTable("Tiendas");
                });

            modelBuilder.Entity("Dominio.Tiendas.TipoTienda", b =>
                {
                    b.Property<int>("IdTipoTienda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreTienda")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdTipoTienda");

                    b.ToTable("TipoTiendas");
                });

            modelBuilder.Entity("Dominio.Clientes.Cliente", b =>
                {
                    b.HasOne("Dominio.Clientes.Comuna", "Comuna")
                        .WithMany()
                        .HasForeignKey("ComunaIdComuna");

                    b.HasOne("Dominio.Clientes.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionIdRegion");

                    b.HasOne("Dominio.Clientes.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorIdSector");
                });

            modelBuilder.Entity("Dominio.Productos.Producto", b =>
                {
                    b.HasOne("Dominio.Productos.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaIdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Productos.Medida", "Medida")
                        .WithMany()
                        .HasForeignKey("MedidaIdMedida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Proveedores.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("ProveedorIdProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Proveedores.ContactoProveedor", b =>
                {
                    b.HasOne("Dominio.Proveedores.Proveedor", "Proveedor")
                        .WithMany("Contacto")
                        .HasForeignKey("ProveedorIdProveedor");
                });

            modelBuilder.Entity("Dominio.Proveedores.Proveedor", b =>
                {
                    b.HasOne("Dominio.Misc.Banco", "Banco")
                        .WithMany()
                        .HasForeignKey("BancoIdBanco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Misc.TipoCuenta", "TipoCuenta")
                        .WithMany()
                        .HasForeignKey("TipoCuentaIdTipoCuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Misc.TipoPago", "TipoPago")
                        .WithMany()
                        .HasForeignKey("TipoPagoIdTipoPago")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Proveedores.TipoProveedor", "TipoProveedor")
                        .WithMany()
                        .HasForeignKey("TipoProveedorIdTipoProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Tiendas.Tiendas", b =>
                {
                    b.HasOne("Dominio.Tiendas.TipoTienda", "TipoTienda")
                        .WithMany()
                        .HasForeignKey("TipoTiendaIdTipoTienda");
                });
#pragma warning restore 612, 618
        }
    }
}