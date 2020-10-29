using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.Productos
{
    public class BorrarProducto
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
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
                var producto = await _context.Productos.FindAsync(request.Id);

                if (producto is null) throw new Exception("No se pudo encontrar ese producto");

                _context.Remove(producto);

                return (await _context.SaveChangesAsync() > 0)
                    ? Unit.Value
                    : throw new Exception("Error al interntar borrar un producto");
            }
        }

    }
}
