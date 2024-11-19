using CoinsBack.Core.DTOs;
using CoinsBack.Core.Entities;
using CoinsBack.Core.Interfaces;
using CoinsBack.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoinsBack.Api.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Obtener todos los usuarios
        [HttpGet("usuarios")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsuarios()
        {
            var usuarios = await _userService.GetAllUserAsync();
            return Ok(usuarios);
        }

        // Obtener un país por ID
        [HttpGet("usuario/{id}")]
        public async Task<ActionResult<PaisEntity>> GetByIdUsuario(int id)
        {
            var usuario = await _userService.getUserbyidasync(id);
            if (usuario == null)
                return NotFound($"No se encontró el usuario con ID: {id}");

            return Ok(usuario);
        }

        // Crear una nueva entidad (usuario)
        [HttpPost("usuario")]
        public async Task<ActionResult<UserEntity>> CreateUsuario([FromBody] CreateUserDTO nuevaEntidad)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _userService.createUserasync(
                nuevaEntidad.NombreUsuario,
                nuevaEntidad.TelefonoUsuario,
                nuevaEntidad.DireccionDetalle,
                nuevaEntidad.PaisId,
                nuevaEntidad.DepartamentoId,
                nuevaEntidad.MunicipioId);
            if (creado != null)
            {
                return CreatedAtAction(
                    nameof(GetByIdUsuario),
                    new { id = creado.Id },
                    creado
                );
            }

            return BadRequest("No se pudo crear el usario.");
        }

        // Actualizar una entidad (país)
        [HttpPut("usuario/{id}")]
        public async Task<ActionResult> UpdateUsuario(int id, [FromBody] CreateUserDTO entidadActualizada)
        {
            if (id != entidadActualizada.Id)
                return BadRequest("El ID de la entidad no coincide.");

            var usuarioExistente = await _userService.getUserbyidasync(id);
            if (usuarioExistente == null)
                return NotFound($"No se encontró el país con ID: {id}");

            var actualizado = await _userService.updateUsuarioasync(id,
                entidadActualizada.NombreUsuario,
                entidadActualizada.TelefonoUsuario,
                entidadActualizada.DireccionDetalle,
                entidadActualizada.PaisId,
                entidadActualizada.DepartamentoId,
                entidadActualizada.MunicipioId);
            if (actualizado)
            {
                return NoContent(); // 204 No Content, indicando que la actualización fue exitosa
            }

            return BadRequest("No se pudo actualizar el usuario.");
        }

        // Eliminar un usuario
        [HttpDelete("usuario/{id}")]
        public async Task<ActionResult> DeleteUusario(int id)
        {
            var usuarioExistente = await _userService.getUserbyidasync(id);
            if (usuarioExistente == null)
                return NotFound($"No se encontró el usuario con ID: {id}");

            var eliminado = await _userService.deleteUsuarioasync(id);
            if (eliminado)
            {
                return NoContent(); // 204 No Content, indicando que la eliminación fue exitosa
            }

            return BadRequest("No se pudo eliminar el país.");
        }
    }
}
