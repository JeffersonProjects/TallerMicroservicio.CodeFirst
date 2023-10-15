using CodeFirst.DB.MySql.Customer.Domain.Aggregate;
using CodeFirst.DB.MySql.Customer.Infraestructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DB.MySql.Customer.Application.Clientes
{
    public class Nuevo
    {
        public class NuevoCliente : IRequest
        {
            public int ClienteId { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
        }

        public class Conductor : IRequestHandler<NuevoCliente>
        {
            private readonly CustomerContext context;
            public Conductor(CustomerContext _context)
            {
                context = _context;
            }

            public async Task<Unit> Handle(NuevoCliente request, CancellationToken cancellationToken)
            {
                var cliente = new Cliente
                {
                    ClienteId = request.ClienteId,
                    Nombres = request.Nombres,
                    Apellidos = request.Apellidos
                };

                context.Cliente.Add(cliente);
                var valor = await context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo guardar el cliente");
            }
        }
    }
}
