using Dominio.Clientes;
using Dominio.Misc;
using Dominio.Productos;
using Dominio.Proveedores;
using Dominio.Tiendas;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(){}

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=161.35.248.76,1433;Initial Catalog=POS;Persist Security Info=True;User ID=sa;Password=AlarakJuegaShakuras199522-");
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Medida> Medidas { get; set; }
        public DbSet<TipoProveedor> TipoProveedores { get; set; }
        public DbSet<ContactoProveedor> ContactoProveedores { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Tiendas> Tiendas { get; set; }
        public DbSet<TipoTienda> TipoTiendas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Region> Regiones { get; set; }
        public DbSet<Comuna> Comunas { get; set; }
        public DbSet<Sector> Sectores { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<TipoPago> TipoPagos { get; set; }
        public DbSet<TipoCuenta> TipoCuentas { get; set; }

    }
}
