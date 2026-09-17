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

        [HttpPut("update")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ErrorModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<ErrorModel>), StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateProducto([FromBody] ProductoDTO producto)
        {
            var result = await prodRepo.UpdateProducto(producto);

            return Ok(new Response<bool>
            {
                Success = result,
                Message = result
                    ? "Producto actualizado correctamente"
                    : "No fue posible actualizar el producto",
                Data = result
            });
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ErrorModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<ErrorModel>), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var result = await prodRepo.DeleteProducto(id);

            return Ok(new Response<bool>
            {
                Success = result,
                Message = result
                    ? "Producto eliminado correctamente"
                    : "Producto no encontrado",
                Data = result
            });
        }
    }
}
