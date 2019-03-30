using Pizzeria.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.DataServices.Contracts
{
    public interface IAdditiveService
    {
        IEnumerable<AdditiveDto> GetAdditives();
    }
}
