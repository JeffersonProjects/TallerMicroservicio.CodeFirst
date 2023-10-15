using CodeFirst.DB.MySql.Customer.Application.Clientes;
using CodeFirst.DB.MySql.Customer.Domain.Aggregate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.DB.MySql.Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly IMediator _mediator;
        public ClienteController(IMediator mediador)
        {
            _mediator = mediador;
        }


        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> ListaCliente()
        {
            return await _mediator.Send(new Consulta.ListarCliente());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> ConsultaClientePorId(int id)
        {
            return await _mediator.Send(new ConsultaId.ConsultaClientePorId { ClienteId = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> NuevoCliente(Nuevo.NuevoCliente data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> EditarCliente(int id, Editar.EditarCliente data)
        {
            data.ClienteId = id;
            return await _mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> EliminarUsuario(int id)
        {
            return await _mediator.Send(new Eliminar.EliminarCliente { ClienteId = id });
        }
    }
}
