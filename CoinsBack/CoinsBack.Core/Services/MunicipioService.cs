using CoinsBack.Core.DTOs;
using CoinsBack.Core.Entities;
using CoinsBack.Core.Interfaces;

namespace CoinsBack.Core.Services;

public class MunicipioService : IMunicipioService
{
    private readonly IMunicipioRepository _municipioRepository;

    public MunicipioService(IMunicipioRepository municipioRepository)
    {
        _municipioRepository = municipioRepository;
    }

    // Obtener todos los municipios
    public async Task<IEnumerable<MunicipioDTO>> GetAllMunicipalityAsync()
    {
        var municipios = await _municipioRepository.GetAllAsync();
        return municipios.Select(m => new MunicipioDTO
        {
            Id = m.Id,
            NombreMunicipio = m.NombreMunicipio,
            CodigoMunicipio = m.CodigoMunicipio
        });
    }

    // Obtener un municipio por su ID
    public async Task<MunicipioEntity> GetMunicipalityByIdAsync(int id)
    {
        var municipio = await _municipioRepository.GetByIdAsync(id);
        if (municipio == null)
            return null;

        return municipio;
    }

    // Crear un nuevo municipio
    public async Task<MunicipioEntity> CreateMunicipalityAsync(
        string codigoMunicipio,
        string nombreMunicipio,
        string codigoDepartamento)
    {
        return await _municipioRepository.CrearMunicipioAsync(codigoMunicipio, nombreMunicipio, codigoDepartamento);
    }

    // Actualizar un municipio existente
    public async Task<bool> UpdateMunicipalityAsync(
        int id,
        string codigoMunicipio,
        string nombreMunicipio,
        string codigoDepartamento)
    {
        return await _municipioRepository.ActualizarMunicipioAsync(
            id,
            codigoMunicipio,
            nombreMunicipio,
            codigoDepartamento);
    }

    // Eliminar un municipio
    public async Task<bool> DeleteMunicipalityAsync(int id)
    {
        return await _municipioRepository.EliminarMunicipioAsync(id);
    }
}
