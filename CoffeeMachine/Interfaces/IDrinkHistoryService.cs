

using CoffeeDomain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeMachine.Interfaces
{
    public interface IDrinkHistoryService
    {
        Task<IEnumerable<DrinkHistory>> GetClientDrinkHistory(string badgeNumber);

        Task<int> AddOrUpdateDrinkHistory(DrinkHistory drinkHistory);

    }
}
