using InventoryModels;
using InventoryModels.DTO;
using InventoryRepository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InventoryAPI.Controllers
{
    [Route("api/providers")]
    [ApiController]
    [SwaggerTag("Servicios para la gestión de proveedores")]
    public class ProveedorController(ProveedorRepository prvrepo) : ControllerBase
    {
        /// <summary>
        /// Obtiene el detalle de un proveedor por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(Response<ProveedorDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ErrorModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<ErrorModel>), StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetProveedor(int id)
        {
            var proveedor = await prvrepo.GetById(id);
            return Ok(new Response<ProveedorDTO> { Success = true, Message = "Consulta realizada", Data = proveedor });
        }

        /// <summary>
        /// Crea un nuevo proveedor en el inventario.
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [ProducesResponseType(typeof(Response<ProveedorDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ErrorModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<ErrorModel>), StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> AddProveedor([FromBody] ProveedorDTO producto)
        {
            var newProv = await prvrepo.AddProveedor(producto);
            return Ok(new Response<ProveedorDTO> { Success = true, Message = "Nuevo producto fue creado", Data = newProv });
        }
    }
}
