using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.DB.MySql.Customer.Domain.Aggregate;
using CodeFirst.DB.MySql.Customer.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.DB.MySql.Customer.Application.Clientes
{
    public class Consulta
    {
        public class ListarCliente : IRequest<List<Cliente>> { }

        public class Conductor : IRequestHandler<ListarCliente, List<Cliente>>
        {
            private readonly CustomerContext context;
            public Conductor(CustomerContext _context)
            {
                context = _context;
            }

            public async Task<List<Cliente>> Handle(ListarCliente request, CancellationToken cancellationToken)
            {
                var clientes = await context.Cliente.ToListAsync();
                return clientes;
            }
        }
    }
}
