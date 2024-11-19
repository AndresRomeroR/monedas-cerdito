﻿using CoinsBack.Core.DTOs;
using CoinsBack.Core.Entities;
using CoinsBack.Core.Interfaces;
using CoinsBack.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoinsBack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametricasController : Controller
    {
        private readonly IPaisService _paisService;
        private readonly IDepartamentoService _departamentoService;

        public ParametricasController(
            IPaisService paisService, 
            IDepartamentoService departamentoService)
        {
            _paisService = paisService;
            _departamentoService = departamentoService;
        }

        // Controlador paises
        #region
        // Obtener todos los países
        [HttpGet("paises")]
        public async Task<ActionResult<IEnumerable<PaisDTO>>> GetAll()
        {
            var paises = await _paisService.GetAllCountryAsync();
            return Ok(paises);
        }

        // Obtener un país por ID
        [HttpGet("pais/{id}")]
        public async Task<ActionResult<PaisEntity>> GetById(int id)
        {
            var pais = await _paisService.GetCountryByIdAsync(id);
            if (pais == null)
                return NotFound($"No se encontró el país con ID: {id}");

            return Ok(pais);
        }

        // Crear una nueva entidad (país)
        [HttpPost("pais")]
        public async Task<ActionResult<PaisEntity>> Create([FromBody] CreatePaisDTO nuevaEntidad)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _paisService.CreateCountryAsync(nuevaEntidad.CodigoPais, nuevaEntidad.NombrePais);
            if (creado != null) // Comprobamos si la creación fue exitosa
            {
                // Si el país se creó exitosamente, retornamos un 201 Created con el objeto PaisEntity
                return CreatedAtAction(
                    nameof(GetById),  // Método que obtiene un país por su ID
                    new { id = creado.Id },  // Parámetro de la URL
                    creado  // Retornamos el objeto creado
                );
            }

            return BadRequest("No se pudo crear el país.");
        }

        // Actualizar una entidad (país)
        [HttpPut("pais/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PaisDTO entidadActualizada)
        {
            if (id != entidadActualizada.Id)
                return BadRequest("El ID de la entidad no coincide.");

            var paisExistente = await _paisService.GetCountryByIdAsync(id);
            if (paisExistente == null)
                return NotFound($"No se encontró el país con ID: {id}");

            var actualizado = await _paisService.UpdateCountryAsync(id, entidadActualizada.CodigoPais, entidadActualizada.NombrePais);
            if (actualizado)
            {
                return NoContent(); // 204 No Content, indicando que la actualización fue exitosa
            }

            return BadRequest("No se pudo actualizar el país.");
        }

        // Eliminar un país
        [HttpDelete("pais/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var paisExistente = await _paisService.GetCountryByIdAsync(id);
            if (paisExistente == null)
                return NotFound($"No se encontró el país con ID: {id}");

            var eliminado = await _paisService.DeleteCountryAsync(id);
            if (eliminado)
            {
                return NoContent(); // 204 No Content, indicando que la eliminación fue exitosa
            }

            return BadRequest("No se pudo eliminar el país.");
        }
        #endregion

        // Controlador departamento
        #region
        // Obtener todas las entidades
        [HttpGet("departamentos")]
        public async Task<ActionResult<IEnumerable<DepartamentoDTO>>> GetAllDepartamento()
        {
            var departamentos = await _departamentoService.GetAllDepartmentAsync();
            return Ok(departamentos);
        }

        // Obtener una entidad por ID
        [HttpGet("departamento/{id}")]
        public async Task<ActionResult<PaisDTO>> GetByIdDepartamento(int id)
        {
            var departamento = await _departamentoService.GetDepartmentByIdAsync(id);
            if (departamento == null)
                return NotFound($"No se encontró el departamento con ID: {id}");

            return Ok(departamento);
        }

        // Crear una nueva entidad
        [HttpPost("departamento")]
        public async Task<ActionResult> CreateDepartamento([FromBody] CreateDepartamentoDTO nuevaEntidad)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _departamentoService.CreateDepartmentAsync(nuevaEntidad.CodigoDepartamento, nuevaEntidad.NombreDepartamento, nuevaEntidad.CodigoPais);
            if (creado != null)
            {
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = creado.IdDepartamento },
                    creado
                );
            }

            return BadRequest("No se pudo crear el departamento.");
        }

        // Actualizar una entidad existente
        [HttpPut("departamento/{id}")]
        public async Task<ActionResult> UpdateDepartamento(int id, [FromBody] CreateDepartamentoDTO entidadActualizada)
        {
            if (id != entidadActualizada.Id)
                return BadRequest("El ID de la entidad no coincide.");

            var departamentoExistente = await _departamentoService.GetDepartmentByIdAsync(id);
            if (departamentoExistente == null)
                return NotFound($"No se encontró el departamento con ID: {id}");

            var actualizado = await _departamentoService.UpdateDepartmentAsync(id, entidadActualizada.CodigoDepartamento, entidadActualizada.NombreDepartamento, entidadActualizada.CodigoPais);
            if (actualizado)
            {
                return NoContent(); // 204 No Content, indicando que la actualización fue exitosa
            }

            return BadRequest("No se pudo actualizar el departamento.");
        }

        // Eliminar una entidad
        [HttpDelete("departamento/{id}")]
        public async Task<ActionResult> DeleteDepartamento(int id)
        {
            var departamentoExistente = await _departamentoService.GetDepartmentByIdAsync(id);
            if (departamentoExistente == null)
                return NotFound($"No se encontró el país con ID: {id}");

            var eliminado = await _departamentoService.DeleteDepartmentAsync(id);
            if (eliminado)
            {
                return NoContent(); 
            }

            return BadRequest("No se pudo eliminar el país.");
        }
        #endregion

        // Controlador municipio
        #region
        // Obtener todas las entidades
        [HttpGet("municipios")]
        public async Task<ActionResult<IEnumerable<PaisDTO>>> GetAllMunicipios()
        {
            var entidades = await _paisService.GetAllCountryAsync();
            return Ok(entidades);
        }

        // Obtener una entidad por ID
        [HttpGet("municipio/{id}")]
        public async Task<ActionResult<PaisDTO>> GetByIdMunicipios(int id)
        {
            //var entidad = await _repository.GetByIdAsync(id);
            //if (entidad == null)
            //    return NotFound($"No se encontró la entidad con ID: {id}");

            return Ok();
        }

        // Crear una nueva entidad
        [HttpPost("municipio")]
        public async Task<ActionResult> CreateMunicipios([FromBody] PaisDTO nuevaEntidad)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //await _repository.CreateAsync(nuevaEntidad);
            return CreatedAtAction(nameof(GetById), new { id = nuevaEntidad.Id }, nuevaEntidad);
        }

        // Actualizar una entidad existente
        [HttpPut("municipio/{id}")]
        public async Task<ActionResult> UpdateMunicipios(int id, [FromBody] PaisDTO entidadActualizada)
        {
            //if (id != entidadActualizada.Id)
            //    return BadRequest("El ID de la entidad no coincide.");

            //var existente = await _repository.GetByIdAsync(id);
            //if (existente == null)
            //    return NotFound($"No se encontró la entidad con ID: {id}");

            //await _repository.UpdateAsync(entidadActualizada);
            return NoContent();
        }

        // Eliminar una entidad
        [HttpDelete("municipio/{id}")]
        public async Task<ActionResult> DeleteMunicipio(int id)
        {
            //var existente = await _repository.GetByIdAsync(id);
            //if (existente == null)
            //    return NotFound($"No se encontró la entidad con ID: {id}");

            //await _repository.DeleteAsync(id);
            return NoContent();
        }
        #endregion
    }
}
