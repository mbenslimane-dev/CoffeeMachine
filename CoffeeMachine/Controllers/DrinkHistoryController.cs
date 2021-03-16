using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeDomain.Model;
using CoffeeMachine.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachine.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DrinkHistoryController : ControllerBase
    {
        private readonly IDrinkHistoryService drinkHistoryService;

        public DrinkHistoryController(IDrinkHistoryService drinkHistoryService)
        {
            this.drinkHistoryService = drinkHistoryService;
        }



        // GET api/values/5
        [HttpGet("{badgeNumber}")]
        public async Task<IEnumerable<DrinkHistory>> Get(string badgeNumber)
        {
            return await drinkHistoryService.GetClientDrinkHistory(badgeNumber);
        }

        // POST api/values
        [HttpPost]
        public async Task<StatusCodeResult> Post([FromBody] DrinkHistory selectedDrink)
        {
            var status = await drinkHistoryService.AddOrUpdateDrinkHistory(selectedDrink);
            return StatusCode(status);
        }

        
    }
}
