using CoinsBack.Core.DTOs;
using CoinsBack.Core.Entities;

namespace CoinsBack.Core.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
}
