using Microsoft.AspNetCore.Mvc;
using Pizzeria.DataServices.Contracts;
using Pizzeria.Models.DTO;
using Pizzeria.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IAuthService jwtAuthService;

        public AuthController(IUserService userService, IAuthService jwtAuthService)
        {
            this.userService = userService ?? throw new ArgumentNullException("userService");
            this.jwtAuthService = jwtAuthService ?? throw new ArgumentNullException("jwtAuthService");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginDto newUser)
        {
            if (newUser == null)
            {
                return BadRequest("Invalid client request");
            }

            var userDto = this.userService.Authenticate(newUser);

            if (userDto == null)
            {
                return Unauthorized();
            }

            string token = this.jwtAuthService.GenerateToken(userDto);
            return Ok(new { Token = token });
        }
    }
}
