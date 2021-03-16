
using CoffeeDomain.Model;
using System.Threading.Tasks;

namespace CoffeeMachine.Interfaces
{
    public interface IClientService
    {
         Task<Client> GetClientByBadge(string badgeNumber);
    }
}
