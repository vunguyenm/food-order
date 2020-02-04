﻿using System.Collections.Generic;
using System.Linq;
using FoodOrder.Core;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly FoodOrderDbContext _db;

        public SqlRestaurantData(FoodOrderDbContext db)
        {
            _db = db;
        }
        
        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in _db.Restaurants
                where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                orderby r.Name
                select r;
            return query;
        }

        public Restaurant GetById(int id)
        {
            return _db.Restaurants.Find(id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = _db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _db.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                _db.Remove(restaurant);
            }
            return restaurant;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}