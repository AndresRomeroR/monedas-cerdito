using CoinsBack.Core.DTOs;
using CoinsBack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsBack.Core.Interfaces;

public interface IPaisService
{
    Task<IEnumerable<PaisDTO>> GetAllCountryAsync();
    Task<PaisEntity> GetCountryByIdAsync(int id);
    Task<PaisEntity> CreateCountryAsync(string codigoPais, string nombrePais);
    Task<bool> UpdateCountryAsync(int id, string codigoPais, string nombrePais);
    Task<bool> DeleteCountryAsync(int id);
}
