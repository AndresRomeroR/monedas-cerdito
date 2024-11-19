using CoinsBack.Core.DTOs;
using CoinsBack.Core.Entities;


namespace CoinsBack.Core.Interfaces;

public interface IDepartamentoService
{
    Task<IEnumerable<DepartamentoDTO>> GetAllDepartmentAsync();
    Task<DepartamentoEntity> GetDepartmentByIdAsync(int id);
    Task<DepartamentoEntity> CreateDepartmentAsync(
        string codigoDepartamento,
        string nombreDepartamento,
        int codigoPais);
    Task<bool> UpdateDepartmentAsync(int id,
        string codigoDepartamento,
        string nombreDepartamento,
        int codigoPais);
    Task<bool> DeleteDepartmentAsync(int id);
}
