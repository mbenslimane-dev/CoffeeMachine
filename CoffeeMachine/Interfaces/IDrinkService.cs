

using CoffeeDomain.Enumerations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeMachine.Interfaces
{
    public interface IDrinkService
    {
        Task<CoffeeDomain.Objects.Drink> GetDrink(DrinkTypeEnum drinkType);

        Task<IEnumerable<CoffeeDomain.Model.Drink>> GetDrinks();
    }
}
