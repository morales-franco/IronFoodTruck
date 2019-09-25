using IronFoodTruck.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IronFoodTruck.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetListByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int restaurantId);
        int GetCountOfRestaurants();
        int Commit();
    }

    
}
