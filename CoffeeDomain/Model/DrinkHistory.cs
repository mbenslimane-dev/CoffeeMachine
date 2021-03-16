

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeDomain.Model
{
    public class DrinkHistory
    {
        public long Id { get; set; }

        [ForeignKey("Drink")]
        public int DrinkId { get; set; }
        public Drink Drink { get; set; }
        
        public int SugarQuantity { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public DateTime RequestDate { get; set; }

        public bool Equal(DrinkHistory drinkHistory)
        {
            return drinkHistory.SugarQuantity == SugarQuantity
                    && drinkHistory.ClientId == ClientId
                    && drinkHistory.DrinkId == DrinkId;
        }
        
    }
}
