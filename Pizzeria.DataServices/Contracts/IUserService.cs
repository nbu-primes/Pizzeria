using Pizzeria.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.DataServices.Contracts
{
    public interface IUserService
    {
        UserDto Authenticate(LoginDto loginData);
        UserDto Create(UserDto userData, string password);

    }
}
