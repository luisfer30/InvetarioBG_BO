using InventoryModels;
using InventoryModels.DTO;
using InventoryRepository.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InventoryAPI.Controllers
{
    [ApiController, Route("api/products")]
    [SwaggerTag("Servicios para la gestión de productos en el inventario.")]
    public class ProductoController(ProductoRepository prodRepo) : ControllerBase
    {

        /// <summary>
        /// Obtiene el detalle de un producto por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(Response<ProductoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ErrorModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<ErrorModel>), StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetProducto(int id)
        {
            var producto = await prodRepo.GetById(id);
            return Ok(new Response<ProductoDTO> { Success=true, Message="Consulta realizada", Data=producto });
        }

        /// <summary>
        /// Crea un nuevo producto en el inventario.
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [ProducesResponseType(typeof(Response<ProductoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ErrorModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<ErrorModel>), StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> AddProducto([FromBody] ProductoDTO producto)
        {
           var newProduct = await prodRepo.AddProducto(producto);
           return Ok(new Response<ProductoDTO> { Success = true, Message = "Nuevo producto fue creado", Data = newProduct });
        }
                
        // [HttpPut("Update")]
        //public async Task<IActionResult> UpdateProducto(ProductoDTO producto)
        //{
        //     return Ok();

        // }

        // [HttpDelete("Delete/{id}")]
        //public async  Task<IActionResult> DeleteProducto(int id)
        //{
        //     return Ok();
        //}
    }
}
