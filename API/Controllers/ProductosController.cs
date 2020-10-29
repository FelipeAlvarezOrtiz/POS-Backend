using Aplicacion.Productos;
using Dominio.Productos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> ListaProductos()
        {
            return await _mediator.Send(new ListaProductos.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> DetalleProducto(int id)
        {
            return await _mediator.Send(new DetalleProducto.Query{Id=id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CrearNuevoProducto(CrearProducto.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> ActualizarProducto(int id,ActualizarProducto.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> BorrarProducto(int id)
        {
            return await _mediator.Send( new BorrarProducto.Command{Id = id});
        }
    }
}
