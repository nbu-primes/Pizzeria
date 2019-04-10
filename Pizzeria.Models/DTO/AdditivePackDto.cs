using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Models.DTO
{
    /// <summary>
    /// Holds the information coming from the client which is what additive how many times is picked.
    /// </summary>
    public class AdditivePackDto
    {
        public AdditiveDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
