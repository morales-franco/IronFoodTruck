using IronFoodTruck.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IronFoodTruck.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Pizza Hut", Location = "Auckland", Cuisine = CuisineType.NewZealand },
                new Restaurant { Id = 2, Name = "Survive", Location= "Buenos Aires", Cuisine = CuisineType.Argentine },
                new Restaurant { Id= 3, Name = "El Tano", Location = "Buenos Aires", Cuisine = CuisineType.Argentine }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        public Restaurant GetById(int id)
        {
            return _restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetListByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return GetAll();

            return _restaurants
                .Where(r => r.Name.StartsWith(name))
                .OrderBy(r => r.Name);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = _restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);

            if (restaurant == null)
                return restaurant;

            restaurant.Name = updatedRestaurant.Name;
            restaurant.Location = updatedRestaurant.Location;
            restaurant.Cuisine = updatedRestaurant.Cuisine;

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {

            _restaurants.Add(newRestaurant);
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Delete(int restaurantId)
        {
            var restaurant = _restaurants.SingleOrDefault(r => r.Id == restaurantId);

            if(restaurant != null)
                _restaurants.Remove(restaurant);

            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return _restaurants.Count();
        }
    }
}
