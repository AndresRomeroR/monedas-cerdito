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
}
