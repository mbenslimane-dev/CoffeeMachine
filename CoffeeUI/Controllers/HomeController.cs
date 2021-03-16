using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoffeeUI.Models;
using CoffeeUI.Utilities;
using Newtonsoft.Json;

namespace CoffeeUI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await HttpUtilities.GetRequest("https://localhost:44394/Drink");

            var stringResponse = await response.Content.ReadAsStringAsync();


            var drinks = JsonConvert.DeserializeObject<List<CoffeeDomain.Model.Drink>>(stringResponse);

            Drinks model = new Drinks(drinks);

            return View(model);
        }
  
    }
}
