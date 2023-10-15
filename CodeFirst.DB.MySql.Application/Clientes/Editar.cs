using CodeFirst.DB.MySql.Customer.Infraestructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DB.MySql.Customer.Application.Clientes
{
    public class Editar
    {
        public class EditarCliente : IRequest
        {
            public int ClienteId { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }

        }

        public class Conductor : IRequestHandler<EditarCliente>
        {
            private readonly CustomerContext context;
            public Conductor(CustomerContext _context)
            {
                context = _context;
            }

            public async Task<Unit> Handle(EditarCliente request, CancellationToken cancellationToken)
            {
                var cliente = await context.Cliente.FindAsync(request.ClienteId);

                if (cliente == null)
                {
                    throw new Exception("No se encontro el cliente");
                }

                cliente.Nombres = request.Nombres ?? request.Nombres;

                var resultado = await context.SaveChangesAsync();

                if (resultado > 0)
                    return Unit.Value;

                throw new Exception("No se guardaron los cambios en el cliente");
            }
        }
    }
}
