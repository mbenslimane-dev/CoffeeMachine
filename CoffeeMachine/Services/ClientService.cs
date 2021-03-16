
using CoffeeMachine.Interfaces;
using CoffeeDomain;
using CoffeeDomain.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoffeeMachine.Services
{
    public class ClientService : IClientService
    {
        private readonly CoffeeDBContext coffeeDBConext;

        public ClientService(CoffeeDBContext coffeeDBConext)
        {
            this.coffeeDBConext = coffeeDBConext;
        }


        public async Task<IEnumerable<Client>> GetAllClients ()
        {
            return await coffeeDBConext.Clients.ToListAsync();
        }

        public async Task<Client> GetClientByBadge(string badgeNumber)
        {
            return await coffeeDBConext.Clients.FirstOrDefaultAsync(x=> x.BadgeNumber == badgeNumber);
        }

    }
}
