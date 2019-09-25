using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IronFoodTruck.Core;
using Microsoft.EntityFrameworkCore;

namespace IronFoodTruck.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly IronFoodTruckDbContext _context;

        public SqlRestaurantData(IronFoodTruckDbContext context)
        {
            _context = context;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            _context.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Restaurant Delete(int restaurantId)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == restaurantId);

            if (restaurant != null)
                _context.Restaurants.Remove(restaurant);

            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }

        public Restaurant GetById(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public int GetCountOfRestaurants()
        {
            return _context.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetListByName(string name)
        {
            return _context.Restaurants.
                Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name)).
                ToList();
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = _context.Restaurants.Attach(updatedRestaurant);
            restaurant.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
