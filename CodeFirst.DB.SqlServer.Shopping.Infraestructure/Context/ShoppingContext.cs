using CodeFirst.DB.SqlServer.Shopping.Domain.Aggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DB.SqlServer.Shopping.Infraestructure.Context
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options)
        {
        }

        public DbSet<Compra> Compra { get; set; } = null!;
        public DbSet<DetalleCompra> DetalleCompra { get; set; } = null!;
        public DbSet<Producto> Producto { get; set; } = null!;
     }
}
