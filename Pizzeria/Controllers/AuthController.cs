using Microsoft.AspNetCore.Mvc;
using Pizzeria.DataServices.Contracts;
using Pizzeria.DataServices.CustomExceptions;
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
        public IActionResult Login([FromBody]LoginDto u)
        {
            if (u == null)
            {
                return BadRequest("Invalid client request");
            }

            var userDto = this.userService.Authenticate(u);

            if (userDto == null)
            {
                return Unauthorized();
            }

            string token = this.jwtAuthService.GenerateToken(userDto);
            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto newUser)
        {
            if (newUser == null)
            {
                return BadRequest("Invalid client request");
            }
            try
            {
                this.userService.Create(newUser);
                return this.Ok();
            }
            catch (DuplicatedEmailException ex)
            {
                return new BadRequestObjectResult(ex);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
