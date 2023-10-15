using CodeFirst.DB.SqlServer.Shopping.Application.Dto;
using CodeFirst.DB.SqlServer.Shopping.Application.Dto.Nuevo;
using CodeFirst.DB.SqlServer.Shopping.Application.Interfaces;
using CodeFirst.DB.SqlServer.Shopping.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.DB.SqlServer.Shopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly IShoppingService _shoppingService;

        public ComprasController(IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
        }

        [HttpGet("listarCompras")]
        public async Task<ActionResult<List<CompraDto>>> ListarCompras()
        {
            //return Ok(_shoppingService.ListarCompras());
            return await _shoppingService.ListarCompras();
        }

        [HttpPost("nuevaCompra")]
        public async Task<int> NuevaCompra(NuevaCompraDto compraDto)
        {            
            return await _shoppingService.CrearCompra(compraDto);
        }

    }
}
