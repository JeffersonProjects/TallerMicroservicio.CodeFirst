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
    public class ConsultaId
    {
        public class ConsultaClientePorId : IRequest<Cliente>
        {
            public int ClienteId { get; set; }
        }

        public class Conductor : IRequestHandler<ConsultaClientePorId, Cliente>
        {
            private readonly CustomerContext context;
            public Conductor(CustomerContext _context)
            {
                context = _context;
            }

            public async Task<Cliente> Handle(ConsultaClientePorId request, CancellationToken cancellationToken)
            {
                var cliente = await context.Cliente.FindAsync(request.ClienteId);
                return cliente;
            }
        }
    }
}
