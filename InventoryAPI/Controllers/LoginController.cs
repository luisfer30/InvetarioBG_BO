using InventoryAPI.Services;
using InventoryModels;
using InventoryModels.Request;
using InventoryRepository.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InventoryAPI.Controllers
{

    [ApiController, Route("api/security")]
    [SwaggerTag("Servicio de autenticación y autorización de usuarios.")]
    public class LoginController(UsuarioRepository usrRepo, IConfiguration config)  : ControllerBase
    {
        /// <summary>
        /// Autentica las credenciales del usuario y devuelve un token de autenticación si son válidas.
        /// </summary>
        /// <param name="login">Objeto que contiene las credenciales del usuario.</param>
        [HttpPost("auth")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Response<string>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ErrorModel>),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<ErrorModel>),StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Autenticar([FromBody] LoginRequest login)
        {           
           await usrRepo.ValidarCredenciales(login);

           var token = GenerarToken.GenerateTokenJWT(config);

           return Ok(new Response<string> {Success=true, Message="Autenticación exitosa", Data=token });           
        }
    }
}
