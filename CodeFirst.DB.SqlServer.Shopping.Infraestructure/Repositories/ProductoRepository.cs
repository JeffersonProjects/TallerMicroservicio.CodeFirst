using CodeFirst.DB.SqlServer.Shopping.Domain.Aggregate;
using CodeFirst.DB.SqlServer.Shopping.Domain.Interface;
using CodeFirst.DB.SqlServer.Shopping.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.DB.SqlServer.Shopping.Infraestructure.Repositories
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(ShoppingContext context) : base(context) { }

        public List<Producto> ListarDetalleProducto()
        {
            return _context.Producto.ToList();
            
        }
    }
}
