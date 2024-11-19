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
        public async Task<ActionResult<IEnumerable<PaisDTO>>> GetAll()
        {
            //var paises = await _paisService.GetAllCountryAsync();
            //return Ok(paises);
        }

        // Obtener un país por ID
        [HttpGet("usuario/{id}")]
        public async Task<ActionResult<PaisEntity>> GetById(int id)
        {
            //var pais = await _paisService.GetCountryByIdAsync(id);
            //if (pais == null)
            //    return NotFound($"No se encontró el país con ID: {id}");

            //return Ok(pais);
        }

        // Crear una nueva entidad (país)
        [HttpPost("usuario")]
        public async Task<ActionResult<PaisEntity>> Create([FromBody] CreatePaisDTO nuevaEntidad)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //var creado = await _paisService.CreateCountryAsync(nuevaEntidad.CodigoPais, nuevaEntidad.NombrePais);
            //if (creado != null) // Comprobamos si la creación fue exitosa
            //{
            //    // Si el país se creó exitosamente, retornamos un 201 Created con el objeto PaisEntity
            //    return CreatedAtAction(
            //        nameof(GetById),  // Método que obtiene un país por su ID
            //        new { id = creado.Id },  // Parámetro de la URL
            //        creado  // Retornamos el objeto creado
            //    );
            //}

            //return BadRequest("No se pudo crear el país.");
        }

        // Actualizar una entidad (país)
        [HttpPut("usuario/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PaisDTO entidadActualizada)
        {
            //if (id != entidadActualizada.Id)
            //    return BadRequest("El ID de la entidad no coincide.");

            //var paisExistente = await _paisService.GetCountryByIdAsync(id);
            //if (paisExistente == null)
            //    return NotFound($"No se encontró el país con ID: {id}");

            //var actualizado = await _paisService.UpdateCountryAsync(id, entidadActualizada.CodigoPais, entidadActualizada.NombrePais);
            //if (actualizado)
            //{
            //    return NoContent(); // 204 No Content, indicando que la actualización fue exitosa
            //}

            //return BadRequest("No se pudo actualizar el país.");
        }

        // Eliminar un país
        [HttpDelete("usuario/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            //var paisExistente = await _paisService.GetCountryByIdAsync(id);
            //if (paisExistente == null)
            //    return NotFound($"No se encontró el país con ID: {id}");

            //var eliminado = await _paisService.DeleteCountryAsync(id);
            //if (eliminado)
            //{
            //    return NoContent(); // 204 No Content, indicando que la eliminación fue exitosa
            //}

            //return BadRequest("No se pudo eliminar el país.");
        }
    }
}
