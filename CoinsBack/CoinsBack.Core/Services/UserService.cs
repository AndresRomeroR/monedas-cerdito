using CoinsBack.Core.DTOs;
using CoinsBack.Core.Entities;
using CoinsBack.Core.Interfaces;

namespace CoinsBack.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    // Obtener todos los usuarios
    public async Task<IEnumerable<UserDto>> GetAllUserAsync()
    {
        var usuarios = await _userRepository.GetAllAsync();
        return usuarios.Select(u => new UserDto
        {
            Id = u.Id,
            NombreCliente = u.NombreUsuario,
            TelefonoCliente = u.TelefonoUsuario,
            DireccionCliente = u.DireccionDetalle
        });
    }

    // obtener un usuario por su id
    public async Task<UserEntity> getUserbyidasync(int id)
    {
        var usuario = await _userRepository.GetByIdAsync(id);
        if (usuario == null)
            return null;

        return usuario;
    }

    // crear un nuevo usuario
    public async Task<UserEntity> createUserasync(
        string nombreUsuario,
        string telefonoUsuario,
        string direccionDetalle,
        int paisId,
        string departamentoId,
        int municipioId)
    {
        return await _userRepository.CrearUsuarioAsync(
            nombreUsuario,
            telefonoUsuario,
            direccionDetalle,
            paisId,
            departamentoId,
            municipioId);
    }

    // actualizar un usuario existente
    public async Task<bool> updateUsuarioasync(
        int idUsuario,
        string nombreUsuario,
        string telefonoUsuario,
        string direccionUsuario,
        int idPaisUsuario,
        string idDepartamentoUsuario,
        int idMunicipioUsuario)
    {
        return await _userRepository.ActualizarUsuarioAsync(
            idUsuario,
            nombreUsuario,
            telefonoUsuario,
            direccionUsuario,
            idPaisUsuario,
            idDepartamentoUsuario,
            idMunicipioUsuario);
    }

    // eliminar un usuario
    public async Task<bool> deleteUsuarioasync(int id)
    {
        return await _userRepository.EliminarUsuarioAsync(id);
    }
}
