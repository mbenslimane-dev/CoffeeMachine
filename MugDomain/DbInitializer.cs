using MugDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MugDomain
{
    public static class DbInitializer
    {
        public static void Initialize(MugDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any badges.
            if (context.Mugs.Any())
            {
                return;   // DB has been seeded
            }

            var mugs = new Mug[]
            {
                new Mug{Size=50, Quantity=10},
                new Mug{Size=100, Quantity=10},
                new Mug{Size=150, Quantity=10},

            };

            context.Mugs.AddRange(mugs);

            context.SaveChanges();
        }
    }
}
