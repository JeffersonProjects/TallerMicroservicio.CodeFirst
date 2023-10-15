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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DB.SqlServer.Shopping.Application.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly IMapper _mapper;
        private readonly ShoppingContext _context;
        private readonly ICompraRepository _compraRepository;

        public ShoppingService(IMapper mapper, ICompraRepository compraRepository, ShoppingContext context)
        {
            _mapper = mapper;
            _context = context;
            _compraRepository = compraRepository;
        }

        public async Task<List<CompraDto>> ListarCompras()
        {
            //var compra = await _context.Compra.ToListAsync();
            //var compra = await _context.Compra.Include(p => p.DetalleCompra).ToListAsync();
            var compra = _compraRepository.ListarDetalleCompra();
            var compraDto = _mapper.Map<List<CompraDto>>(compra);
            return compraDto;
        }

        public async Task<int> CrearCompra(NuevaCompraDto compraDto)
        {
            var compra = _mapper.Map<Compra>(compraDto);
            //var detalleCompra = compra.DetalleCompra;
            //var existeProducto = true;
            var valor = 1;

            //foreach (var itemDetalleCompra in detalleCompra)
            //{
            //    var productoId = itemDetalleCompra.ProductoId;
            //    var producto = await _context.Producto.FindAsync(productoId);
            //    if (producto == null)
            //    {
            //        existeProducto = false;
            //        break;
            //    }
            //}

            //if (existeProducto)
            //{
            //_context.Compra.Add(compra);
            //valor = await _context.SaveChangesAsync();
            _compraRepository.Add(compra);
            _compraRepository.Save();

                if (valor == 0)
                {                   
                    throw new Exception("No se pudo guardar la compra");
                }                        
            //}

            return valor;
        }

    }
}
