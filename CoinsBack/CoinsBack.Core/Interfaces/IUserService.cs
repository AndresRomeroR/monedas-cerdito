using CoinsBack.Core.DTOs;
using CoinsBack.Core.Entities;

namespace CoinsBack.Core.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUserAsync();
    Task<UserEntity> getUserbyidasync(int id);
    Task<UserEntity> createUserasync(
        string nombreUsuario,
        string telefonoUsuario,
        string direccionDetalle,
        int paisId,
        string departamentoId,
        int municipioId);
    Task<bool> updateUsuarioasync(
        int idUsuario,
        string nombreUsuario,
        string telefonoUsuario,
        string direccionUsuario,
        int idPaisUsuario,
        string idDepartamentoUsuario,
        int idMunicipioUsuario);
    Task<bool> deleteUsuarioasync(int id);
}
