using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IronFoodTruck.Core;
using IronFoodTruck.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IronFoodTruck.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetById(restaurantId);

            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = _restaurantData.Delete(restaurantId);
            _restaurantData.Commit();

            if (restaurant == null)
                return RedirectToPage("./NotFound");

            TempData["CrudMessage"] = $"{restaurant.Name} has been deleted";

            return RedirectToPage("./List");
        }
    }
}