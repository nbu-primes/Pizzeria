using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pizzeria.Models.DTO
{
    public class UserDto
    {
        public UserDto(Users u)
        {
            this.Id = u.Id;
            this.FirstName = u.FirstName;
            this.LastName = u.LastName;
            this.Email = u.Email;
            this.DepositedCash = u.DepositedCash;
            this.Role = u.Role.RoleName;
        }
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public string Role { get; set; }
        
        public decimal DepositedCash { get; set; }
    }
}
