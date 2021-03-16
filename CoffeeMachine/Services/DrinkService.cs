
using CoffeeDomain;
using CoffeeDomain.Enumerations;
using CoffeeMachine.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CoffeeMachine.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly CoffeeDBContext coffeeDomainDBConext;

        public DrinkService(CoffeeDBContext coffeeDomainDBConext)
        {
            this.coffeeDomainDBConext = coffeeDomainDBConext;
        }

        public async Task<CoffeeDomain.Model.Drink> GetDrink(DrinkTypeEnum drinkType)
        {
            var drink = await coffeeDomainDBConext.Drinks.FirstOrDefaultAsync(x => x.Name == drinkType.ToString());

            return drink;
        }

        public async Task<IEnumerable<CoffeeDomain.Model.Drink>> GetDrinks()
        {
            var result = await coffeeDomainDBConext.Drinks.ToListAsync();
            return result;
        }
    }
}
