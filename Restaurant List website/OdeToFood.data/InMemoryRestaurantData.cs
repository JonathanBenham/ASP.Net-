using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> Restaurants;

        public InMemoryRestaurantData()
        {
            Restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1,Cuisine=CuisineType.Indian, Location="Paris", Name = "OResto"},
                new Restaurant{Id=2, Cuisine=CuisineType.Italian, Location="Panam", Name="Pedro"},
                new Restaurant{Id=2, Cuisine=CuisineType.Indian, Location="India", Name="Salsa"}
            };

        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            Restaurants.Add(newRestaurant);
            newRestaurant.Id = Restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
            {

            }
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = Restaurants.SingleOrDefault(restaurant => restaurant.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;

            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string Name = null)
        {
            return from r in Restaurants
                   where string.IsNullOrEmpty(Name) || r.Name.StartsWith(Name)
                   orderby r.Name
                   select r;
        }


        public Restaurant GetById(int id)
        {
            return Restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Delete(int id)
        {
            var restaurant = Restaurants.FirstOrDefault(r => r.Id == id);
            if(restaurant != null)
            {
                Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return Restaurants.Count();
        }
    }
}
