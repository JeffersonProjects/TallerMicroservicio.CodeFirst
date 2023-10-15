using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DB.SqlServer.Shopping.Application.Dto.Nuevo
{
    public class NuevaCompraDto
    {
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public virtual List<NuevaCompraDetalleDto> DetalleCompra { get; set; } = null!;
    }

    public class NuevaCompraDetalleDto
    {
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
