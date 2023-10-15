using CodeFirst.DB.SqlServer.Shopping.Application.Dto;
using CodeFirst.DB.SqlServer.Shopping.Application.Dto.Nuevo;
using CodeFirst.DB.SqlServer.Shopping.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.DB.SqlServer.Shopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductoController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("listarProductos")]
        public async Task<ActionResult<List<ProductoDto>>> ListarProductos() //IActionResult ListarProductos()            
        {
            //return Ok(_productService.ListarProductos());
            return await _productService.ListarProductos();
        }

        [HttpPost("nuevoProducto")]
        public async Task<ActionResult<int>> NuevoProducto(NuevoProductoDto nuevoProductoDto)
        {
            //_productService.CrearProducto(nuevoProductoDto);
            //return Ok();
            return await _productService.CrearProducto(nuevoProductoDto);
        }
    }
}
