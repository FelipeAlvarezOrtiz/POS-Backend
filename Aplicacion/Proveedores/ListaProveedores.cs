using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Proveedores;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Proveedores
{
    public class ListaProveedores
    {
        public class Query : IRequest<List<Proveedor>> { }

        public class Handler : IRequestHandler<Query, List<Proveedor>>
        {
            private readonly ApplicationDbContext _context;

            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<Proveedor>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Proveedores.ToListAsync(cancellationToken);
            }
        }
    }
}
