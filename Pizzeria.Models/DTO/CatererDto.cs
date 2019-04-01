using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Models.DTO
{
    public class CatererDto
    {

        public CatererDto(Caterer c)
        {
            this.Id = c.Id;
            this.Name = c.Name;
        }
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
