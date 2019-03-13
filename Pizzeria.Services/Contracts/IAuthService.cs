using Pizzeria.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Services.Contracts
{
    public interface IAuthService
    {
        string GenerateToken(UserDto user);
    }
}
