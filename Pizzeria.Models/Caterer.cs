﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pizzeria.Models
{
    public class Caterer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsAvailable { get; set; }
    }
}
