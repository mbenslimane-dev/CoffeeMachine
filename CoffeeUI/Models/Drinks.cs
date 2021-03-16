using System;
using System.Collections.Generic;

namespace CoffeeUI.Models
{
    public class Drinks
    {
        
        public List<CoffeeDomain.Model.Drink> DrinkList{ get; set; }


        public Drinks(List<CoffeeDomain.Model.Drink> drinkList)
        {
            DrinkList = drinkList;
        }
    }
}