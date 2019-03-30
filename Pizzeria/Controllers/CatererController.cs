using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.DataServices.Contracts;
using Pizzeria.Models.DTO;

namespace Pizzeria.Api.Controllers
{
    [Route("api/caterers")]
    [ApiController]
    public class CatererController : ControllerBase
    {
        private readonly ICatererService catererService;
        public CatererController(ICatererService catererService)
        {
            this.catererService = catererService ?? throw new ArgumentNullException("catererService");
        }

        [HttpGet]
        public IEnumerable<CatererDto> GetCaterers()
        {
            return this.catererService.GetCaterers();
        }
    }
}