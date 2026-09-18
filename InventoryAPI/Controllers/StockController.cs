using InventoryModels;
using InventoryModels.DTO;
using InventoryRepository.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InventoryAPI.Controllers
{
    [Route("api/stock")]
    [ApiController]
    [SwaggerTag("Gestión del inventario")]
    public class StockController(StockRepository strepo) : Controller
    {
        private readonly StockRepository _strepo = strepo;

        [HttpGet("list")]
        [ProducesResponseType(typeof(Response<List<StockDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ErrorModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<ErrorModel>), StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetStock()
        {
            var stock = await _strepo.GetStock();
            return Ok(new Response<List<StockDTO>> { Success = true, Message = "Stock Actual", Data = stock });
        }
        [HttpPost("add")]
        [ProducesResponseType(typeof(Response<StockDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ErrorModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<ErrorModel>), StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> AddStock([FromBody] StockDTO request)
        {
            var exists = await _strepo.ExistsStock(
                request.ProductoId,
                request.ProveedorId
            );

            if (exists)
            {
                return BadRequest(new Response<StockDTO>
                {
                    Success = false,
                    Message = "Ya existe stock registrado para este producto y proveedor.",
                    Data = null
                });
            }

            var stock = await _strepo.AddStock(request);

            return Ok(new Response<StockDTO>
            {
                Success = true,
                Message = "Stock registrado correctamente.",
                Data = stock
            });
        }
    }

}
