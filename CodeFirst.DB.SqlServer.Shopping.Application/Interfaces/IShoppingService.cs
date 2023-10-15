using CodeFirst.DB.SqlServer.Shopping.Application.Dto;
using CodeFirst.DB.SqlServer.Shopping.Application.Dto.Nuevo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DB.SqlServer.Shopping.Application.Interfaces
{
    public interface IShoppingService
    {
        Task<List<CompraDto>> ListarCompras();
        Task<int> CrearCompra(NuevaCompraDto compraDto);
    }
}
