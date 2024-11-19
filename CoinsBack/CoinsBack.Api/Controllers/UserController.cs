using CoinsBack.Core.DTOs;
using CoinsBack.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoinsBack.Api.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<UserDto>> GetAll()
        {
            return (await _userService.GetAllUsersAsync()).ToList();
        }
    }
}
