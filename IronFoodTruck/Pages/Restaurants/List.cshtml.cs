using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IronFoodTruck.Core;
using IronFoodTruck.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace IronFoodTruck.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IRestaurantData _restaurantData;

        public  string Message { get; set; }

        [TempData]
        public string CrudMessage { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configuration,
            IRestaurantData restaurantData)
        {
            _configuration = configuration;
            _restaurantData = restaurantData;
        }

        //Http Get
        public void OnGet()
        {
            //Retrieve value from appSettings
            Message = _configuration["Message"];

            //Inflate list
            Restaurants = _restaurantData.GetListByName(SearchTerm);
        }
    }
}