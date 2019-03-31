using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.DataServices.Contracts;
using Pizzeria.Models.DTO;

namespace Pizzeria.Api.Controllers
{
    [Route("api/additives")]
    [ApiController]
    public class AdditiveController : ControllerBase
    {
        private readonly IAdditiveService additiveService;
        public AdditiveController(IAdditiveService additiveService)
        {
            this.additiveService = additiveService ?? throw new ArgumentNullException("additiveService");
        }

        [HttpGet]
        public IEnumerable<AdditiveDto> GetAdditives()
        {
            return this.additiveService.GetAdditives();
        }

    }
}