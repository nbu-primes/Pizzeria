using System;
using Pizzeria.Models.DTO;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.DataServices.Contracts
{
    public interface ICatererService
    {
        IEnumerable<CatererDto> GetCaterers();
    }
}
