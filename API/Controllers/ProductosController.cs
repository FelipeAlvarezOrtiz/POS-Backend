using Aplicacion.Productos;
using Dominio.Productos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class ProductosController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> ListaProductos()
        {
            return await Mediator.Send(new ListaProductos.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> DetalleProducto(int id)
        {
            return await Mediator.Send(new DetalleProducto.Query{Id=id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CrearNuevoProducto(CrearProducto.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> ActualizarProducto(int id,ActualizarProducto.Command command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> BorrarProducto(int id)
        {
            return await Mediator.Send( new BorrarProducto.Command{Id = id});
        }
    }
}
