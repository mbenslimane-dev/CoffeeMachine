using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mug.Interfaces;
using Mug.Services;
using MugDomain.Objects;
using MugDomain.Enumerations;

namespace Mug.Controllers
{
    [Route("mugApi/[controller]")]
    [ApiController]
    public class MugController : ControllerBase
    {
        private readonly IMugService mugService;

        public MugController(IMugService mugService)
        {
            this.mugService = mugService;
        }

        
        [HttpGet("{mugSize}")]
        public Task<Cup> Get(MugSizeEnum mugSize)
        {
            return  mugService.UseMug(mugSize);
        }

    }
}
