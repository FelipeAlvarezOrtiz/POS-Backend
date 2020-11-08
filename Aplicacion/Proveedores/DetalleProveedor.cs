using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Proveedores;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Proveedores
{
    public class DetalleProveedor
    {
        public class Query : IRequest<Proveedor>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Proveedor>
        {
            private readonly ApplicationDbContext _context;

            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Proveedor> Handle(Query request, CancellationToken cancellationToken)
            {
                if (await _context.Proveedores.FindAsync(request.Id) is null)
                    throw new Exception("No hay detalles para el proveedor seleccionado");

                return await _context.Proveedores.Where(proveedor => proveedor.RutProveedor == request.Id)
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
}
