using Microsoft.EntityFrameworkCore;
using Pizzeria.Data;
using Pizzeria.DataServices.Contracts;
using Pizzeria.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzeria.DataServices
{
    class AdditiveService : IAdditiveService
    {
        private readonly ApplicationDbContext dbContext;

        public AdditiveService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
        }
        public IEnumerable<AdditiveDto> GetAdditives()
        {
            var additives = this.dbContext.Additives
           .Select(r => new AdditiveDto(r))
           .ToList();

            return additives;
        }
    }
}
