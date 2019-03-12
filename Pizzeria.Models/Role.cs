using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pizzeria.Models
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}

