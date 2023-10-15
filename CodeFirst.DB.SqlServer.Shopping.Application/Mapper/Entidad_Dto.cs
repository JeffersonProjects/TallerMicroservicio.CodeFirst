using AutoMapper;
using CodeFirst.DB.SqlServer.Shopping.Application.Dto.Nuevo;
using CodeFirst.DB.SqlServer.Shopping.Application.Dto;
using CodeFirst.DB.SqlServer.Shopping.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DB.SqlServer.Shopping.Application.Mapper
{
    public class Entidad_Dto : Profile
    {
        public Entidad_Dto()
        {
            CreateMap<Compra, CompraDto>();
            CreateMap<DetalleCompra, DetalleCompraDto>();
            CreateMap<Producto, ProductoDto>();
        }
    }
}
