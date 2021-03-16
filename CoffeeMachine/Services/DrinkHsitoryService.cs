
using CoffeeMachine.Interfaces;
using CoffeeDomain;
using CoffeeDomain.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace CoffeeMachine.Services
{
    public class DrinkHistoryService : IDrinkHistoryService
    {
        private readonly CoffeeDBContext coffeeDBContext;

        public DrinkHistoryService(CoffeeDBContext coffeeDBContext)
        {
            this.coffeeDBContext = coffeeDBContext;
        }

        public async Task<IEnumerable<DrinkHistory>> GetClientDrinkHistory(string badgeNumber)
        {
            return await coffeeDBContext.DrinkHistories.Where(x => x.Client.BadgeNumber == badgeNumber).ToListAsync();
        }

        public async Task<int> AddOrUpdateDrinkHistory(DrinkHistory drinkHistory)
        {
            var actualDrink = await coffeeDBContext.DrinkHistories.FirstOrDefaultAsync(x => x.Equal(drinkHistory));

            drinkHistory.RequestDate = DateTime.Now;

            if( actualDrink == null)
            {
                coffeeDBContext.DrinkHistories.Add(drinkHistory);
            }
            else
            {
                coffeeDBContext.Entry(drinkHistory).State = EntityState.Modified;
            }

            return coffeeDBContext.SaveChanges();
        }


    }
}
