using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DB.SqlServer.Shopping.Application.Dto
{
    public class CompraDto
    {
        public int CompraId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public List<DetalleCompraDto> DetalleCompra { get; set; } = null!;
    }
}
