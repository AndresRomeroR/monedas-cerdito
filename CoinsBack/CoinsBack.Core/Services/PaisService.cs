using CoinsBack.Core.DTOs;
using CoinsBack.Core.Entities;
using CoinsBack.Core.Interfaces;

namespace CoinsBack.Core.Services;

public class PaisService : IPaisService
{
    private readonly IPaisRepository _paisRepository;

    public PaisService(IPaisRepository paisRepository)
    {
        _paisRepository = paisRepository;
    }

    // Obtener todos los países
    public async Task<IEnumerable<PaisDTO>> GetAllCountryAsync()
    {
        var paises = await _paisRepository.GetAllAsync();
        return paises.Select(p => new PaisDTO
        {
            Id = p.Id,
            NombrePais = p.NombrePais,
            CodigoPais = p.CodigoPais
        });
    }

    // Obtener un país por su ID
    public async Task<PaisEntity> GetCountryByIdAsync(int id)
    {
        var pais = await _paisRepository.GetByIdAsync(id);
        if (pais == null)
            return null;

        return pais;
    }

    // Crear un nuevo país
    public async Task<PaisEntity> CreateCountryAsync(string codigoPais, string nombrePais)
    {
        return await _paisRepository.CrearPaisAsync(codigoPais, nombrePais);
    }

    // Actualizar un país existente
    public async Task<bool> UpdateCountryAsync(int id, string codigoPais, string nombrePais)
    {
        return await _paisRepository.ActualizarPaisAsync(id, codigoPais, nombrePais);
    }

    // Eliminar un país
    public async Task<bool> DeleteCountryAsync(int id)
    {
        return await _paisRepository.EliminarPaisAsync(id);
    }
}
