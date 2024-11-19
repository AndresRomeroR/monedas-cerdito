using CoinsBack.Core.DTOs;
using CoinsBack.Core.Entities;
using CoinsBack.Core.Interfaces;

namespace CoinsBack.Core.Services;

public class DepartamentoService : IDepartamentoService
{
    private readonly IDepartamentoRepository _departamentoRepository;

    public DepartamentoService(IDepartamentoRepository departamentoRepository)
    {
        _departamentoRepository = departamentoRepository;
    }

    // Obtener todos los departamentos
    public async Task<IEnumerable<DepartamentoDTO>> GetAllDepartmentAsync()
    {
        var departamentos = await _departamentoRepository.GetAllAsync();
        return departamentos.Select(d => new DepartamentoDTO
        {
            Id = d.IdDepartamento,
            NombreDepartamento = d.NombreDepartamento,
            CodigoDepartamento = d.CodigoDepartamento
        });
    }

    // Obtener un departamento por su ID
    public async Task<DepartamentoEntity> GetDepartmentByIdAsync(int id)
    {
        var departamento = await _departamentoRepository.GetByIdAsync(id);
        if (departamento == null)
            return null;

        return departamento;
    }

    // Crear un nuevo departamento
    public async Task<DepartamentoEntity> CreateDepartmentAsync(
        string codigoDepartamento, 
        string nombreDepartamento,
        int codigoPais)
    {
        return await _departamentoRepository.CrearDepartamentoAsync(codigoDepartamento, nombreDepartamento, codigoPais);
    }

    // Actualizar un país existente
    public async Task<bool> UpdateDepartmentAsync(int id,
        string codigoDepartamento,
        string nombreDepartamento,
        int codigoPais)
    {
        return await _departamentoRepository.ActualizarDepartamentoAsync(id, codigoDepartamento, nombreDepartamento, codigoPais);
    }

    // Eliminar un país
    public async Task<bool> DeleteDepartmentAsync(int id)
    {
        return await _departamentoRepository.EliminarDepartamentoAsync(id);
    }
}
