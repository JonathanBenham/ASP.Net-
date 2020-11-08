using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.data
{
    public class SqlRestaurantsData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantsData(OdeToFoodDbContext db)
        {
            this.db = db;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;

        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                db.Remove(restaurant);
        
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string Name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(Name) || string.IsNullOrEmpty(Name)
                        orderby r.Name
                        select r;
            return query;

        }

        public Restaurant Update(Restaurant updatedrestaurant)
        {
            var entity = db.Restaurants.Attach(updatedrestaurant);
            entity.State = EntityState.Modified;
            return updatedrestaurant;
        }

        

    }
}
