using Pizzeria.Data;
using Pizzeria.DataServices.Contracts;
using Pizzeria.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Pizzeria.DataServices
{
    class CatererService : ICatererService
    {

        private readonly ApplicationDbContext dbContext;

        public CatererService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
        }
        public IEnumerable<CatererDto> GetCaterers()
        {
            var caterers = this.dbContext.Caterers
           .Where(r => r.IsAvailable == true)
           .Select(r => new CatererDto(r))
           .ToList();

            return caterers;
        }
    }
}
