using CoinsBack.Core.Entities;

namespace CoinsBack.Core.Interfaces;

public interface IMunicipioRepository
{
    Task<List<MunicipioEntity>> GetAllAsync();
    Task<MunicipioEntity> GetByIdAsync(int id);
    Task<MunicipioEntity> CrearMunicipioAsync(
        string codigoMunicipio,
        string nombreMunicipio,
        string codigoDepartamento);
    Task<bool> ActualizarMunicipioAsync(
        int id,
        string codigoMunicipio,
        string nombreMunicipio,
        string codigoDepartamento);
    Task<bool> EliminarMunicipioAsync(int id);
}
