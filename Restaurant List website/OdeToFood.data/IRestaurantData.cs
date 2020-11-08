using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string Name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedrestaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int id);
        int GetCountOfRestaurants();
        int Commit();
    }
}
