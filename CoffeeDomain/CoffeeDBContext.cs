namespace CoffeeDomain
{
    using CoffeeDomain.Model;
    using Microsoft.EntityFrameworkCore;

    public class CoffeeDBContext : DbContext
    {
        public CoffeeDBContext(DbContextOptions<CoffeeDBContext> options)
            : base(options)
        {
           
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Drink> Drinks { get; set; }

        public DbSet<DrinkHistory> DrinkHistories { get; set; }


    }
}
