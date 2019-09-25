using IronFoodTruck.Core;
using IronFoodTruck.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IronFoodTruck.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;

        public Restaurant Restaurant { get; set; }
        [TempData]
        public string Message { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetById(restaurantId);

            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            //Default behaviour.
            return Page();
        }
    }
}