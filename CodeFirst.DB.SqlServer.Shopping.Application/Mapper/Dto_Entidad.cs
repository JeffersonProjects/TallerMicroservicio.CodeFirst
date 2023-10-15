using AutoMapper;
using CodeFirst.DB.SqlServer.Shopping.Application.Dto;
using CodeFirst.DB.SqlServer.Shopping.Application.Dto.Nuevo;
using CodeFirst.DB.SqlServer.Shopping.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DB.SqlServer.Shopping.Application.Mapper
{
    public class Dto_Entidad : Profile
    {
        public Dto_Entidad()
        {
            CreateMap<CompraDto, Compra>();
            CreateMap<DetalleCompraDto, DetalleCompra>();
            CreateMap<ProductoDto, Producto>();
            CreateMap<NuevoProductoDto, Producto>();

            CreateMap<NuevaCompraDetalleDto, DetalleCompra>();
            CreateMap<NuevaCompraDto, Compra>();
        }
    }
}
