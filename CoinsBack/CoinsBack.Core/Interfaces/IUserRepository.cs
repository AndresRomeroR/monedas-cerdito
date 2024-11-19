using CoinsBack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsBack.Core.Interfaces;

public interface IUserRepository
{
    Task<List<UserEntity>> GetAllAsync();
    Task<UserEntity> GetByIdAsync(int id);
    Task<UserEntity> CrearUsuarioAsync(
        string nombreUsuario,
        string telefonoUsuario,
        string direccionDetalle,
        int paisId,
        string departamentoId,
        int municipioId);
    Task<bool> ActualizarUsuarioAsync(
        int idUsuario,
        string nombreUsuario,
        string telefonoUsuario,
        string direccionUsuario,
        int idPaisUsuario,
        string idDepartamentoUsuario,
        int idMunicipioUsuario);
    Task<bool> EliminarUsuarioAsync(int id);
}
