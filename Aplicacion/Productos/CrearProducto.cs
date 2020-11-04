using System;
using System.Linq;
using MediatR;
using Dominio.Productos;
using Dominio.Proveedores;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Productos
{
    public class CrearProducto
    {
        public class Command : IRequest
        {
            public string NombreProducto { get; set; }
            public string DescripcionProducto { get; set; }
            public int PrecioMayorista { get; set; }
            public int PrecioTotal { get; set; }

            public int Categoria { get; set; }

            public int Medida { get; set; }
     
            public int Proveedor { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ApplicationDbContext _context;

            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var categoria = await ObtenerCategoria(request.Categoria);
                var medida = await ObtenerMedida(request.Medida);
                var proveedor = await ObtenerProveedor(request.Proveedor); 
                await _context.Productos.AddAsync(new Producto()
                {
                    NombreProducto = request.NombreProducto,
                    DescripcionProducto = request.DescripcionProducto,
                    PrecioMayorista = request.PrecioMayorista,
                    PrecioTotal = request.PrecioTotal,
                    FechaCreacion = DateTime.Now,
                    NombreBusqueda = request.NombreProducto + " " + medida.NombreMedida,
                    Categoria = categoria,
                    Medida = medida,
                    Proveedor = proveedor
                });
                return await _context.SaveChangesAsync() > 0
                    ? Unit.Value 
                    : throw new Exception("Problema al guardar el producto");
            }

            private async Task<Categoria> ObtenerCategoria(int id)
            {
                return await _context.Categorias.Where(cat => cat.IdCategoria == id).FirstOrDefaultAsync();
            }

            private async Task<Medida> ObtenerMedida(int id)
            {
                return await _context.Medidas.Where(med => med.IdMedida == id).FirstOrDefaultAsync();
            }

            private async Task<Proveedor> ObtenerProveedor(int id)
            {
                return await _context.Proveedores.Where(prov => prov.IdProveedor == id)
                    .Include(p => p.Banco)
                    .Include(p => p.TipoCuenta)
                    .Include(p => p.TipoPago)
                    .Include(p => p.TipoProveedor)
                    .FirstOrDefaultAsync();
            }
        }
    }
}
