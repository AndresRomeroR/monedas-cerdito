
using CoinsBack.Core.DTOs;
using CoinsBack.Core.Entities;

namespace CoinsBack.Core.Interfaces;

public interface IMunicipioService
{
    Task<IEnumerable<MunicipioDTO>> GetAllMunicipalityAsync();
    Task<MunicipioEntity> GetMunicipalityByIdAsync(int id);
    Task<MunicipioEntity> CreateMunicipalityAsync(
        string codigoMunicipio,
        string nombreMunicipio,
        string codigoDepartamento);
    Task<bool> UpdateMunicipalityAsync(
        int id,
        string codigoMunicipio,
        string nombreMunicipio,
        string codigoDepartamento);
    Task<bool> DeleteMunicipalityAsync(int id);
}
