using AutoMapper;
using CodeFirst.DB.SqlServer.Shopping.Application.Dto;
using CodeFirst.DB.SqlServer.Shopping.Application.Dto.Nuevo;
using CodeFirst.DB.SqlServer.Shopping.Application.Interfaces;
using CodeFirst.DB.SqlServer.Shopping.Domain.Aggregate;
using CodeFirst.DB.SqlServer.Shopping.Domain.Interface;
using CodeFirst.DB.SqlServer.Shopping.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DB.SqlServer.Shopping.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly ShoppingContext _context;
        private readonly IProductoRepository _productoRepository;

        public ProductService(IMapper mapper, ShoppingContext context, IProductoRepository productoRepository)
        {
            _mapper = mapper;
            _context = context;
            _productoRepository = productoRepository;
        }

        public async Task<List<ProductoDto>> ListarProductos()
        {
            //var producto = await _context.Producto.ToListAsync();
            var producto = _productoRepository.ListarDetalleProducto();
            var productoDto = _mapper.Map<List<ProductoDto>>(producto);
            return productoDto;
        }

        public async Task<int> CrearProducto(NuevoProductoDto nuevoProductoDto)
        {
            var producto = _mapper.Map<Producto>(nuevoProductoDto);
            var valor = 1;

            //_context.Producto.Add(producto);
            //var valor = await _context.SaveChangesAsync();
            _productoRepository.Add(producto);
            _productoRepository.Save();

            //if (valor == 0)
            //{
            //    throw new Exception("No se pudo guardar el producto");
            //}

            return valor;
        }
    }
}
