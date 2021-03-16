using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeDomain.Model;
using CoffeeMachine.Interfaces;
using CoffeeMachine.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

  
        [HttpGet("{badgeNumber}")]
        public  Task<Client> Get(string badgeNumber)
        {
            return clientService.GetClientByBadge(badgeNumber);
        }


    }
}
