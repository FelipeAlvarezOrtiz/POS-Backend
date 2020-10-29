using System;
using Dominio.Productos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Productos
{
    public class DetalleProducto
    {
        public class Query : IRequest<Producto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Producto>
        {
            private readonly ApplicationDbContext _context;

            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Producto> Handle(Query request, CancellationToken cancellationToken)
            {
                if(await _context.Productos.FindAsync(request.Id) is null) 
                    throw new Exception("No hay detalles para el producto seleccionado");

                return await _context.Productos.Where(producto => producto.IdProducto == request.Id)
                    .Include(x=> x.Categoria).Include(x=> x.Medida)
                    .Include(x=> x.Proveedor)
                    .FirstOrDefaultAsync();
            }
        }
    }
}
