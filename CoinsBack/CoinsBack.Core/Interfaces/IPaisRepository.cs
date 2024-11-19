using CoinsBack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsBack.Core.Interfaces;

public interface IPaisRepository
{
    Task<List<PaisEntity>> GetAllAsync();
    Task<PaisEntity> GetByIdAsync(int id);
    Task<PaisEntity> CrearPaisAsync(string codigoPais, string nombrePais);
    Task<bool> ActualizarPaisAsync(int id, string codigoPais, string nombrePais);
    Task<bool> EliminarPaisAsync(int id);
}
