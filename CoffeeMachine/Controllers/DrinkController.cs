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
    public class DrinkController : ControllerBase
    {
        private readonly IDrinkService drinkService;

        public DrinkController(IDrinkService drinkService)
        {
            this.drinkService = drinkService;
        }

  
        [HttpGet]
        public async Task<IEnumerable<CoffeeDomain.Model.Drink>> Get()
        {
            return await drinkService.GetDrinks();
        }
    }
}
