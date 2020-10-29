using Dominio.Productos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Productos
{
    public class ListaProductos
    {
        public class Query : IRequest<List<Producto>>{}

        public class Handler : IRequestHandler<Query, List<Producto>>
        {
            private readonly ApplicationDbContext _context;

            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<List<Producto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Productos.Include(producto=> producto.Categoria)
                    .Include(producto => producto.Medida)
                    .Include(producto => producto.Proveedor)
                    .Take(20).OrderByDescending(x => x.IdProducto).ToListAsync(cancellationToken);
            }
        }
    }
}
