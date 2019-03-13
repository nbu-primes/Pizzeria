using Microsoft.EntityFrameworkCore;
using Pizzeria.Data;
using Pizzeria.DataServices.Contracts;
using Pizzeria.Models;
using Pizzeria.Models.DTO;
using Pizzeria.Services;
using Pizzeria.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzeria.DataServices
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;

        private const string DefaultRole = "Customer";

        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
        }

        public UserDto Authenticate(LoginDto loginData)
        {
            if (loginData == null)
                return null;

            var user = dbContext.Users
                .Where(x => x.Email == loginData.Email)
                .Include(u => u.Role)
                .SingleOrDefault();

            // check if email exists
            if (user == null)
                return null;

            // check if password is correct
            if (!AuthUtils.VerifyPasswordHash(loginData.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return new UserDto(user);
        }

        public UserDto Create(UserDto userData, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("Password is required");

            if (this.dbContext.Users.Any(x => x.Email == userData.Email))
                throw new ArgumentException("Email \"" + userData.Email + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            AuthUtils.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            string userRoleName = userData.Role ?? DefaultRole;
            Users user = new Users()
            {
                Id = Guid.NewGuid(),
                Email = userData.Email,
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                DepositedCash = userData.DepositedCash,
                Role = this.dbContext.Roles.Single(r => r.RoleName == userRoleName),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            this.dbContext.Users.Add(user);
            this.dbContext.SaveChanges();

            return new UserDto(user);
        }
    }
}
