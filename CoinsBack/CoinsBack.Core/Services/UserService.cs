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

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(
            u => new UserDto { 
                Id = u.Id, 
                NombreCliente = u.Nombre, 
                TelefonoCliente = u.Telefono,
                DireccionCliente = u.Direccion,
            });
    }
}
