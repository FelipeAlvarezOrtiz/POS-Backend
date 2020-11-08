using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Proveedores;
using Dominio.Proveedores;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProveedoresController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Proveedor>>> ListaProveedores()
        {
            return await Mediator.Send(new ListaProveedores.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> DetalleProveedor(string id)
        {
            return await Mediator.Send(new DetalleProveedor.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CrearNuevoProducto(CrearProveedor.Command command)
        {
            return await Mediator.Send(command);
        }
    }
}
