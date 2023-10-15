using CodeFirst.DB.MySql.Customer.Infraestructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DB.MySql.Customer.Application.Clientes
{
    public class Eliminar
    {
        public class EliminarCliente : IRequest
        {
            public int ClienteId { get; set; }
        }

        public class Conductor : IRequestHandler<EliminarCliente>
        {
            private readonly CustomerContext context;
            public Conductor(CustomerContext _context)
            {
                context = _context;
            }

            public async Task<Unit> Handle(EliminarCliente request, CancellationToken cancellationToken)
            {
                var cliente = await context.Cliente.FindAsync(request.ClienteId);

                if (cliente == null)
                {
                    throw new Exception("No se encontro el cliente");
                }

                context.Remove(cliente);

                var resultado = await context.SaveChangesAsync();

                if (resultado > 0)
                    return Unit.Value;

                throw new Exception("No se pudo eliminar el cliente");
            }
        }
    }
}
