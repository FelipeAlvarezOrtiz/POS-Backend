using System;
using System.Linq;
using MediatR;
using Persistencia;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Productos;
using Dominio.Proveedores;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Productos
{
    public class ActualizarProducto
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
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

            public Handler( ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var producto = await _context.Productos.FindAsync(request.Id);

                if(producto is null) throw new Exception("No se ha podido encontrar ese producto");

                producto.NombreProducto = request.NombreProducto ?? producto.NombreProducto;
                producto.DescripcionProducto = request.DescripcionProducto ?? producto.DescripcionProducto;
                producto.PrecioMayorista = request.PrecioMayorista;
                producto.PrecioTotal = request.PrecioTotal;
                producto.Categoria = await ObtenerCategoria(request.Categoria);
                producto.Medida = await ObtenerMedida(request.Medida);
                producto.Proveedor = await ObtenerProveedor(request.Proveedor);

                return await _context.SaveChangesAsync() > 0 ? Unit.Value : throw new Exception("No se ha podido actualizar el producto");
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
                    .Include(p => p.TipoCuenta).Include(p => p.TipoPago)
                    .Include(p => p.TipoProveedor)
                    .FirstOrDefaultAsync();
            }
        }
    }
}
