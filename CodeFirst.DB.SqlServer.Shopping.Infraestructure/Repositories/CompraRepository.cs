using CodeFirst.DB.SqlServer.Shopping.Domain.Aggregate;
using CodeFirst.DB.SqlServer.Shopping.Domain.Interface;
using CodeFirst.DB.SqlServer.Shopping.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.DB.SqlServer.Shopping.Infraestructure.Repositories
{
    public class CompraRepository : GenericRepository<Compra>, ICompraRepository
    {
        public CompraRepository(ShoppingContext context) : base(context) { }

        public List<Compra> ListarDetalleCompra()
        {
            return _context.Compra.Include(p => p.DetalleCompra).ToList();
        }
    }
}
