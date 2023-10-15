using CodeFirst.DB.MySql.Customer.Domain.Aggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DB.MySql.Customer.Infraestructure.Context
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; } = null!;
        public DbSet<Direccion> Direccion { get; set; } = null!;
    }
}
