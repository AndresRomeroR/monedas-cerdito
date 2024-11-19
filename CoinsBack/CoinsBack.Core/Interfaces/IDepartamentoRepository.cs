using CoinsBack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsBack.Core.Interfaces;

public interface IDepartamentoRepository
{
    Task<List<DepartamentoEntity>> GetAllAsync();
    Task<DepartamentoEntity> GetByIdAsync(int id);
    Task<DepartamentoEntity> CrearDepartamentoAsync(
        string codigoDepartamento,
        string nombreDepartamento,
        int codigoPais);
    Task<bool> ActualizarDepartamentoAsync(
        int id,
        string codigoDepartamento,
        string nombreDepartamento,
        int codigoPais);
    Task<bool> EliminarDepartamentoAsync(int id);
}
