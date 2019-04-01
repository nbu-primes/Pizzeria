using System;

namespace Pizzeria.Models.DTO
{
    public class AdditiveDto
    {
        public AdditiveDto()
        {
            
        }
        public AdditiveDto(Additive a)
        {
            this.Id = a.Id;
            this.Name = a.Name;
            this.Price = a.Price;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}